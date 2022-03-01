using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddSubCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Main_Category();
            Bind_Subcategory_Repeatr();
        }
    }

    private void Bind_Main_Category()
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            Con.Open();
            SqlCommand Cmd = new SqlCommand("Select * from Category_Details", Con);

            SqlDataAdapter SDA = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddl_Main_Category_ID.DataSource = dt;
                ddl_Main_Category_ID.DataTextField = "Category_Name";
                ddl_Main_Category_ID.DataValueField = "Category_ID";
                ddl_Main_Category_ID.DataBind();
                ddl_Main_Category_ID.Items.Insert(0, new ListItem("-Select-", "0"));

            }
         }
    }

    private void Bind_Subcategory_Repeatr()
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            using (SqlCommand Cmd = new SqlCommand("select A.*,B.* from Subcategory_Details A inner join Category_Details B on B.Category_ID = A.Main_Category_ID ", Con))
            {
                using (SqlDataAdapter SDA = new SqlDataAdapter(Cmd))
                {
                    DataTable dt = new DataTable();
                    SDA.Fill(dt);
                    rptrSubCat.DataSource = dt;
                    rptrSubCat.DataBind();
                }
            }
        }
    }

    protected void btn_Add_SubCategory_Click(object sender, EventArgs e)
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            Con.Open();

            SqlCommand cmd = new SqlCommand("Insert into Subcategory_Details(Subcategory_Name,Main_Category_ID) Values('" + tb_SubCategory.Text + "','" + ddl_Main_Category_ID.SelectedItem.Value + "')", Con);

            cmd.ExecuteNonQuery();

            Response.Write("<script>alert('Subcategory Added Successfully!!! ');</script>");
            tb_SubCategory.Text = "";

            ddl_Main_Category_ID.ClearSelection();
            ddl_Main_Category_ID.Items.FindByValue("0").Selected = true;

            Con.Close();
        }

        Bind_Subcategory_Repeatr();
    }
}