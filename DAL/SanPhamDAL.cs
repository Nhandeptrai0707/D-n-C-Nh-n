using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPhamDAL:Data
    {
        
        public List<SanPham> loadSanPham() {
            
            
                List<SanPham> listSanPham = new List<SanPham>();
                listSanPham = loadSanPhamDTO();
                return listSanPham;
        }
        public List<SanPham> TimSanPham(string maloai)
        {
            List<SanPham> listSanPham = new List<SanPham>();
            listSanPham = TimSanPhamDTO(maloai);
            return listSanPham;
        }
        public List<SanPham> TimSanPhamTheoTen(string tensp)
        {
            List<SanPham> listSanPham = new List<SanPham>();
            listSanPham = TimSanPhamTheoTenDTO(tensp);
            return listSanPham;
        }
        public List<SanPham> SanPhamTangDan()
        {
            List<SanPham> listSanPham = new List<SanPham>();
            listSanPham = SanPhamTangDanDTO();
            return listSanPham;
        }
        public List<SanPham> SanPhamGiamDan()
        {
            List<SanPham> listSanPham = new List<SanPham>();
            listSanPham = SanPhamGiamDanDTO();
            return listSanPham;
        }

    }
}
