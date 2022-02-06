using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frm_Login_Form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btn_Submit.Enabled = false;
    }

    protected void tb_Password_TextChanged(object sender, EventArgs e)
    {
        btn_Submit.Enabled = true;
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (tb_Username.Text == "a" && tb_Password.Text == "a")
        {
            
        }
    }
}