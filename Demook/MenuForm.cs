using DevExpress.XtraBars;
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
    public partial class MenuForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string Connection = @"Data Source=.;Initial Catalog=QuanLyThuVien;Integrated Security=True";
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btn_dang_nhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form f  = new DangNhapForm();
            f.ShowDialog();

        }

        private void btn_logout_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(Connection))
            {
                conn.Open();
                string query = "SELECT * FROM SACH";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                LoadDanhSach();

                conn.Close();
            }
        }

        private void LoadDanhSach()
        {
            string queryStr = "SELECT * FROM SACH";
            dgv_sach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_sach.DataSource = GetData(queryStr).Tables[0];
        }

        private DataSet GetData(string query)
        {
            DataSet data = new DataSet();

            using (SqlConnection conn = new SqlConnection(Connection))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(data);
                conn.Close();
            }

            return data;
        }
    }
}