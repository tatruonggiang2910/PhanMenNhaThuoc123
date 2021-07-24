using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
namespace BLL
{
    public class QuanHuyenBLL
    {
        QuanHuyenDAL quanhuyen = new QuanHuyenDAL();
        public DataTable getQuanHuyenBLL()
        {
            return quanhuyen.getQuanHuyenDAL();
        }
    }
}
