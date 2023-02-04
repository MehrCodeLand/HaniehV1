using Core.Servises.MainSer;
using Data.Models;
using Data.MyDbFile;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository.MainRepo
{
    public class MainRepository : IMainService
    {
        private readonly MyDb _db;
        public MainRepository(MyDb db)
        {
            _db = db;
        }
        public AllPaintForMainVm GetAllPaint()
        {
            IQueryable<Paint> result = _db.Paints;
            AllPaintForMainVm allPaint = new AllPaintForMainVm();
            allPaint.Paints = _db.Paints.OrderBy(u => u.Created).ToList();
            return allPaint;
        }
        public ShowPaintVm GetPaintShow(int myPaintId)
        {
            Paint paint = _db.Paints.SingleOrDefault(u => u.PaintId == myPaintId);
            if( paint != null)
            {
                ShowPaintVm paintVm = new ShowPaintVm()
                {
                    PaintName = paint.PaintName,
                    ImageName = paint.ImagePaintName,
                    Description = paint.Description,
                    CreateTime = paint.Created,
                };

                return paintVm;
            }

            return null;
        }
    }
}
