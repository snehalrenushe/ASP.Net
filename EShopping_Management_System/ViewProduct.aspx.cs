using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ViewProduct : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind_Product_Repeater();
        }
    }

    private void Bind_Product_Repeater()
    {
        using (SqlConnection Con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("procBindAllProducts", Con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrProducts.DataSource = dt;
                    rptrProducts.DataBind();
                }
            }
        }
    }
}