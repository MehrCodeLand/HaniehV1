using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creator
{
    public class CreateMyBookId
    {
        public static int CreateId()
        {
            Random rnd = new Random();
            return rnd.Next(10000, 99999);
        }
    }
}
