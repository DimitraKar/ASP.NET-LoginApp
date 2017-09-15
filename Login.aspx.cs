using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication8
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Login_Click(Object sender, EventArgs e) 
        {
            string username = Username.Text.ToString();
            String password = Password.Text;
            if (username.Length > 0 && password.Length > 0)
            {
                SqlDataSource sds = new SqlDataSource();
                sds.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStringDb1"].ToString();
                
                try
                {
                    
                    string passwords = encryption(password);
                    sds.SelectCommand = "SELECT Name, Username, Password FROM users WHERE(Username= '" + username + "') AND (Password= '" + passwords + "');";
                    DataView dv = (DataView)sds.Select(DataSourceSelectArguments.Empty);
                     if (dv.Count == 0)
        {
            Mess.Visible = true;
            Mess.Text = "Invalid username and password!";
            return;
        }
        else
        {
           
           this.Session["Username1"] = dv[0].Row["Name"].ToString();            
           Response.Redirect("home/Home.aspx");
        }
                }

                catch (Exception ex)
                {
                    Mess.Text = ex.ToString();
                    Mess.Visible = true;
                }
               

            }
            else
            {
                String Message = "Field empty";
                Mess.Text = Message.ToString();
                Mess.Visible = true;
            } 
        
        }
        public string encryption(String password)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }
    }
}
