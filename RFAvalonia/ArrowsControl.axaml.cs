using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RFAvalonia
{
    public partial class ArrowsControl : UserControl
    {
        public ArrowsControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
