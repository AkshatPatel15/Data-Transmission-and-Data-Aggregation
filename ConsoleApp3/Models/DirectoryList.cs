using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Models
{
    internal class DirectoryList
    {
        public string GetDirectoryList(string url, string username, string password)
        {
            string output;
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(username, password);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    output = reader.ReadToEnd();
                }
            }
            return (output);
        }
    }
}
