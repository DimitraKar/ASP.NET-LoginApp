using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication8
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Username1"] != null)
            {
                //Retrieving name from Session
                Username1.Visible = true;
                Username1.Text = "Welcome: " + this.Session["Username1"].ToString();
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
           

        }
    }
}