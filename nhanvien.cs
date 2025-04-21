using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlibangiay2
{
    public class nhanvien
    {
        public int Idnv { get; set; }
        public string Tennv { get; set; }
        public string Chucvunv { get; set; }
        public string Emailnv { get; set; }
        public string Sdtnv { get; set; }
        public string Rolenv { get; set; }

        public nhanvien() { }

        public nhanvien(int idnv, string tennv, string chucvunv, string emailnv, string sdtnv, string rolenv)
        {
            Idnv = idnv;
            Tennv = tennv;
            Chucvunv = chucvunv;
            Emailnv = emailnv;
            Sdtnv = sdtnv;
            Rolenv = rolenv;
        }
    }
}
