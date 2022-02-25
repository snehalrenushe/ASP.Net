using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class AddProduct : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString;

    public void Clear_Controls()
    {
        ddlBrand.ClearSelection();
        ddl_Category.ClearSelection();
        ddl_Gender.ClearSelection();
        ddl_SubCategory.ClearSelection();
        cbl_Size.ClearSelection();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Brand();
            Bind_Category();
            Bind_Gender();
            ddl_SubCategory.Enabled = false;
            ddl_Gender.Enabled = false;
        }
    }

    private void Bind_Brand()
    {
        using (SqlConnection Con = new SqlConnection(CS))
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

    private void Bind_Category()
    {
        using (SqlConnection Con = new SqlConnection(CS))
        {
            Con.Open();
            SqlCommand Cmd = new SqlCommand("Select * from Category_Details", Con);

            SqlDataAdapter SDA = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddl_Category.DataSource = dt;
                ddl_Category.DataTextField = "Category_Name";
                ddl_Category.DataValueField = "Category_ID";
                ddl_Category.DataBind();
                ddl_Category.Items.Insert(0, new ListItem("-Select-", "0"));
            }

            Con.Close();
        }
    }

    private void Bind_Gender()
    {
        using (SqlConnection Con = new SqlConnection(CS))
        {
            Con.Open();
            SqlCommand Cmd = new SqlCommand("Select * from Gender_Details with(nolock)", Con);
            SqlDataAdapter SDA = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddl_Gender.DataSource = dt;
                ddl_Gender.DataTextField = "Gender_Name";
                ddl_Gender.DataValueField = "Gender_ID";
                ddl_Gender.DataBind();
                ddl_Gender.Items.Insert(0, new ListItem("-Select-", "0"));

            }
        }
    }

    protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_SubCategory.Enabled = true;

        int MainCategoryID = Convert.ToInt32(ddl_Category.SelectedItem.Value);

        using (SqlConnection Con = new SqlConnection(CS))
        {
            Con.Open();
            SqlCommand Cmd = new SqlCommand("Select * from Subcategory_Details where Main_Category_ID = '" + ddl_Category.SelectedItem.Value + "'", Con);

            SqlDataAdapter SDA = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddl_SubCategory.DataSource = dt;
                ddl_SubCategory.DataTextField = "Subcategory_Name";
                ddl_SubCategory.DataValueField = "Subcategory_ID";
                ddl_SubCategory.DataBind();
                ddl_SubCategory.Items.Insert(0, new ListItem("-Select-", "0"));
            }

        }
    }

    protected void ddl_Gender_SelectedIndexChanged1(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Size_Details where Brand_ID='" + ddlBrand.SelectedItem.Value + "' and Category_ID='" + ddl_Category.SelectedItem.Value + "' and Subcategory_ID='" + ddl_SubCategory.SelectedItem.Value + "' and Gender_ID='" + ddl_Gender.SelectedItem.Value + "' ", con);

            //SqlCommand cmd = new SqlCommand("Select * from Size_Details where Brand_ID='" + ddlBrand.SelectedItem.Value + "' and Category_ID='" + ddl_Category.SelectedItem.Value + "' and Subcategory_ID='" + ddl_SubCategory.SelectedItem.Value + "' and Gender_ID='" + ddl_Gender.SelectedItem.Value + "' ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            { 
                cbl_Size.DataSource = dt;
                cbl_Size.DataTextField = "Size_Name";
                cbl_Size.DataValueField = "Size_ID";
                cbl_Size.DataBind();
            }
        }
    }

    protected void btn_Add_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("sp_InsertProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Product_Name", tb_Product_Name.Text);
            cmd.Parameters.AddWithValue("@Purchase_Price", tb_Price.Text);
            cmd.Parameters.AddWithValue("@Selling_Price", tb_sell_Price.Text);
            cmd.Parameters.AddWithValue("@Brand_ID", ddlBrand.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Category_ID", ddl_Category.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Subcategory_ID", ddl_SubCategory.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Gender", ddl_Gender.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@Description", tb_Description.Text);
            cmd.Parameters.AddWithValue("@Product_Details", tb_P_Detail.Text);
            cmd.Parameters.AddWithValue("@Material_Care", tb_Mat_Care.Text);

            if (ch_Free_Delivery.Checked == true)
            {
                cmd.Parameters.AddWithValue("@Free_Delivery", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@Free_Delivery", 0.ToString());
            }

            if (ch_30_Ret.Checked == true)
            {
                cmd.Parameters.AddWithValue("@30_Day_Ret", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@30_Day_Ret", 0.ToString());
            }
          
            if (cb_COD.Checked == true)
            {
                cmd.Parameters.AddWithValue("@COD", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@COD", 0.ToString());
            }

            con.Open();
            Int64 Product_ID = Convert.ToInt64(cmd.ExecuteScalar());


            //Insert size quantity
            for (int i = 0; i < cbl_Size.Items.Count; i++)
            {
                if (cbl_Size.Items[i].Selected == true)
                {
                    Int64 SizeID = Convert.ToInt64(cbl_Size.Items[i].Value);
                    int Quantity = Convert.ToInt32(tb_Quantity.Text);

                    SqlCommand cmd2 = new SqlCommand("insert into Product_Size_Quantity values('" + Product_ID + "','" + SizeID + "','" + Quantity + "')", con);
                    cmd2.ExecuteNonQuery();
                }
            }

            ////Insert and upload images
            //if (fuImg01.HasFile)
            //{
            //    string SavePath = Server.MapPath("~/Imag/Product_Images/") + Product_ID;
            //    if (!Directory.Exists(SavePath))
            //    {
            //        Directory.CreateDirectory(SavePath);

            //    }
            //    string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);

            //    fuImg01.SaveAs(SavePath + "\\" + tb_Product_Name.Text.ToString().Trim() + "01" + Extention);

            //    SqlCommand cmd3 = new SqlCommand("insert into Product_Images values('" + Product_ID + "','" + tb_Product_Name.Text.ToString().Trim() + "01" + "','" + Extention + "')", con);
            //    cmd3.ExecuteNonQuery();
            //}

            //////2nd fileupload
            //if (fuImg01.HasFile)
            //{
            //    string SavePath = Server.MapPath("~/Imag/Product_Images/") + Product_ID;
            //    if (!Directory.Exists(SavePath))
            //    {
            //        Directory.CreateDirectory(SavePath);

            //    }
            //    string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);

            //    fuImg01.SaveAs(SavePath + "\\" + tb_Product_Name.Text.ToString().Trim() + "01" + Extention);

            //    SqlCommand cmd3 = new SqlCommand("insert into Product_Images values('" + Product_ID + "','" + tb_Product_Name.Text.ToString().Trim() + "01" + "','" + Extention + "')", con);
            //    cmd3.ExecuteNonQuery();
            //}

            //////3rd file upload 
            //if (fuImg01.HasFile)
            //{
            //    string SavePath = Server.MapPath("~/Imag/Product_Images/") + Product_ID;
            //    if (!Directory.Exists(SavePath))
            //    {
            //        Directory.CreateDirectory(SavePath);

            //    }
            //    string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);

            //    fuImg01.SaveAs(SavePath + "\\" + tb_Product_Name.Text.ToString().Trim() + "01" + Extention);

            //    SqlCommand cmd3 = new SqlCommand("insert into Product_Images values('" + Product_ID + "','" + tb_Product_Name.Text.ToString().Trim() + "01" + "','" + Extention + "')", con);
            //    cmd3.ExecuteNonQuery();
            //}
            
            //////4th file upload control
            //if (fuImg01.HasFile)
            //{
            //    string SavePath = Server.MapPath("~/Imag/Product_Images/") + Product_ID;
            //    if (!Directory.Exists(SavePath))
            //    {
            //        Directory.CreateDirectory(SavePath);

            //    }
            //    string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);

            //    fuImg01.SaveAs(SavePath + "\\" + tb_Product_Name.Text.ToString().Trim() + "01" + Extention);

            //    SqlCommand cmd3 = new SqlCommand("insert into Product_Images values('" + Product_ID + "','" + tb_Product_Name.Text.ToString().Trim() + "01" + "','" + Extention + "')", con);
            //    cmd3.ExecuteNonQuery();
            //}

            //////5th file upload
            //if (fuImg01.HasFile)
            //{
            //    string SavePath = Server.MapPath("~/Imag/Product_Images/") + Product_ID;
            //    if (!Directory.Exists(SavePath))
            //    {
            //        Directory.CreateDirectory(SavePath);

            //    }
            //    string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);

            //    fuImg01.SaveAs(SavePath + "\\" + tb_Product_Name.Text.ToString().Trim() + "01" + Extention);

            //    SqlCommand cmd3 = new SqlCommand("insert into Product_Images values('" + Product_ID + "','" + tb_Product_Name.Text.ToString().Trim() + "01" + "','" + Extention + "')", con);
            //    cmd3.ExecuteNonQuery();
            //}

        }
    }


    protected void ddl_SubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_SubCategory.SelectedIndex != 0)
        {
            ddl_Gender.Enabled = true;
        }
        else
        {
            ddl_Gender.Enabled = false;
        }
    }
}