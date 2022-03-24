using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Lab_6.Views
{
    public partial class AddNoteView : UserControl
    {
        public AddNoteView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
