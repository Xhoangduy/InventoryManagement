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
    public partial class OrderModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yasus\OneDrive\Documents\dblMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public OrderModuleForm()
        {
            InitializeComponent();
            LoadCustomer();
            LoadProduct();
        }

        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            cm = new SqlCommand("SELECT cid, cname FROM tbCustomer WHERE CONCAT(cname, cphone) LIKE @searchText", con);
            cm.Parameters.AddWithValue("@searchText", "%" + txtSearchCus.Text + "%");
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }


        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pname, pprice, pdescription, pcategory) LIKE @searchText", con);
            cm.Parameters.AddWithValue("@searchText", "%" + txtSearchPro.Text + "%");
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
        private void txtSearchCus_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtSearchPro_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        int qty = 0;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(UDQty.Value)>qty)
            {
                MessageBox.Show("Hàng trong kho không đủ!","Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UDQty.Value = UDQty.Value - 1;
                return;
            }
            int total = Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(UDQty.Value);
            txtTotal.Text = total.ToString();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCid.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCname.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPname.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
            qty = Convert.ToInt32(dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCid.Text == "")
                {
                    MessageBox.Show("Hãy chọn khách hàng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPid.Text == "")
                {
                    MessageBox.Show("Hãy chọn sản phẩm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn thêm đơn hàng này?", "Đơn hàng đang được lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbOrder(odate,pid,cid,qty,price,total)VALUES(@odate,@pid,@cid,@qty,@price,@total)", con);
                    cm.Parameters.AddWithValue("@odate",dtOrder.Value);
                    cm.Parameters.AddWithValue("@pid", Convert.ToInt32(txtPid.Text));
                    cm.Parameters.AddWithValue("@cid", Convert.ToInt32(txtCid.Text));
                    cm.Parameters.AddWithValue("@qty", UDQty.Value);
                    cm.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                    cm.Parameters.AddWithValue("@total", Convert.ToInt32(txtTotal.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Đơn hàng đã được thêm thành công");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            txtCid.Clear();
            txtCname.Clear();

            txtPid.Clear();
            txtPname.Clear();

            txtPrice.Clear();
            UDQty.Value = 1;
            dtOrder.Value = DateTime.Now;
        }

    private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void maskedTextBox6_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnInsert.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }
    }
}
