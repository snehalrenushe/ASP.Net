using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddSize : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Brand();
            Bind_Main_Category();
            Bind_Gender();
            Bind_repeater_Size();
        }
    }

    private void Bind_Brand()
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            Con.Open();
            SqlCommand Cmd = new SqlCommand("Select * from Brand_Details", Con);
            SqlDataAdapter SDA = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlBrand.DataSource = dt;
                ddlBrand.DataTextField = "Brand_Name";
                ddlBrand.DataValueField = "Brand_ID";
                ddlBrand.DataBind();
                ddlBrand.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            Con.Close();
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
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "Category_Name";
                ddlCategory.DataValueField = "Category_ID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));
            }
            Con.Close();
        }
    }

    private void Bind_Gender()
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            Con.Open();
            SqlCommand Cmd = new SqlCommand("Select * from Gender_Details with(nolock)", Con);
            SqlDataAdapter SDA = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlGender.DataSource = dt;
                ddlGender.DataTextField = "Gender_Name";
                ddlGender.DataValueField = "Gender_ID";
                ddlGender.DataBind();
                ddlGender.Items.Insert(0, new ListItem("-Select-", "0"));

            }
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);

        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            Con.Open();
            SqlCommand Cmd = new SqlCommand("Select * from Subcategory_Details where Main_Category_ID = '" + ddlCategory.SelectedItem.Value + "'", Con);

            SqlDataAdapter SDA = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlSubCategory.DataSource = dt;
                ddlSubCategory.DataTextField = "Subcategory_Name";
                ddlSubCategory.DataValueField = "Subcategory_ID";
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));
            }
           
        }
    }

    protected void btn_Add_Size_Click(object sender, EventArgs e)
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            Con.Open();
            SqlCommand Cmd = new SqlCommand("Insert into Size_Details(Size_Name,Brand_ID,Category_ID,SubCategory_ID,Gender_ID) Values('" + tb_Size.Text + "','" + ddlBrand.SelectedItem.Value + "','" + ddlCategory.SelectedItem.Value + "','" + ddlSubCategory.SelectedItem.Value + "','" + ddlGender.SelectedItem.Value + "')", Con);
            Cmd.ExecuteNonQuery();

            Response.Write("<script> alert('Size Added Successfully ');  </script>");
            tb_Size.Text = string.Empty;

            Con.Close();
            ddlBrand.ClearSelection();
            ddlBrand.Items.FindByValue("0").Selected = true;

            ddlCategory.ClearSelection();
            ddlCategory.Items.FindByValue("0").Selected = true;


            ddlSubCategory.ClearSelection();
            ddlSubCategory.Items.FindByValue("0").Selected = true;

            ddlGender.ClearSelection();
            ddlGender.Items.FindByValue("0").Selected = true;

        }
    }

    private void Bind_repeater_Size()
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            using (SqlCommand Cmd = new SqlCommand("select A.*,B.*,C.*,D.*,E.* from Size_Details A inner join Category_Details B on B.Category_ID = a.Category_ID  inner join Brand_Details C on C.Brand_ID = A.Brand_ID inner join Subcategory_Details D on D.Subcategory_ID = A.Subcategory_ID inner join Gender_Details E on E.Gender_ID =A.Gender_ID ", Con))
            {
                using (SqlDataAdapter SDA = new SqlDataAdapter(Cmd))
                {
                    DataTable dt = new DataTable();
                    SDA.Fill(dt);
                    rptrSize.DataSource = dt;
                    rptrSize.DataBind();
                }
            }
        }
    }
}