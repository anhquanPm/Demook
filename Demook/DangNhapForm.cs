using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demook
{
    public partial class DangNhapForm : DevExpress.XtraEditors.XtraForm
    {
        string ConnectionString = @"Data Source=.;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        public DangNhapForm()
        {
            InitializeComponent();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DangNhapForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string userName = tb_username.Text.Trim();
            string pass = tb_pass.Text.Trim();

            using(SqlConnection conn = new SqlConnection(ConnectionString)) {
                conn.Open();
                string query = "SELECT COUNT(*) FROM TaiKhoan WHERE sUsername = @Username AND sPassword = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", userName);
                    cmd.Parameters.AddWithValue("@Password", pass);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        Form form = new  MenuForm();
                        Hide();
                        form.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                    }
                }
                    conn.Close();
            }
        }
    }
}