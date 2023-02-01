using Data.Models;
using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servises.AdminSer
{
    public interface IAdminService
    {
        bool CheckPaint(UploadVm upload);
        void AddPaint(UploadVm upload);
        bool IsAddPaint(int paintId);
        string SaveImage(UploadVm upload);
        AllPaintsVm AllPaints();
        DeletePaintVm GetPaintDelete(int id);
        void DeletePaint(int paintId);
        bool IsDeletePaint(int paintId);
        EditPaintVm GetPaintEdit(int paintId);
        void DeleteImage(string imageName);
        void EditPaint(EditPaintVm editPaint);
        string SaveImage(IFormFile paintCover , string oldImageName);
        void DeleteImageStr(string imageName);
        void Update(Paint paint);
        void Save();

    }
}
