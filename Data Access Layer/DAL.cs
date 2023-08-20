using BussinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Data_Access_Layer
{
    public class DAL
    {
            private string connectionstr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            public int CreateBlog(Blog blog)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionstr))
                    {
                        using (SqlCommand cmd = new SqlCommand("CreateBlog", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Id", blog.Id);
                            cmd.Parameters.AddWithValue("@title", blog.title);
                            cmd.Parameters.AddWithValue("@author", blog.author);
                            cmd.Parameters.AddWithValue("@content", blog.content);
                            cmd.Parameters.AddWithValue("@status", blog.status);
                            if(blog.create_date!=null)
                            cmd.Parameters.AddWithValue("@create_date", blog.create_date);
                            else
                            cmd.Parameters.AddWithValue("@create_date", DBNull.Value);
                            if(blog.publish_date!=null)
                            cmd.Parameters.AddWithValue("@publish_date", blog.publish_date);
                            else
                            cmd.Parameters.AddWithValue("@publish_date", DBNull.Value);
                             con.Open();
                            int result = cmd.ExecuteNonQuery();
                            con.Close();
                            return result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            public List<Blog> GetAllBlog()
            {
                try
                {
                    List<Blog> blogs = new List<Blog>();
                    using (SqlConnection con = new SqlConnection(connectionstr))
                    {
                        using (SqlCommand cmd = new SqlCommand("GetAllBlog", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            con.Open();
                            var reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                Blog blog = new Blog();
                                blog.Id = Convert.ToInt32(reader[0]);
                                blog.title = reader.IsDBNull(1) ? "" : reader[1].ToString();
                                blog.author = reader.IsDBNull(2) ? "" : reader[2].ToString();
                                blog.content = reader.IsDBNull(3) ? "" : reader[3].ToString();
                                blog.status = reader.IsDBNull(4) ? "" : reader[4].ToString();
                                blog.create_date = reader.IsDBNull(5) ?"": reader[5].ToString();
                                blog.publish_date = reader.IsDBNull(6) ?"": reader[6].ToString();
                                blogs.Add(blog);
                            }
                        }
                    }
                    return blogs;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

             public UserBO LoginUser(string User, string Password)
        {
            UserBO userBO = new UserBO();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstr))
                {
                    using (SqlCommand cmd = new SqlCommand("LoginUser", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", User);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        con.Open();
                        var dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            userBO.Id = Convert.ToInt32(dr[0]);
                            userBO.Name = dr.IsDBNull(1) ? " " : dr[1].ToString();
                            userBO.Password = dr.IsDBNull(2) ? " " : dr[2].ToString();
                            userBO.EmailID = dr.IsDBNull(3) ? " " : dr[3].ToString();
                            userBO.Mobilenumber = dr.IsDBNull(4) ? " " : dr[4].ToString();
                        }
                    }
                    return userBO;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
