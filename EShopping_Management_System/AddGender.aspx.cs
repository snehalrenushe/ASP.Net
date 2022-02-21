using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddGender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Bind_Gender_Reapter();
    }

    private void Bind_Gender_Reapter()
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            using (SqlCommand Cmd = new SqlCommand("select * from Gender_Details", Con))
            {
                using (SqlDataAdapter SDA = new SqlDataAdapter(Cmd))
                {
                    DataTable dt = new DataTable();
                    SDA.Fill(dt);
                    rptrGender.DataSource = dt;
                    rptrGender.DataBind();
                }
            }
        }
    }

    protected void btn_Add_Gender_Click(object sender, EventArgs e)
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            Con.Open();

            SqlCommand Cmd = new SqlCommand("Insert into Gender_Details(Gender_Name) Values('" + tb_Gender.Text + "')", Con);

            Cmd.ExecuteNonQuery();

            Response.Write("<script> alert ('Gender Added Successfully!!! '); </script>");
            tb_Gender.Text = "";

            tb_Gender.Focus();
            Con.Close();
        }
    }
}