using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IdeaManager.UI.Resources
{
    /// <summary>
    /// Interaction logic for Symbol.xaml
    /// </summary>
    public partial class Symbol : UserControl
    {
        public Symbol()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Sym),
                typeof(string),
                typeof(Symbol),
                new PropertyMetadata(""));
        public string Sym
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
    }
}
