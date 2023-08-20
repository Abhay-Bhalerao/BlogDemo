using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Bussinesslogic;
using BussinessObject;

namespace Blogs
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            if (ValidateUser(txt_Username.Text, txt_password.Text))
                FormsAuthentication.RedirectFromLoginPage(txt_Username.Text, true);
            else
                Response.Redirect("Login.aspx", true);
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_Username.Text = "";
            txt_password.Text = "";
        }

        private bool ValidateUser(string userName, string passWord)
        {
            UserBO userBO = new UserBO();
            if ((null == userName) || (0 == userName.Length))
            {
                System.Diagnostics.Trace.WriteLine(" Input validation of userName failed.");
                return false;
            }
            if ((null == passWord) || (0 == passWord.Length))
            {
                System.Diagnostics.Trace.WriteLine("Input validation of passWord failed.");
                return false;
            }

            try
            {
                UserBL userBL = new UserBL();
                userBO = userBL.LoginUser(userName, passWord);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Exception " + ex.Message);
            }

            // If no password found, return false.
            if (null == userBO.Password)
            {
                // You could write failed login attempts here to event log for additional security.
                return false;
            }

            // Compare lookupPassword and input passWord, using a case-sensitive comparison.
            return (0 == string.Compare(userBO.Password, passWord, false));
        }


    }
}