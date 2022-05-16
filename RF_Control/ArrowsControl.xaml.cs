using System.Windows;
using System.Windows.Controls;

namespace RF_Control
{
    /// <summary>
    /// Interaction logic for ArrowsControl.xaml
    /// </summary>
    public partial class ArrowsControl : UserControl
    {
        public ArrowsControl()
        {
            InitializeComponent();
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            RFController.Move(RFController.DIRECTIONS.UP);
        }

        private void left_Click(object sender, RoutedEventArgs e)
        {
            RFController.Move(RFController.DIRECTIONS.LEFT);
        }

        private void right_Click(object sender, RoutedEventArgs e)
        {
            RFController.Move(RFController.DIRECTIONS.RIGHT);
        }

        private void down_Click(object sender, RoutedEventArgs e)
        {
            RFController.Move(RFController.DIRECTIONS.DOWN);
        }
    }
}
