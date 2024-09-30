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
using TedEditor.Services;


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
        private readonly DispatcherTimer caretBlinker;
        private CaretService caretService;
        public MainWindow()
        {
            InitializeComponent();

            caret = new(10, 10);

            caretService = new(caret);

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
            UpdateVisibleCaretPostion();
        }

        private void OnCaretBlink(object sender, EventArgs e)
        {
            visibleCaret.Visibility = visibleCaret.Visibility == Visibility.Visible
                ? Visibility.Hidden
                : Visibility.Visible;
        }

        private void UpdateVisibleCaretPostion()
        {
            Canvas.SetLeft(visibleCaret, caret.PositionX);
            Canvas.SetTop(visibleCaret, caret.PositionY);
        }

        private void EditorKeyDown(object sender, KeyEventArgs e)
        {
            caretService.HandleKeyDown(e);
            UpdateVisibleCaretPostion();
        }

    }
}