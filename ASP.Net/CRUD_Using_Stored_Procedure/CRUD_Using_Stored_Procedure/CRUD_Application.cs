using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD_Using_Stored_Procedure
{
    public partial class CRUD_Application : Form
    {
        public CRUD_Application()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DB_CRUD_Using_Stored_Procedure;Integrated Security=True");

        void Con_Open()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();   
            }
        }

        void Con_Close()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        void Clear_Controls()
        {
            tb_Student_ID.Clear();
            tb_Name.Clear();
            tb_Address.Clear();
            tb_Mobile_No.Clear();
            rb_Female.Checked = false;
            rb_Male.Checked = false;
        }

        private void CRUD_Application_Load(object sender, EventArgs e)
        {
            View_Student_Details();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string gen = " ";

            if (tb_Student_ID.Text != "" && tb_Name.Text != "" && tb_Address.Text != "" && tb_Mobile_No.Text != "")
            {
                Con_Open();

                if (rb_Female.Checked)
                {
                    gen = rb_Female.Text;
                }
                else
                {
                    gen = rb_Male.Text;
                }

                SqlCommand Cmd = new SqlCommand("Insert_Student",Con);

                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.Add("@ID",SqlDbType.Int).Value = tb_Student_ID.Text;
                Cmd.Parameters.Add("@Name",SqlDbType.NVarChar).Value = tb_Name.Text;
                Cmd.Parameters.Add("@DOB",SqlDbType.NVarChar).Value = dtp_Date_Of_Birth.Text;
                Cmd.Parameters.Add("@Add",SqlDbType.NVarChar).Value = tb_Address.Text;
                Cmd.Parameters.Add("@Gen",SqlDbType.NVarChar).Value = gen;
                Cmd.Parameters.Add("@Mob",SqlDbType.Decimal).Value = tb_Mobile_No.Text;

                Cmd.Connection = Con;

                Cmd.ExecuteNonQuery();

                MessageBox.Show("Student Details Saved Successfully !!!", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);

                View_Student_Details();
                
                Clear_Controls();

                Con_Close();
            }
            else
            {
                MessageBox.Show("Insert Valid Details !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        void View_Student_Details()
        {
            SqlCommand Cmd = new SqlCommand("View_Student",Con);

            SqlDataAdapter SDA = new SqlDataAdapter(Cmd);

            DataTable dt = new DataTable();

            SDA.Fill(dt);

            dgv_Crud_Application.DataSource = dt;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear_Controls();
            View_Student_Details();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string gen = " ";

            if (tb_Student_ID.Text != "" && tb_Name.Text != "" && tb_Address.Text != "" && tb_Mobile_No.Text != "")
            {
                Con_Open();

                if (rb_Female.Checked)
                {
                    gen = rb_Female.Text;
                }
                else
                {
                    gen = rb_Male.Text;
                }

                SqlCommand Cmd = new SqlCommand("Update_Student", Con);

                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = tb_Student_ID.Text;
                Cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = tb_Name.Text;
                Cmd.Parameters.Add("@DOB", SqlDbType.NVarChar).Value = dtp_Date_Of_Birth.Text;
                Cmd.Parameters.Add("@Add", SqlDbType.NVarChar).Value = tb_Address.Text;
                Cmd.Parameters.Add("@Gen", SqlDbType.NVarChar).Value = gen;
                Cmd.Parameters.Add("@Mob", SqlDbType.Decimal).Value = tb_Mobile_No.Text;

                Cmd.Connection = Con;

                Cmd.ExecuteNonQuery();

                MessageBox.Show("Student Record Updated Successfully !!!", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);

                View_Student_Details();

                Clear_Controls();

                Con_Close();
            }
            else
            {
                MessageBox.Show("Insert Valid Details !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
        
            Con_Open();

            SqlCommand Cmd = new SqlCommand("Delete_Student", Con);

            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = tb_Student_ID.Text;

            Cmd.Connection = Con;

            Cmd.ExecuteNonQuery();
          
            if (MessageBox.Show("Are you Sure you want to delete this record ??","Deleting",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
	        {
		        MessageBox.Show("Student Record Deleted Successfully !!!", "Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);

                View_Student_Details();

                Clear_Controls();

                Con_Close();
	        }
            else
            {
                MessageBox.Show("Insert Valid Details !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SqlCommand Cmd = new SqlCommand("Search_Student", Con);

            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@ID", SqlDbType.Int).Value = tb_Student_ID.Text;

            Cmd.Connection = Con;

            SqlDataAdapter SDA = new SqlDataAdapter(Cmd);

            DataTable dt = new DataTable();

            SDA.Fill(dt);

            dgv_Crud_Application.DataSource = dt;

            Clear_Controls();
        }
    }
}
