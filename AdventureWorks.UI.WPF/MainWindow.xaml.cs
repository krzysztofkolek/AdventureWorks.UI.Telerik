using Telerik.Windows.Controls;

namespace AdventureWorks.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RadRibbonWindow
    {
        static MainWindow()
        {
            RadRibbonWindow.IsWindowsThemeEnabled = false;
        }

        public MainWindow()
        {
            InitializeComponent();
            IconSources.ChangeIconsSet(IconsSet.Modern);
        }
    }
}
