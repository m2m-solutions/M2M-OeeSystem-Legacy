using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace M2M.DataCenter.AdminTool
{
    public class RadTextBoxWriter : TextWriter
    {
        RadTextBox _output = null;

        public RadTextBoxWriter(RadTextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            MethodInvoker action = delegate { _output.AppendText(value.ToString()); };
            _output.BeginInvoke(action);
        }



        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}