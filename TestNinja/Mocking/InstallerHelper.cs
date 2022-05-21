﻿using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private readonly IFileDownloader _fileDownloader;

        public InstallerHelper(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }
        public bool DownloadInstaller(string customerName, string installerName)
        {
            var client = new WebClient();
            try
            {
                _fileDownloader.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}