using Salot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website.API;

namespace Website
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            UserApiCalls userApiCalls = new API.UserApiCalls();
            User returnUser = null;
            try
            {
                returnUser =  await userApiCalls.RegisterUser(EmailTextBox.Text, PasswordTextbox.Text);
                Response.Redirect("login.aspx");
            }
            catch (ArgumentException ex)
            {
                RegisterFailedError.Text = ex.Message;
            }
        }
    }
}