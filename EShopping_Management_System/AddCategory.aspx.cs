using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class AddCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Bind_Category_Reapter();
    }

    protected void btn_Add_Category_Click(object sender, EventArgs e)
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            Con.Open();

            SqlCommand cmd = new SqlCommand("Insert into Category_Details(Category_Name) Values('" + tb_Category.Text + "')", Con);

            cmd.ExecuteNonQuery();

            Response.Write("<script>alert('Category Added Successfully!!! ');</script>");
            tb_Category.Text = "";

            //lbl_Warning.Text = "Please Fill the all the Field";
            //lbl_Warning.ForeColor = System.Drawing.Color.Red;

            tb_Category.Focus();

            Con.Close();
        }
    }

    private void Bind_Category_Reapter()
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            using (SqlCommand Cmd = new SqlCommand("select * from Category_Details", Con))
            {
                using (SqlDataAdapter SDA = new SqlDataAdapter(Cmd))
                {
                    DataTable dt = new DataTable();
                    SDA.Fill(dt);
                    rptrCategory.DataSource = dt;
                    rptrCategory.DataBind();
                }
            }
        }
    }
}