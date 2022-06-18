using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    public class DownloadFile
    {
        //File to download
        static string remoteDownloadFilePath = "/200501942 Akshat Patel/info.csv";
        //Create copy of file
        static string localDownloadFileDestination = @"C:\Users\aksha\source\repos\ConsoleApp3\ConsoleApp3\ConsoleApp3.csproj";

        public string fileDownload(string url, string username, string password)
        {
            string output;
            url = url + remoteDownloadFilePath;
            Console.WriteLine(url);
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.DownloadFile;//method of transaction

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(username, password);

            //Indicate Binary so that any file type can be downloaded
            request.UseBinary = true;
            try
            {
                //Create an instance of a Response object
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //Request a Response from the server
                using (Stream stream = response.GetResponseStream())
                {
                    //Build a variable to hold the data
                    byte[] buffer = new byte[1024]; //1 Mb chucks
                                                    //Establish a file stream to collect data from the response
                    using (FileStream fs = new FileStream(localDownloadFileDestination, FileMode.Create))
                    {
                        //Read data from the stream
                        //"ReadCount" is a variable holding length of byte array
                        int ReadCount = stream.Read(buffer, 0, buffer.Length);

                        //Loop until the stream data is complete
                        while (ReadCount > 0)
                        {
                            //Write the data to the file
                            fs.Write(buffer, 0, ReadCount);

                            //Read data from the stream at the rate of the size of the buffer
                            ReadCount = stream.Read(buffer, 0, buffer.Length);
                        }
                    }
                }

                //Output the results to the return string
                output = $"Download Complete, status {response.StatusDescription}";
            }
            catch (Exception e)
            {
                //Something went wrong
                output = e.Message;
            }

            //Return the output of the Responce
            return (output);
        }
    }
}
