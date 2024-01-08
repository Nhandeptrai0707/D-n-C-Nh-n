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
    public partial class Khach : Form
    {
        SanPhamBLL spbll = new SanPhamBLL();
        UserBLL usbll = new UserBLL();
        public User People;
        public Khach(User people)
        {
            InitializeComponent();
            this.People = people;
        }
        private void TimSanPham(string ten)
        {
            if(ten == "")
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm");
            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
                List<SanPham> listSanPham = new List<SanPham>();
                listSanPham = spbll.TimSanPhamTheoTen(ten);
                if (listSanPham == null)
                {
                    Label label = new Label();
                    label.Text = "Không có sản phẩm nào tên " + ten;
                }
                else
                {
                    foreach(SanPham sp in listSanPham)
                    {
                        Button bt = new Button();
                        bt.Width = 120;
                        bt.Height = 120;
                        bt.Text = sp.TENMH.ToString() + Environment.NewLine + sp.GIA.ToString();
                        Image anh = Image.FromFile(sp.ANHMH.ToString());
                        Size size = new Size(70, 70);
                        anh = new Bitmap(anh, size);
                        bt.Image = anh;
                        bt.BackColor = Color.White;
                        bt.ImageAlign = ContentAlignment.TopCenter;
                        bt.TextAlign = ContentAlignment.BottomCenter;
                        bt.Tag = sp;
                        bt.Click += Button_Click;
                        flowLayoutPanel1.Controls.Add(bt);
                    }
                }
            }
            
        }
        private void Button_Click(object sender, EventArgs e)
        {

            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
              
                SanPham sp = clickedButton.Tag as SanPham;
                if (sp != null)
                {
                    ThanhToan tt = new ThanhToan(sp,People);
                    tt.Show();
                }
                else {
                    MessageBox.Show("null");
                }
            }
        }
        private void loadItem(string s)
        {
            if (s == "")
            {
                flowLayoutPanel1.Controls.Clear();
                List<SanPham> sp = new List<SanPham>();
                sp = spbll.listSanPham();
                foreach (SanPham sp1 in sp)
                {
                    Button bt = new Button();
                    bt.Width = 120;
                    bt.Height = 120;
                    bt.Text = sp1.TENMH.ToString() + Environment.NewLine + sp1.GIA.ToString();
                    Image anh = Image.FromFile(sp1.ANHMH.ToString());
                    Size size = new Size(70, 70);
                    anh = new Bitmap(anh, size);
                    bt.Image = anh;
                    bt.BackColor = Color.White;
                    bt.ImageAlign = ContentAlignment.TopCenter;
                    bt.TextAlign = ContentAlignment.BottomCenter;
                    bt.Tag = sp1;
                    bt.Click += Button_Click;
                    flowLayoutPanel1.Controls.Add(bt);


                }
            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
                List<SanPham> sp = new List<SanPham>();
                sp = spbll.TimSanPham(s);
                foreach (SanPham sp1 in sp)
                {
                    Button bt = new Button();
                    bt.Width = 120;
                    bt.Height = 120;
                    bt.Text = sp1.TENMH.ToString() + Environment.NewLine + sp1.GIA.ToString();
                    Image anh = Image.FromFile(sp1.ANHMH.ToString());
                    Size size = new Size(70, 70);
                    anh = new Bitmap(anh, size);
                    bt.Image = anh;
                    bt.BackColor = Color.White;
                    bt.ImageAlign = ContentAlignment.TopCenter;
                    bt.TextAlign = ContentAlignment.BottomCenter;
                    bt.Tag = sp1;
                    bt.Click += Button_Click;
                    flowLayoutPanel1.Controls.Add(bt);
                }
            }
            
        }
        private void Khach_Load(object sender, EventArgs e)
        {
            string s = "";
            loadItem(s);
           
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string s = "";
            loadItem(s);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            string maloai = "DT";
            loadItem(maloai);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string maloai = "IP";
            loadItem(maloai);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string maloai = "LK";
            loadItem(maloai);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            string maloai = "LT";
            loadItem(maloai);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimSanPham(textBox1.Text);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                // Lấy giá trị của mục đã chọn
                string selectedValue = comboBox1.SelectedItem.ToString();
                if (selectedValue == "Giá Tăng Dần")
                {
                    flowLayoutPanel1.Controls.Clear();
                    List<SanPham> sp = new List<SanPham>();
                    sp = spbll.SanPhamTangDan();
                    foreach (SanPham sp1 in sp)
                    {
                        Button bt = new Button();
                        bt.Width = 120;
                        bt.Height = 120;
                        bt.Text = sp1.TENMH.ToString() + Environment.NewLine + sp1.GIA.ToString();
                        Image anh = Image.FromFile(sp1.ANHMH.ToString());
                        Size size = new Size(70, 70);
                        anh = new Bitmap(anh, size);
                        bt.Image = anh;
                        bt.BackColor = Color.White;
                        bt.ImageAlign = ContentAlignment.TopCenter;
                        bt.TextAlign = ContentAlignment.BottomCenter;
                        bt.Tag = sp1;
                        bt.Click += Button_Click;
                        flowLayoutPanel1.Controls.Add(bt);


                    }
                }
                else if(selectedValue == "Giá Giảm Dần")
                {
                    flowLayoutPanel1.Controls.Clear();
                    List<SanPham> sp = new List<SanPham>();
                    sp = spbll.SanPhamGiamDan();
                    foreach (SanPham sp1 in sp)
                    {
                        Button bt = new Button();
                        bt.Width = 120;
                        bt.Height = 120;
                        bt.Text = sp1.TENMH.ToString() + Environment.NewLine + sp1.GIA.ToString();
                        Image anh = Image.FromFile(sp1.ANHMH.ToString());
                        Size size = new Size(70, 70);
                        anh = new Bitmap(anh, size);
                        bt.Image = anh;
                        bt.BackColor = Color.White;
                        bt.ImageAlign = ContentAlignment.TopCenter;
                        bt.TextAlign = ContentAlignment.BottomCenter;
                        bt.Tag = sp1;
                        bt.Click += Button_Click;
                        flowLayoutPanel1.Controls.Add(bt);


                    }
                }
            }
        }
    }
}
