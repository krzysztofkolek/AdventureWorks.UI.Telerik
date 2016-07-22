using System;
using System.Linq;
using Telerik.WinControls.UI;

namespace AdventureWorks.UI.Forms.UI
{
    public partial class OutlookMailForm : RadForm
    {
        public OutlookMailForm()
        {
            InitializeComponent();

            this.FormElement.TitleBar.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
        }
    }
}
