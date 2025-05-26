using intelika.fontawesome.wpf;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfTest;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
       // var helper = new FontAwesomeHelper();

        var icon =Icons.DuotoneIcons.GetIconAsImageSource(NormalIconType.align_center, System.Drawing.Color.Black, System.Drawing.Color.Gray, 32);

        var btn = new Button
        {
            Width = 100,
            Height = 50,
            Content = new Image
            {
                Source = icon,
                Width = 24,
                Height = 24
            }
        };

        MainGrid.Children.Add(btn);
    }
}