using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Website.API;

namespace Website
{
    public partial class LunchWebsiteController : System.Web.UI.Page
    {
        WebsiteApiCalls websiteHelper = new WebsiteApiCalls();
        const string testUserGuid = "6B60C9B2-8053-4FB1-B0EE-BD4BF295321A";
        //TODO: Localstorageen ettei tarvi aina ladata uusiks
        List<Salot.Data.Website> websiteList = new List<Salot.Data.Website>();
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                try
                {
                    websiteList = await websiteHelper.GetWebsitesForUsers(Guid.Parse(testUserGuid));
                }
                catch (Exception ex)
                {
                    ErrorText.Text = ex.Message;
                }

                GridView1.DataSource = websiteList;
                GridView1.AutoGenerateColumns = false;
                GridView1.DataBind();

            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Unsubscribe")
            {
                try
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView1.Rows[rowIndex];
                    string ID = (row.FindControl("ID") as TextBox).Text;
                    if (UnsubscribeFromWebsite(ID))
                        GridView1.DeleteRow(rowIndex);
                }
                catch(Exception ex)
                {
                    ErrorText.Text = string.Format("Deleting website failed: {0}", ex.Message);
                }

            }
        }
        
        protected bool UnsubscribeFromWebsite(string id)
        {
            try
            {
                var website = websiteHelper.Delete(Guid.Parse(id));
                ErrorText.Text = "Deleted";
                return true;
            }
            catch (Exception ex)
            {
                ErrorText.Text = ex.Message;
                return false;
            }
        }
        protected async void AddWebsiteForUser(object sender, EventArgs e)
        {
            try
            {
                var webSites = await websiteHelper.InsertWebsiteForUser(Guid.Parse(testUserGuid), LunchWebsiteTextbox.Text);
                GridView1.DataSource = webSites;
                GridView1.DataBind();
                ErrorText.Text = "Added";
            }
            catch (Exception ex)
            {
                ErrorText.Text = ex.Message;
            }
        }

        protected async void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            websiteList = await websiteHelper.GetWebsitesForUsers(Guid.Parse(testUserGuid));
            websiteList.Remove(websiteList.Where(w => w.ID == Guid.Parse((row.FindControl("ID") as TextBox).Text)).FirstOrDefault());
            GridView1.DataSource = websiteList;
            GridView1.DataBind();
        }
    }
}