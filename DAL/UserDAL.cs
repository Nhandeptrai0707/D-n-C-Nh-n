using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class UserDAL:Data
    {
        public string CheckLogin(User user)
        {
            string info = CheckLoginDTO(user);
            return info;

        }
        public void TaoHoaDon(string makh, int manv, int sl, string mamh)
        {
                TaoHoaDonDTO(makh, manv, sl, mamh);
            
        }
        public KhachHang TimKhachHang(string makh)
        {
            KhachHang kh = TimKhachHangDTO(makh);
            return kh;
        }
        public void TaoKhachHang(string makh, string tenkh, string dckh, string sdt) => TaoKhachHangDTO(makh,tenkh,dckh,sdt);
    }
}
