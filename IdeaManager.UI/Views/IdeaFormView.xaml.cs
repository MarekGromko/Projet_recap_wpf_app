using IdeaManager.UI.ViewModels;
using System.Windows.Controls;

namespace IdeaManager.UI.Views
{
    /// <summary>
    /// Logique d'interaction pour IdeaFormView.xaml
    /// </summary>
    public partial class IdeaFormView : UserControl
    {
        public IdeaFormView(IdeaFormViewModel ideaFormViewModel)
        {
            InitializeComponent();
            DataContext = ideaFormViewModel;
        }
    }
}
