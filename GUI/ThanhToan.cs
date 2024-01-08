using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ThanhToan : Form
    {
        public SanPham sp;
        public User people;
        UserBLL usbll = new UserBLL(); 
        public ThanhToan(SanPham sp, User people)
        {
            InitializeComponent();
            this.sp = sp;
            this.people = people;
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            label1.Text = label1.Text +" "+ sp.TENMH.ToString();
            label2.Text = label2.Text +" "+sp.GIA.ToString();
            Image anh = Image.FromFile(sp.ANHMH);
            pictureBox1.Image = anh;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            if (!int.TryParse(textBox1.Text, out _))
            {
                i = 1;
                textBox1.Text = i.ToString();
            }
            else
            {
                i = int.Parse(textBox1.Text)+1;
                textBox1.Text = i.ToString();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            if (!int.TryParse(textBox1.Text, out _))
            {
                i = 1;
                textBox1.Text = i.ToString();
            }
            else
            {
                i = int.Parse(textBox1.Text) - 1;
                textBox1.Text = i.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(people.quyen == "khach")
            {
                usbll.TaoHoaDon(people.user,0,int.Parse(textBox1.Text),sp.MAMH);
                MessageBox.Show("Mua Thành Công");
                this.Close();
            }else if(people.quyen == "nv")
            {
                TTKhach ttk = new TTKhach(people.user,int.Parse(textBox1.Text),sp.MAMH);
                ttk.Show();
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
