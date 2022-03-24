using Avalonia;
using Avalonia.Controls;
using ReactiveUI;
using Avalonia.Markup.Xaml;
using System;
using Lab_6.ViewModels;
using System.Collections.ObjectModel;
using Lab_6.Models;
using DynamicData;
using System.Reactive.Linq;

namespace Lab_6.Views
{
    public partial class ListNotesView : UserControl
    {
       
        public ListNotesView()
        {
            
            InitializeComponent();
            var datePicker = this.FindControl<DatePicker>("DatePicker");
            var today = DateTime.Today;
            datePicker.SelectedDate = today.AddDays(-1);    
            datePicker.SelectedDateChanged += delegate
            {
                var context = this.DataContext as ListNotesViewModel;
                if (context != null)
                    context.CheckDate();


                //тут будет передаваться дата на средний уровень, чтобы в дальнейшем выводить заметки по этой дате
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
