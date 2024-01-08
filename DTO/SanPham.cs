using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        private string mAMH;
        private string mALOAI;
        private string tENMH;
        private string dVT;
        private int gIA;
        private string aNHMH;
        public SanPham(string mamh,string maloai,string ten,string dvt,int gia,string anh )
        {
            this.mAMH = mamh;
            this.mALOAI = maloai;
            this.tENMH = ten;
            this.dVT = dvt;
            this.gIA = gia;
            this.aNHMH = anh;
        }
        public SanPham(DataRow Row)
        {
            this.mAMH = Row["MAMH"] != DBNull.Value ? Row["MAMH"].ToString() : string.Empty;
            this.mALOAI = Row["MALOAI"] != DBNull.Value ? Row["MALOAI"].ToString() : string.Empty;
            this.tENMH = Row["TENMH"] != DBNull.Value ? Row["TENMH"].ToString() : string.Empty;
            this.dVT = Row["DVT"] != DBNull.Value ? Row["DVT"].ToString() : string.Empty;
            this.gIA = Row["GIA"] != DBNull.Value ? (int)Row["GIA"] : 0;
            this.aNHMH = Row["ANHMH"] != DBNull.Value ? Row["ANHMH"].ToString() : string.Empty;
        }
        

        public string MAMH { get => mAMH; set => mAMH = value; }
        public string MALOAI { get => mALOAI; set => mALOAI = value; }
        public string TENMH { get => tENMH; set => tENMH = value; }
        public string DVT { get => dVT; set => dVT = value; }
        public int GIA { get => gIA; set => gIA = value; }
        public string ANHMH { get => aNHMH; set => aNHMH = value; }
    }
}
