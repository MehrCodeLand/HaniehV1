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
        ShowPaintVm GetPaintShow(int myPaintId);
    }
}
