using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Models.File
{
    public class UploadFile
    {
        public byte[] FormData { get; set; }
        public string File { get; set; }
    }
}