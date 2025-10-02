using System;
using System.ComponentModel;
using System.Web.UI;
using Telerik.Web.UI;

namespace SchedulerTemplatesCS
{
    public partial class AdvancedForm : UserControl
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


        #region Properties forwarded to SchedulerDefaultForm user control

        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        public string Subject
        {
            get
            {
                return SchedulerDefaultForm1.Subject;
            }

            set
            {
                SchedulerDefaultForm1.Subject = value;
            }
        }

        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        public DateTime Start
        {
            get
            {
                return SchedulerDefaultForm1.Start;
            }

            set
            {
                SchedulerDefaultForm1.Start = value;
            }
        }

        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        public DateTime End
        {
            get
            {
                return SchedulerDefaultForm1.End;
            }

            set
            {
                SchedulerDefaultForm1.End = value;
            }
        }

        [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
        public string RecurrenceRuleText
        {
            get
            {
                return SchedulerDefaultForm1.RecurrenceRuleText;
            }

            set
            {
                SchedulerDefaultForm1.RecurrenceRuleText = value;
            }
        }

        #endregion

        #region Attributes and resources



        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Owner.OverflowBehavior == OverflowBehavior.Scroll)
            {
                AdvancedEditOptionsPanel.CssClass += " rsScrollingContent";
            }
        }
    }
}