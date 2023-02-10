using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servises.MainSer
{
    public interface IMainService
    {
        AllPaintForMainVm GetAllPaint();
        bool IsUsernameValid(SignInVm signIn);
        ShowPaintVm GetPaintShow(int myPaintId);
        Admin GetAdminByUsername(string username );
        bool IsAdminExist(SignOutVm signOut);
    }
}
