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
using IdeaManager.UI.ViewModels;
using IdeaManager.UI.Views;

namespace IdeaManager.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(IdeaFormViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }

    private void InjectIdeaFormViewModel(object sender, RoutedEventArgs e)
    {
        DataContext = App.ServiceProvider.GetService(typeof(IdeaFormViewModel));
    }

    private void InjectIdeaListViewModel(object sender, RoutedEventArgs e)
    {
        DataContext = App.ServiceProvider.GetService(typeof(IdeaListViewModel));
    }
}