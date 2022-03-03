using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Payment : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USERNAME"] != null)
        {
            if (!IsPostBack)
            {
                BindPriceData();
            }
        }
        else
        {
            Response.Redirect("~/SignIn.aspx");
        }
    }

    private void BindPriceData()
    {
        if (Request.Cookies["CartPID"] != null)
        {
            string CookieData = Request.Cookies["CartPID"].Value.Split('=')[1];
            string[] CookieDataArray = CookieData.Split(',');

            if (CookieDataArray.Length > 0)
            {
                //h4Noitems.InnerText = "My Cart(" + CookieDataArray.Length + " items)";
                DataTable dt = new DataTable();
                Int64 CartTotal = 0;
                Int64 Total = 0;
                for (int i = 0; i < CookieDataArray.Length; i++)
                {
                    string PID = CookieDataArray[i].ToString().Split('-')[0];
                    string SizeID = CookieDataArray[i].ToString().Split('-')[1];

                    using (SqlConnection Con = new SqlConnection(CS))
                    {
                        using (SqlCommand cmd = new SqlCommand("select A.*,dbo.getSizeName(" + SizeID + ") as SizeNamee,"
                                       + SizeID + " as SizeIDD,SizeData.Img_Name,SizeData.Extenstion from Product_Details A cross apply( select top 1 B.Img_Name,Extenstion from Product_Images B where B.Product_ID=A.Product_ID ) SizeData where A.Product_ID="
                                       + PID + "", Con))
                        {
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                sda.Fill(dt);
                            }
                        }
                    }

                    CartTotal += Convert.ToInt64(dt.Rows[i]["Purchase_Price"]);
                    Total += Convert.ToInt64(dt.Rows[i]["Selling_Price"]);
                }


                divPriceDetails.Visible = true;

                spanCartTotal.InnerText = CartTotal.ToString();
                spanTotal.InnerText = "Rs. " + Total.ToString();
                spanDiscount.InnerText = "- " + (CartTotal - Total).ToString();

                hdCartAmount.Value = CartTotal.ToString();
                hdCartDiscount.Value = (CartTotal - Total).ToString();
                hdTotalPayed.Value = Total.ToString();
            }
            else
            {
                Response.Redirect("~/Products.aspx");
            }
        }
        else
        {
            Response.Redirect("~/Products.aspx");
        }
    }

    protected void btnPaytm_Click(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            string USERID = Session["USERID"].ToString();
            string PaymentType = "Paytm";
            string PaymentStatus = "NotPaid";
            string EMAILID = Session["USEREMAIL"].ToString();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("insert into Purchase_Details values('" + USERID + "','" + hdPidSizeID.Value + "','" + hdCartAmount.Value + "','" + hdCartDiscount.Value + "','" + hdTotalPayed.Value + "','" + PaymentType + "','" + PaymentStatus + "',getdate(),'" + txtName.Text + "','" + txtAddress.Text + "','" + txtPinCode.Text + "','" + txtMobileNumber.Text + "') select SCOPE_IDENTITY()", con);
                con.Open();
                Int64 PurchaseID = Convert.ToInt64(cmd.ExecuteScalar());

                Response.Write("<script>alert('Payment has Done Successfully!!! ');</script>");
            }
        }
        else
        {
            Response.Redirect("~/SignIn.aspx");
        }
    }
}