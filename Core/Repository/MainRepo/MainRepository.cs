using Core.Security;
using Core.Servises.MainSer;
using Data.Models;
using Data.MyDbFile;
using Data.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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



        public Admin GetAdminByUsername(string username)
        {
            Admin admin = _db.Admins.SingleOrDefault(u => u.Username == username);
            return admin;
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

        public bool IsAdminExist(SignOutVm signOut)
        {
            Admin admin = _db.Admins.SingleOrDefault(u => (u.Username == signOut.Username));
            if(admin == null) { return false; }

            return true;
        }
        public bool IsUsernameValid(SignInVm signIn)
        {
            string hashPassword = HashPasswordC.EncodePasswordMd5(signIn.Password);
            Admin admin = _db.Admins.SingleOrDefault(u => (u.Username == signIn.Username) && (u.Password == hashPassword));
            if (admin != null) { return true;}
            return false;
        }
    }
}
