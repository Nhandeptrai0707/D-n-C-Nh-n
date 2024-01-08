using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class UserBLL
    {
        UserDAL userdal = new UserDAL();
        public string CheckLogin(User user)
        {
            
              if (user.user == "")
            {
                return "tài khoản trống"; 
            }
              if(user.password == "")
            {

                return "mật khẩu trống";
            }
            string info = userdal.CheckLogin(user);
            return info;

        }
        public void TaoHoaDon(string makh, int manv, int sl, string mamh)
        {
            userdal.TaoHoaDon(makh, manv, sl, mamh);
        }
        public KhachHang TimKhachHang(string makh)
        {
            KhachHang kh = userdal.TimKhachHang(makh);
            
            return kh;
        }
        public void TaoKhachHang(string makh,string tenkh,string dckh,string sdt)
        {
            userdal.TaoKhachHang(makh, tenkh, dckh, sdt);
        }
    }
}
