using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class TTKhach : Form
    {
        public string manv;
        public int sl;
        public string mamh;
        UserBLL usbll = new UserBLL();
        public TTKhach(string manv,int sl,string mamh)
        {
            InitializeComponent();
            this.manv = manv;
            this.sl = sl;
            this.mamh = mamh;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == ""||textBox2.Text==""||textBox4.Text ==""||textBox3.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else {
                KhachHang kh = new KhachHang();
                kh = usbll.TimKhachHang(textBox1.Text);
                if (kh.makh != null)
                {
                    string inputString = manv;

                    string pattern = @"\d+";
                    MatchCollection matches = Regex.Matches(inputString, pattern);
                    manv = "";
                    foreach (Match match in matches)
                    {
                        manv = manv + match.Value;
                    }
                    usbll.TaoHoaDon(kh.makh,int.Parse(manv),sl,mamh);
                    MessageBox.Show("Mua Thành Công");
                    this.Close();
                }
                else
                {
                    string inputString = manv;

                    string pattern = @"\d+";
                    MatchCollection matches = Regex.Matches(inputString, pattern);
                    manv = "";
                    foreach (Match match in matches)
                    {
                        manv = manv + match.Value;
                    }
                    usbll.TaoKhachHang(textBox1.Text, textBox4.Text, textBox3.Text, textBox2.Text);
                    usbll.TaoHoaDon(textBox1.Text, int.Parse(manv), sl, mamh);
                    MessageBox.Show("Mua Thành Công");
                    this.Close();
                }
            }
        }
    }
}
