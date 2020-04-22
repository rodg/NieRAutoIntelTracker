using System;
using System.Windows.Forms;

using System.Xml;

namespace LiveSplit.UI.Components
{
    public partial class Settings : UserControl
    {
        public Boolean IntelDisplayEnabled { get; set; }

        private Action<bool> _displayAction;

        public Settings(Action<bool> action)
        {
            InitializeComponent();
            _displayAction = action;

            // default setting
            IntelDisplayEnabled = true;

            checkBox1.DataBindings.Add("Checked", this, "IntelDisplayEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            XmlElement parent = document.CreateElement("Settings");

            var element = document.CreateElement(this.ToString());
            element.InnerText = "NieR:Automata Intel Tracker";
            parent.AppendChild(element);
            element = document.CreateElement("IntelDisplayEnabled");
            element.InnerText = IntelDisplayEnabled.ToString();
            parent.AppendChild(element);
            
            return parent;
        }

        public void SetSettings(XmlNode settings)
        {
            if (settings["IntelDisplayEnabled"].InnerText != null)
            {
                checkBox1.Checked = IntelDisplayEnabled = bool.Parse(settings["IntelDisplayEnabled"].InnerText);
            }
            _displayAction.Invoke(IntelDisplayEnabled);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            IntelDisplayEnabled = checkBox1.Checked;
            _displayAction.Invoke(checkBox1.Checked);
        }
    }
}