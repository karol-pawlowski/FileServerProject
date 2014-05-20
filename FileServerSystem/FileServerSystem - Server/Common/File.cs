using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileServerSystem___Server.Common
{
    public class File
    {
        private string _fileLength;
        private FileStream _fileData;
        private string _fileName;
        private string _fileExtension;

        public File(string fileLength, FileStream fileData, string fileName, string fileExtension)
        {
            _fileLength = fileLength;
            _fileData = fileData;
            _fileName = fileName;
            _fileExtension = fileExtension;
        }

        public string FileLength 
        {
            get
            {
                return _fileLength;
            }
            set
            {
                _fileLength = value;
            }
        }

        public FileStream FileData 
        {
            get
            {
                return _fileData;
            }
            set
            {
                _fileData = value;
            }
        }
        public string FileName 
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
            }
        }
        public string FileExtension 
        {
            get
            {
                return _fileExtension;
            }
            set
            {
                _fileExtension = value;
            }
        }
    }
}