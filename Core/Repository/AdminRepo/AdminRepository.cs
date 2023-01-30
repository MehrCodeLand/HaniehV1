using Core.Servises.AdminSer;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository.AdminRepo
{
    public class AdminRepository : IAdminService
    {
        public bool CheckPaint(UploadVm upload)
        {
            if (upload == null) { return false; }
            else if(upload.PaintName == null ) { return false; }
            else if(upload.Description.Length < 10) { return false; }
            else if(upload.UploadImage == null ) { return false; }

            return true;
        }
    }
}
