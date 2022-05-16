using System.Windows;
using System.Windows.Input;

namespace RF_Control
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    RFController.Move(RFController.DIRECTIONS.UP);
                    break;
                case Key.Down:
                    RFController.Move(RFController.DIRECTIONS.DOWN);
                    break;
                case Key.Right:
                    RFController.Move(RFController.DIRECTIONS.RIGHT);
                    break;
                case Key.Left:
                    RFController.Move(RFController.DIRECTIONS.LEFT);
                    break;
            }
        }
    }
}
