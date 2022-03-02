using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindCartNumber();

        if (Session["Username"] != null)
        {
            //lbl_Success.Text = "Login Successfull, Welcome <b>" + Session["Username"].ToString() + "</b>";
            btn_Logout.Visible = true;
            btn_Login.Visible = false;
        }
        else
        {
            btn_Logout.Visible = false;
            btn_Login.Visible = true;
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void btn_Logout_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
        Session["Username"] = null;
    }

    public void BindCartNumber()
    {
        if (Request.Cookies["CartPID"] != null)
        {
            string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
            string[] ProductArray = CookiePID.Split(',');
            int ProductCount = ProductArray.Length;
            pCount.InnerText = ProductCount.ToString();
        }
        else
        {
            pCount.InnerText = 0.ToString();
        }
    }

    protected void btn_Login_Click(object sender, EventArgs e)
    {

    }
}
