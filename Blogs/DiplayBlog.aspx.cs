using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blogs
{
    public partial class DiplayBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL dAL = new DAL();
            var post = dAL.GetAllBlog();
            var display = post.Where(x => x.publish_date != string.Empty).ToList();
            
            lvPost.DataSource = display;
            lvPost.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("BlogPage.aspx");
        }
    }
}