using Core.Creator;
using Core.Servises.AdminSer;
using Data.Models;
using Data.MyDbFile;
using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository.AdminRepo
{
    public class AdminRepository : IAdminService
    {
        private readonly MyDb _db;
        public AdminRepository( MyDb db )
        {
            _db = db;
        }


        #region Add Paint
        public void AddPaint(UploadVm upload)
        {
            // first save image if is work
            // then we add paint.
            string imageName = SaveImage(upload);
            if( imageName != null)
            {
                Paint paint = new Paint()
                {
                    ImagePaintName = imageName,
                    Description = upload.Description,
                    PaintName = upload.PaintName,
                    PaintId = CreateMyBookId.CreateId(),
                };

                _db.Paints.Add(paint);
                Save();
            }
        }
        public bool CheckPaint(UploadVm upload)
        {
            if (upload == null) { return false; }
            else if(upload.PaintName == null ) { return false; }
            else if(upload.Description.Length < 10) { return false; }
            else if(upload.UploadImage == null ) { return false; }

            return true;
        }
        public bool IsAddPaint(int paintId)
        {
            Paint paint = _db.Paints.SingleOrDefault( u => u.PaintId == paintId);
            if(paint != null)
            {
                return true;
            }

            return false;
        }
        public string SaveImage(UploadVm upload)
        {
            if(upload.UploadImage != null)
            {
                string imagePath = "";
                upload.PaintImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(upload.UploadImage.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/paintImage",  upload.PaintImageName);
                using ( var stream = new FileStream(imagePath, FileMode.Create ))
                {
                    upload.UploadImage.CopyTo(stream);
                    return upload.PaintImageName;
                }
                
            }

            return null ;
        }
        #endregion

        #region Delete
        public AllPaintsVm AllPaints()
        {
            IQueryable<Paint> result = _db.Paints;

            AllPaintsVm allPaints = new AllPaintsVm();
            allPaints.Paints = result.OrderBy(u => u.Created).ToList();
            return allPaints;
        }
        public DeletePaintVm GetPaintDelete(int id)
        {
            Paint paint = _db.Paints.FirstOrDefault(u => u.PaintId == id);
            if(paint == null)
            {
                return null;
            }

            DeletePaintVm deletePaint = new DeletePaintVm()
            {
                PainyId = paint.PaintId,
                PaintImageName = paint.ImagePaintName,
                PaintName = paint.PaintName,
            };

            return deletePaint;
        }
        public void DeletePaint(int paintId)
        {
            Paint paint = _db.Paints.SingleOrDefault( u => u.PaintId == paintId );
            if(paint != null)
            {
                string imageNmae = paint.ImagePaintName;
                _db.Paints.Remove(paint);
                Save();
                DeleteImage(imageNmae);
            }
        }
        public void DeleteImage(string imageName)
        {
            string imagePath = "";
            imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/paintImage", imageName);
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }
        public bool IsDeletePaint(int paintId)
        {
            Paint paint = _db.Paints.SingleOrDefault(u => u.PaintId == paintId);
            if(paint !=null)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Edit
        public EditPaintVm GetPaintEdit(int paintId)
        {
            Paint paint = _db.Paints.SingleOrDefault(u => u.PaintId == paintId);
            if( paint != null)
            {
                EditPaintVm editPaint = new EditPaintVm()
                {
                    NewDescription = paint.Description,
                    NewPaintName = paint.PaintName,
                    oldImageName = paint.ImagePaintName,
                    PaintId = paint.PaintId,
                };

                return editPaint;
            }

            return null;
        }

        public void EditPaint(EditPaintVm editPaint)
        {
            Paint paint = _db.Paints.SingleOrDefault( u => u.PaintId == editPaint.PaintId);


            paint.PaintName = editPaint.NewPaintName;
            paint.Description = editPaint.NewDescription;
            if(editPaint.NewPaintCover != null)
            {
                paint.ImagePaintName = SaveImage(editPaint.NewPaintCover, editPaint.oldImageName);
            }

            Update(paint);

        }

        public string SaveImage(IFormFile paintCover, string oldImageName)
        {
            string filePath = "";
            string paintNameForDelete = oldImageName;
            oldImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(paintCover.FileName);
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/paintImage", oldImageName);
            using( var stream = new FileStream(filePath, FileMode.Create))
            {
                paintCover.CopyTo(stream);
                DeleteImageStr(paintNameForDelete);
                return oldImageName;
            }
            return "NULL";
        }
        public void DeleteImageStr(string imageName)
        {
            string imagePath = "";
            imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/paintImage", imageName);
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }
        public void Update(Paint paint)
        {
            _db.Paints.Update(paint);
            Save();
        }





        #endregion

        
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
