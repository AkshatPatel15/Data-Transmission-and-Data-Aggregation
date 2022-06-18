using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    public class UploadFile
    {
        static string localUploadFilePath = @"C:\Users\aksha\source\repos\ConsoleApp3\ConsoleApp3\ConsoleApp3.csproj";
        //local file path to upload";



        public void FileUpload(string url, string username, string password)
        {
            string filename = "info2.csv";  //filename on FTP
            string remoteUploadFileDestination = "/200501942 Akshat Patel/" + filename;   //directory on server
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url + remoteUploadFileDestination);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            // Copy the contents of the file to the request stream.
            byte[] fileContents;
            using (StreamReader sourceStream = new StreamReader(localUploadFilePath)) //create testfile.txt on debug folder of your application with data 
            {
                fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            }
            request.ContentLength = fileContents.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
            }
        }
    }
}
