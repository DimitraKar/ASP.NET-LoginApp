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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Register_Click(object sender, EventArgs e)
        {
            string username = Username.Text.ToString();
            string name = Name.Text.ToString();
            String password = Password.Text;
            if (username.Length > 0 && password.Length > 0 && name.Length > 0)
            {
                String passwords = encryption(password); 
                string constr = ConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                try
                {
                    string sql = "INSERT INTO users (Name, Username ,Password) VALUES ('" + name + "','" + username + "','" + passwords + "');";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    String Message = "Registered Successfully!";
                    Mess.Text = Message.ToString();
                    Mess.Visible = true;
                }
                catch (Exception ex)
                {

                    Mess.Text = ex.ToString();
                    Mess.Visible = true;
                }
                con.Close(); 
                
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