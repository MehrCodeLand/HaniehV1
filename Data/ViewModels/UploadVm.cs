using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class UploadVm
    {
        public string PaintName { get; set; }
        public string ImagePaintName { get; set; }
        public string Description { get; set; }
        public string PaintImageName { get; set; }
        public IFormFile UploadImage { get; set; }
    }
}
