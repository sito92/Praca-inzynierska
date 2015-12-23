using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Models.File
{
    public class UploadFile
    {
        public List<string> FormData  { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}