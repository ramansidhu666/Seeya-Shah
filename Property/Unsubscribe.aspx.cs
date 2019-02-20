using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Property_cls;
using System.Data.SqlClient;
using System.Configuration;

namespace Property
{
    public partial class Unsubscribe : System.Web.UI.Page
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());

                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql = null;

                // sql = "insert into errorlog ([DBname],[message],[EmailId]) values('" + dbname + "','" + ex.Message.ToString() + "in send mail function." + "','" + Email + "')";
                try
                {
                    conn.Open();
                    adapter.InsertCommand = new SqlCommand(sql, conn);
                    adapter.InsertCommand.ExecuteNonQuery();

                }
                catch (Exception ex1)
                {
                    conn.Close();
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Congrts!", "alert('Your E-mail has been unsubscribed sucessfully - Thank You');", true);
                return;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Failure", "alert('You failed to unsubscribe, please try again.');", true);
                return;
                //If the message failed at some point, let the user know
                //lblResult.Text = "Your message failed to send, please try again.";
            }
        }
    }
}