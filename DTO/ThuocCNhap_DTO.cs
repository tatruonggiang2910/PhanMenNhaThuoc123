using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThuocCNhap_DTO
    {
        public string MATHUOC { get; set; }
        public string TENTHUOC { get; set; }
        public string DVT { get; set; }
        public double DONGIA { get; set; }
        public int SOLUONG { get; set; }
        public double THANHTIEN
        {
            get { return SOLUONG * DONGIA; }
        }
    }
}
