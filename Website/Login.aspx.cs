using Salot.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website.API;

namespace Website
{
    public partial class WebFormTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void LoginButtonClick(object sender, EventArgs e)
        {
            UserApiCalls userApiCalls = new API.UserApiCalls();
            User returnUser = new Salot.Data.User();
            returnUser.Email= EmailTextBox.Text;
            returnUser.Password = PasswordTextbox.Text;
            try
            {
                var returnFrom = await userApiCalls.Login(returnUser);
                returnUser = (User)returnFrom.FirstOrDefault();
            }
            catch (ArgumentException ex)
            {
                RegisterFailedError.Text = ex.Message;
            }

            if (returnUser.ID != null && returnUser.ID != Guid.Empty)
            {
                Response.Redirect("LunchWebsiteController.aspx");
            }
        }
    }
}