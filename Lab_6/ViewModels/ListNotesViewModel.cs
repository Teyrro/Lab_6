using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Lab_6.Models;
using DynamicData;
using DynamicData.Binding;
using System.Reactive.Linq;
using System.Reactive;

namespace Lab_6.ViewModels
{
    public class ListNotesViewModel : ViewModelBase
    {

        DateTimeOffset currentDate;
        public DateTimeOffset CurrentDate 
        {
            get => currentDate;
            set => this.RaiseAndSetIfChanged(ref currentDate, value);
        }

        int selectedIndex;

        public int SelectedIndex
        {
            get => selectedIndex;
            set => this.RaiseAndSetIfChanged(ref selectedIndex, value - 1);
        }

        public ListNotesViewModel() 
        {
            
            SingNote = new List<SingleDateNotes>();
            ResultNotes = new ObservableCollection<NoteData>();
            BuildSomeTestNotes();
            
            DeleteButton = ReactiveCommand.Create(() => DeleteNote());
            CurrentDate = DateTime.Today;
        }

        public ObservableCollection<NoteData> ResultNotes { get; set; }
        
        public List<SingleDateNotes> SingNote { get; set; }

        public void UpdateSingleList(NoteData newNote)
        {
        
            if (SingNote.Exists(p => p.Date == CurrentDate))
            {
                SingNote.Find(p => p.Date == CurrentDate).Notes.Add(newNote);
            }
            else
            {
                List<NoteData> listNewNote = new List<NoteData>();
                listNewNote.Add(newNote);
                SingNote.Add(new SingleDateNotes(CurrentDate, listNewNote));
            }
        }

        public ReactiveCommand<Unit, Unit> DeleteButton { get; set; }
        public void DeleteNote()
        {
            SingNote.Find(p => p.Date == currentDate).Notes.RemoveAt(SelectedIndex);
            CheckDate();
        }

        public List<NoteData> generateTestNotes(string mama)
        {
            List<NoteData> Rotes = new List<NoteData>();
            Rotes.Add(new NoteData("Заметка 1" + mama, "Тут очень важный месседж, мой друг"));
            Rotes.Add(new NoteData("Заметка 2" + mama, "Тут очень важный месседж, мой друг"));
            Rotes.Add(new NoteData("Заметка 3" + mama, "Тут очень важный месседж, мой друг"));
            return Rotes;
        }
        private void BuildSomeTestNotes()
        {
            SingNote.Add(new SingleDateNotes(new DateTime(2022, 3, 23), generateTestNotes(" mama")));
            SingNote.Add(new SingleDateNotes(new DateTime(2022, 3, 22), generateTestNotes(" papa")));
        }

        public void CheckDate()
        {
            ResultNotes.Clear();

            SingleDateNotes? tmp = SingNote.Find(p => p.Date == CurrentDate);
            if (tmp == null)
                return;

            foreach (NoteData ptr in tmp.Notes)
            {
                ResultNotes.Add(ptr);
            }
        }



    }
}
