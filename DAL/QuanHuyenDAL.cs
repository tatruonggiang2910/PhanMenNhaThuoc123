using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSet1TableAdapters;
namespace DAL
{
    public class QuanHuyenDAL
    {
        QUANHUYENTableAdapter quanhuyen = new QUANHUYENTableAdapter();

        public DataTable getQuanHuyenDAL()
        {
            return quanhuyen.GetData();
        }
    }
}
