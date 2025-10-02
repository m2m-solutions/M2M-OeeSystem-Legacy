using System;

using System.Linq;

using System.Web.UI;


namespace M2M.DataCenter.WebUI.Production
{
    public partial class ToggleControl : System.Web.UI.UserControl
    {
        
        public string UserControlToBeLoaded { get; set; }
        
        private bool IsLoaded
        {
            get 
            {
                object obj = ViewState["IsLoaded"];
                if(obj == null)
                    obj = false;
                return (bool)obj;
            }
            set 
            {
                ViewState["IsLoaded"] = value;
            }
        }

        private void LoadUserControl()
        {
            PlaceHolder1.Controls.Clear();
            UserControl uc = (UserControl)LoadControl(UserControlToBeLoaded);
            PlaceHolder1.Controls.Add(uc);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsLoaded)
                LoadUserControl();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            IsLoaded = !IsLoaded;
            if (IsLoaded)
                LoadUserControl();
            else
                PlaceHolder1.Controls.RemoveAt(0);
        }
    }
}