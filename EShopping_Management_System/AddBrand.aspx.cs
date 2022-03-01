using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddBrand : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Brand_Repeater();
        }
    }

    protected void btnAddBrand_Click(object sender, EventArgs e)
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            Con.Open();

            SqlCommand cmd = new SqlCommand("Insert into Brand_Details(Brand_Name) Values('" + tb_Brand.Text + "')", Con);

            cmd.ExecuteNonQuery();

            Response.Write("<script>alert('Brand Added Successfully!!! ');</script>");
            tb_Brand.Text = "";

            //lbl_Warning.Text = "Please Fill the all the Field";
            //lbl_Warning.ForeColor = System.Drawing.Color.Red;

            tb_Brand.Focus();

            Con.Close();
        }
    }

    private void Bind_Brand_Repeater()
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            using (SqlCommand Cmd = new SqlCommand("select * from Brand_Details", Con))
            {
                using (SqlDataAdapter SDA = new SqlDataAdapter(Cmd))
                {
                    DataTable dt = new DataTable();
                    SDA.Fill(dt);
                    rptrBrands.DataSource = dt;
                    rptrBrands.DataBind();
                }
            }
        }
    }
}