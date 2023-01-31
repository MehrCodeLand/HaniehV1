using Data.ViewModels;
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
        void Save();

    }
}
