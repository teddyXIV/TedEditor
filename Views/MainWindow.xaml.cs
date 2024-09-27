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
using Microsoft.Win32;
using System.IO;
using TedEditor.Models;
using System.Windows.Threading;


/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
/// 

namespace TedEditor.Views
{
    public partial class MainWindow : Window
    {
        private Caret caret;
        private Rectangle visibleCaret;
        private DispatcherTimer caretBlinker;
        public MainWindow()
        {
            InitializeComponent();

            caret = new(0, 0);

            visibleCaret = new()
            {
                Width = 16,
                Height = 16,
                Fill = Brushes.LimeGreen
            };

            caretBlinker = new();
            caretBlinker.Interval = TimeSpan.FromMilliseconds(500);
            caretBlinker.Tick += OnCaretBlink;
            caretBlinker.Start();


            tedEditor.Children.Add(visibleCaret);
        }

        private void OnCaretBlink(object sender, EventArgs e)
        {
            visibleCaret.Visibility = visibleCaret.Visibility == Visibility.Visible
                ? Visibility.Hidden
                : Visibility.Visible;
        }

    }
}