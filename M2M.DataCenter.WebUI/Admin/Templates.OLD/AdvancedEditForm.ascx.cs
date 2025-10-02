using System;
using System.ComponentModel;
using System.Web.UI;
using Telerik.Web.UI;

namespace SchedulerTemplatesCS
{
    public partial class AdvancedEditForm : UserControl
    {
        protected RadScheduler Owner
        {
            get
            {
                return Appointment.Owner;
            }
        }

        protected Appointment Appointment
        {
            get
            {
                SchedulerFormContainer container = (SchedulerFormContainer)BindingContainer;
                return container.Appointment;
            }
        }

        #region Properties forwarded to AdvancedForm user control

        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        public string Subject
        {
            get
            {
                return AdvancedForm1.Subject;
            }

            set
            {
                AdvancedForm1.Subject = value;
            }
        }

        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        public DateTime Start
        {
            get
            {
                return AdvancedForm1.Start;
            }

            set
            {
                AdvancedForm1.Start = value;
            }
        }

        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        public DateTime End
        {
            get
            {
                return AdvancedForm1.End;
            }

            set
            {
                AdvancedForm1.End = value;
            }
        }

        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        public string RecurrenceRuleText
        {
            get
            {
                return AdvancedForm1.RecurrenceRuleText;
            }

            set
            {
                AdvancedForm1.RecurrenceRuleText = value;
            }
        }


        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateButton.ValidationGroup = Owner.ValidationGroup;
        }
    }
}