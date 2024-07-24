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

namespace HETHONGQUANLYKHO
{
    public partial class ProductForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yasus\OneDrive\Documents\dblMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public ProductForm()
        {
            InitializeComponent();
            LoadProduct();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pname, pprice, pdescription, pcategory) LIKE @searchText", con);
            cm.Parameters.AddWithValue("@searchText", "%" + txtSearch.Text + "%");
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductModuleForm userModule = new ProductModuleForm();
            userModule.btnSave.Enabled = true;
            userModule.btnUpdate.Enabled = false;
            userModule.ShowDialog();
            LoadProduct();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ProductModuleForm productModule = new ProductModuleForm();
                productModule.lblPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule.txtPname.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.txtPqty.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                productModule.txtPprice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.txtPdes.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.comboCat.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();


                productModule.btnSave.Enabled = false;
                productModule.btnUpdate.Enabled = true;
                productModule.ShowDialog();
            }

            else if (colName == "Delete")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này không?", "Đang xóa sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbProduct WHERE pid LIKE '" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Sản phẩm đã được xóa thành công");
                }
            }
            LoadProduct();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct(); 
        }
    }
}
