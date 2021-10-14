using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    class NhanVien
    {
        private string hoten, sdt, taikhoan, matkhau;
        public NhanVien(string ten, string sodienthoai, string tk, string mk)
        {
            hoten = ten;
            sdt = sodienthoai;
            taikhoan = tk;
            matkhau = mk;
        }
        //Kiem tra dinh dang mat khau: >= 6 ki tu ; co ca chu va so
        public bool KiemTraMatKhau()
        {
            bool CheckLength = false;
            if (matkhau.Length >= 6)
            {
                CheckLength = true;
            }

            if (CheckLength == true)
            {
                bool foundChar = false;
                bool foundNum = false;

                for (int i = 0; i < matkhau.Length; i++)
                {
                    if (foundChar && foundNum)
                    {
                        break;
                    }
                    if ((matkhau[i] >= 'A' && matkhau[i] <= 'Z') || matkhau[i] >= 'a' && matkhau[i] <= 'z')
                    {
                        foundChar = true;
                    }
                    if (matkhau[i] >= '0' && matkhau[i] <= '9')
                    {
                        foundNum = true;
                    }
                }

                if (CheckLength == true && foundNum == true && foundChar == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
