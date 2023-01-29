using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Paint
    {
        [Key]
        public int Id { get; set; }
        public int PaintId { get; set; }
        public string PaintName { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string ImagePaintName { get; set; }
        public string Description { get; set; }
        public int MyProperty { get; set; }
    }
}
