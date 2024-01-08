using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SanPhamBLL
    {
        SanPhamDAL SPDAL = new SanPhamDAL();
        public List<SanPham> listSanPham()
        {


            List<SanPham> listSanPham = new List<SanPham>();
            listSanPham = SPDAL.loadSanPham();
            return listSanPham;
        }
        public List<SanPham> TimSanPham(string maloai)
        {
            List<SanPham> listSanPham = new List<SanPham>();
            listSanPham = SPDAL.TimSanPham(maloai);
            return listSanPham;
        }
        public List<SanPham> TimSanPhamTheoTen(string tensp)
        {
            List<SanPham> listSanPham = new List<SanPham>();
            listSanPham = SPDAL.TimSanPhamTheoTen(tensp);
            return listSanPham;
        }
        public List<SanPham> SanPhamTangDan()
        {
            List<SanPham> listSanPham = new List<SanPham>();
            listSanPham = SPDAL.SanPhamTangDan();
            return listSanPham;
        }
        public List<SanPham> SanPhamGiamDan()
        {
            List<SanPham> listSanPham = new List<SanPham>();
            listSanPham = SPDAL.SanPhamTangDan();
            return listSanPham;
        }
    }
}
