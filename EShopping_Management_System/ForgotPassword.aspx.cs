using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Reset_Pass_Click(object sender, EventArgs e)
    {
        using (SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["EShoppingDB"].ConnectionString))
        {
            Con.Open();

            SqlCommand cmd = new SqlCommand("Select * from Signup where Email=@Email", Con);

            cmd.Parameters.AddWithValue("@Email", tb_Email_ID.Text);    

            SqlDataAdapter SDA = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            SDA.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                String myGUID = Guid.NewGuid().ToString();
                int Uid = Convert.ToInt32(dt.Rows[0][0]);

                SqlCommand cmd1 = new SqlCommand("Insert into ForgotPass(Id,Uid,RequestDateTime) values('" + myGUID + "','" + Uid + "',GETDATE())", Con);
                cmd1.ExecuteNonQuery();

                String ToEmailAddress = dt.Rows[0][4].ToString();
                String Username = dt.Rows[0][1].ToString();
                String EmailBody = "Hi ," + Username + ",<br/><br/>Click the link below to reset your password<br/> <br/> http://localhost:2562/EShopping_Management_System/RecoverPassword.aspx?id="+myGUID;


                MailMessage PassRecMail = new MailMessage("snehalrenushe123@gmail.com", ToEmailAddress);

                PassRecMail.Body = EmailBody;
                PassRecMail.IsBodyHtml = true;
                PassRecMail.Subject = "Reset Password";

                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("snehalrenushe123@gmail.com", "Nanu@123");
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    client.Send(PassRecMail);
                }

                lblResetPassMsg.Text = "Reset Link send ! Check Your email for Reset password";
                lblResetPassMsg.ForeColor = System.Drawing.Color.Green;
                tb_Email_ID.Text = string.Empty;
            }
            else
            {
                lblResetPassMsg.Text = "OOps! This Email Does not Exist...Try agian ";
                lblResetPassMsg.ForeColor = System.Drawing.Color.Red;
                tb_Email_ID.Text = string.Empty;
                tb_Email_ID.Focus();

            }

        }
    }
}