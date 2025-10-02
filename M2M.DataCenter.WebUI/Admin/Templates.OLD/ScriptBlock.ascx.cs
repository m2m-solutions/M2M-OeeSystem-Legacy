using System;
using System.IO;
using System.Text;
using System.Web.UI;

namespace SchedulerTemplatesCS
{
    public partial class ScriptBlock : UserControl
    {
        private class ScriptBlockContent : Control, INamingContainer
        {
        }

        private ITemplate _content;

        [TemplateContainer(typeof(ScriptBlockContent))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Content.InstantiateIn(PlaceHolder1);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            ScriptManager manager = ScriptManager.GetCurrent(Page);

            if (manager != null && manager.IsInAsyncPostBack)
            {
                StringBuilder sb = new StringBuilder();
                base.Render(new HtmlTextWriter(new StringWriter(sb)));
                string script = sb.ToString();
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), UniqueID, script, false);
            }
            else
            {
                base.Render(writer);
            }
        }
    }
}