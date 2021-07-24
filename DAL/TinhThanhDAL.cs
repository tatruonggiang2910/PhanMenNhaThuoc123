using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataSet1TableAdapters;
using System.Data;
namespace DAL
{
    public class TinhThanhDAL
    {
        TINHTHANHTableAdapter tinhthanh = new TINHTHANHTableAdapter();
        public DataTable getTinhThanhDAL()
        {
            return tinhthanh.GetData();
        }
    }
}
