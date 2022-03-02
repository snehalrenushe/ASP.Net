using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Product : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Product_ID"] != null)
        {
            if (!IsPostBack)
            {
                Bind_Product_Image();
                Bind_Product_Details();
            }
        }
        else
        {
            Response.Redirect("~/Product.aspx");
        }
    }

    private void Bind_Product_Image()
    {
        Int64 PID = Convert.ToInt64(Request.QueryString["Product_ID"]);

        using (SqlConnection Con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Product_Images where Product_ID='" + PID + "'", Con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrImage.DataSource = dt;
                    rptrImage.DataBind();
                }
            }
        }
    }

    protected string GetActiveImgClass(int ItemIndex)
    {
        if (ItemIndex == 0)
        {
            return "active";
        }
        else
        {
            return "";

        }
    }

    private void Bind_Product_Details()
    {
        Int64 PID = Convert.ToInt64(Request.QueryString["Product_ID"]);
        using (SqlConnection Con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select * from Product_Details where Product_ID='" + PID + "'", Con))
            {
                 cmd.CommandType = CommandType.Text;
                 using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                 {
                     DataTable dt = new DataTable();
                     sda.Fill(dt);
                     rptrProductDetails.DataSource = dt;
                     rptrProductDetails.DataBind();
                 }
            }
       }
    }

    protected void rptrProductDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string BrandID = (e.Item.FindControl("hfBrandID") as HiddenField).Value;
            string CatID = (e.Item.FindControl("hfCatID") as HiddenField).Value;
            string SubCatID = (e.Item.FindControl("hfSubCatID") as HiddenField).Value;
            string GenderID = (e.Item.FindControl("hfGenderID") as HiddenField).Value;

            RadioButtonList rblSize = e.Item.FindControl("rblSize") as RadioButtonList;

            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Size_Details where Brand_ID='" + BrandID + "' and Category_ID=" + CatID + " and Subcategory_ID=" + SubCatID + " and Gender_ID=" + GenderID + "", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rblSize.DataSource = dt;
                        rblSize.DataTextField = "Size_Name";
                        rblSize.DataValueField = "Size_ID";
                        rblSize.DataBind();
                    }
                }
            }
        }
    }

    protected void btnAddtoCart_Click(object sender, EventArgs e)
    {
        string SelectedSize = string.Empty;
        foreach (RepeaterItem item in rptrProductDetails.Items)
        {
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                var rbList = item.FindControl("rblSize") as RadioButtonList;
                SelectedSize = rbList.SelectedValue;
                var lblError = item.FindControl("lblError") as Label;
                lblError.Text = "";
            }
        }

        if (SelectedSize != "")
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["Product_ID"]);
            if (Request.Cookies["CartPID"] != null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                CookiePID = CookiePID + "," + PID + "-" + SelectedSize;
                HttpCookie CartProducts = new HttpCookie("CartPID");
                CartProducts.Values["CartPID"] = CookiePID;
                CartProducts.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProducts);
            }
            else
            {
                HttpCookie CartProducts = new HttpCookie("CartPID");
                CartProducts.Values["CartPID"] = PID.ToString() + "-" + SelectedSize;
                CartProducts.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProducts);
            }
            Response.Redirect("~/ViewProduct.aspx?Product_ID=" + PID);
        }
        else
        {
            foreach (RepeaterItem item in rptrProductDetails.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var lblError = item.FindControl("lblError") as Label;
                    lblError.Text = "Please select a size";
                }
            }

        }



    }
}
