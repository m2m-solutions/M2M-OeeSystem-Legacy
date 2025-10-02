using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace M2M.DataCenter.WebUI.Admin
{
    public partial class CategoryListControl : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            SqlDataSource1.ConnectionString = Database.SystemConnectionString;
            SqlDataSource4.ConnectionString = Database.SystemConnectionString;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SqlDataSource4_Updated(object sender, SqlDataSourceStatusEventArgs e)
        {
            
        }
    }
}