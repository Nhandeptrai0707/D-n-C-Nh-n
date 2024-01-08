using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
namespace GUI
{
    public partial class DangNhap : Form
    {
        User user = new User();
        UserBLL userBLL = new UserBLL();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            user.user = textBox1.Text;
            user.password = textBox2.Text;
            string getuser = userBLL.CheckLogin(user);
            user.quyen = getuser;
            switch (getuser)
            {
                case "tài khoản trống":
                    MessageBox.Show("tài khoản không được để trống");
                    return;
                case "mật khẩu trống":
                    MessageBox.Show("Mật khẩu không được để trống");
                    return;
                case "Tài khoản hoặc mật khẩu không chính xác":
                    MessageBox.Show("tài khoản mật khẩu sai");
                    return;
                case "khach":
                    Khach khach = new Khach(user);
                    khach.Show();
                    Visible = false;
                    return;
                case "admin":
                    Admin admin = new Admin();
                    admin.Show();
                    Visible = false;
                    return;
                case "nv":

                    Khach khach1 = new Khach(user);
                    khach1.Show();
                    Visible = false;
                    return;
                
                default:
                    MessageBox.Show(getuser.ToString());
                    return;
                    
            }
        }

            private void DangNhap_Load(object sender, EventArgs e)
            {

            }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát","Thông Báo",MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
