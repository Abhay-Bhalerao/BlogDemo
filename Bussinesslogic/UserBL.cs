using BussinessObject;
using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussinesslogic
{
    public class UserBL
    {      
        public UserBO LoginUser(string UserName,string Password)
        {
            try
            {
                DAL objUserda = new DAL();
                return objUserda.LoginUser(UserName, Password);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public int CreateBlog(Blog blog)
        {
            try
            {
                DAL objUserda = new DAL();
                return  objUserda.CreateBlog(blog);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public List<Blog> GetAllBlog()
        {
            try
            {
                DAL objUserda = new DAL();
                return objUserda.GetAllBlog();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
