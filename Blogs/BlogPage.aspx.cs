using BussinessObject;
using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Blogs
{
    public partial class BlogPage : System.Web.UI.Page
    {
        DAL dAL = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            var username = User.Identity.Name;
            if (!IsPostBack)
            {         
                var post = dAL.GetAllBlog();
                var userpost = post.Where(x => x.author == username);
                ddlPost.DataSource = userpost;
                ddlPost.DataBind();
                ddlPost.DataTextField = "title";
                ddlPost.DataValueField = "Id";
                ddlPost.DataBind();
                ddlPost.Items.Insert(0, new ListItem("New", "0"));
                txtAuthor.Text = username;
            }
            var name= User.Identity.Name;
            lblName.Text = "Welcome " + name;

        }
        protected void btnDraft_Click(object sender, EventArgs e)
        {
             var entit = BuildDatabaseEntities();
             var res = dAL.CreateBlog(entit);
             ClearControl();
        }

        protected Blog BuildDatabaseEntities()
        {
            var entity = new Blog();
            entity.Id = String.IsNullOrEmpty(idfield.Value) ? 0   :Convert.ToInt32(idfield.Value);
            entity.title = txtTitle.Text;
            entity.author = txtAuthor.Text;
            entity.content = txtContent.Text;
            entity.status = ddlStatus.SelectedValue;
            entity.create_date = String.IsNullOrEmpty(txtCalender.Text)? null :txtCalender.Text;
            entity.publish_date= String.IsNullOrEmpty(txtCalender2.Text) ? null : txtCalender2.Text;
            return entity;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {           
            txtCalender.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            
            Calendar2.Visible = true;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtCalender2.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
        }

        protected void ddlPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((ddlPost.SelectedItem.Value!="New")&& (ddlPost.SelectedItem.Value != "Select") )
            {
                int selectedid = Convert.ToInt32(ddlPost.SelectedItem.Value);
                var post = dAL.GetAllBlog();
                var posts = post.Where(x => x.Id == selectedid).FirstOrDefault();
                idfield.Value = posts.Id.ToString();
                txtTitle.Text=posts.title;
                txtAuthor.Text=posts.author;
                txtContent.Text=posts.content;
                ddlStatus.SelectedValue=posts.status;
                txtCalender.Text = posts.create_date;
                txtCalender2.Text = posts.publish_date;
                if (posts.status == "Draft")
                {
                    divcreate.Visible = true;
                    divpublish.Visible = false;
                }
                else
                {
                    divcreate.Visible = false;
                    divpublish.Visible = true;
                }  
            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlStatus.SelectedItem.Value== "Draft")
            {
                divcreate.Visible = true;
                divpublish.Visible = false;
            }
            if (ddlStatus.SelectedItem.Value == "Publish")
            {
                divcreate.Visible = false;
                divpublish.Visible = true;
            }
        }

        protected void ClearControl()
        {
            idfield.Value = "";
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtContent.Text = "";
            ddlStatus.SelectedItem.Value = "New";
            txtCalender.Text = "";
            txtCalender2.Text = "";
            divcreate.Visible = true;
            divpublish.Visible = true;
        }

        protected void btnViewPost_Click(object sender, EventArgs e)
        {
            Response.Redirect("DiplayBlog.aspx");
        }
    }
}