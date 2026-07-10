// Made By @1nonlydelete_ (discord) 
// Whole Credit Goes To DELETE HEX
// Join https://discord.gg/NT4Gda3WCK
//  Visit deletehex.com
// Clean UI With Basic Aesthetics 

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace GreatRed
{
    public partial class MainWindow : Window
    {
        private bool _isDragging = false;
        private Point _lastMousePos;
        private double _windowLeft;
        private double _windowTop;

        private bool _isMinimized = false;
        private double _originalBorderHeight = 292;
        private double _lastLeft = 0;
        private double _lastTop = 0;

        private DispatcherTimer? _downloadTimer;
        private double _downloadedSize = 0;
        private const double TotalSize = 32.0;

        private DispatcherTimer? _scanTimer;
        private double _scanProgress = 0;

        private string _selectedEmuValue = "MSI";

        private static ToastWindow? _toastWindowInstance;

        private bool _isLoggingIn = false;

        public MainWindow()
        {
            InitializeComponent();
            PasswordPlaceholder.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TxtUsername.Focus();
        }

        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);

            if (EmuSelectPopup != null && EmuSelectPopup.IsOpen)
            {
                DependencyObject? originalSource = e.OriginalSource as DependencyObject;
                bool isInsidePopup = false;
                bool isInsideTrigger = false;

                while (originalSource != null)
                {
                    if (originalSource == EmuSelectPopup)
                    {
                        isInsidePopup = true;
                        break;
                    }
                    if (originalSource == EmuSelectTrigger)
                    {
                        isInsideTrigger = true;
                        break;
                    }
                    originalSource = VisualTreeHelper.GetParent(originalSource);
                }

                if (!isInsidePopup && !isInsideTrigger)
                {
                    EmuSelectPopup.IsOpen = false;
                }
            }
        }
    }
}
