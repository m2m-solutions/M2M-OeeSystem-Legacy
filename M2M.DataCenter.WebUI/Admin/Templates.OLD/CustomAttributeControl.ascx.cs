using System.Web.UI;
using System.ComponentModel;

namespace SchedulerTemplatesCS
{
    public partial class CustomAttributeControl : UserControl
    {
        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        public string Value
        {
            get
            {
                return AttributeValue.Text;
            }

            set
            {
                AttributeValue.Text = value;
            }
        }

        [Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
        public string Label
        {
            get
            {
                return AttributeLabel.Text;
            }

            set
            {
                AttributeLabel.Text = value;
            }
        }
    }
}