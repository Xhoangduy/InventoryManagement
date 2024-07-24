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
    public partial class ProductModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yasus\OneDrive\Documents\dblMS.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public ProductModuleForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory()
        {
            comboCat.Items.Clear();
            cm= new SqlCommand("SELECT catname FROM tbCategory", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                comboCat.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn lưu sản phẩm này?", "Sản phẩm đang được lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tbProduct(pname, pqty, pprice, pdescription, pcategory )VALUES(@pname,@pqty,@pprice,@pdescription,@pcategory)", con);
                    cm.Parameters.AddWithValue("@pname", txtPname.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(txtPqty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt32(txtPprice.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtPdes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboCat.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Sản phẩm đã được lưu thành công");
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        public void Clear()
        {
            txtPname.Clear();
            txtPprice.Clear();
            txtPqty.Clear();
            txtPdes.Clear();
            comboCat.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn cập nhật sản phẩm này?", "Sản phẩm đang được cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("UPDATE tbProduct SET pname=@pname, pqty=@pqty, pprice=@pprice, pdescription=@pdescription, pcategory=@pcategory WHERE pid LIKE @pid", con);
                    cm.Parameters.AddWithValue("@pid", lblPid.Text);
                    cm.Parameters.AddWithValue("@pname", txtPname.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(txtPqty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt32(txtPprice.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtPdes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboCat.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Sản phẩm đã được cập nhật thành công");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblPid_Click(object sender, EventArgs e)
        {

        }

        private void ProductModuleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
