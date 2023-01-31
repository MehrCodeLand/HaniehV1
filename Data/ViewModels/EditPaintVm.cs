using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class EditPaintVm
    {
        public int PaintId { get; set; }
        public string NewPaintName { get; set; }
        public string NewDescription { get; set; }
        public string oldImageName { get; set; }
        public IFormFile NewPaintCover { get; set; }
    }
}
