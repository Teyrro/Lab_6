using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Lab_6.Models;
using System.Reactive;


namespace Lab_6.ViewModels
{
    public class AddNoteViewModel : ViewModelBase
    {
        private string name;
        private string text;

        public AddNoteViewModel()
        {
            name = "";
            text = "";
            var addEnabled = this.WhenAnyValue(
                newNote => newNote.Name,
                newNote => !string.IsNullOrWhiteSpace(newNote));

            Add = ReactiveCommand.Create(() => UpdateNote(), addEnabled);
            Cancel = ReactiveCommand.Create(() => { });
        }

        public ReactiveCommand<Unit, NoteData> Add { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }

        public NoteData UpdateNote()
        {
            NoteData NewNoteData = new NoteData(name, text);
            
            return NewNoteData;
        }

        private string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        private string Text
        {
            get => text;
            set => this.RaiseAndSetIfChanged(ref text, value);
        }
    }
}
