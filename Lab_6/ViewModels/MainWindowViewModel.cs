using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Lab_6.Models;

namespace Lab_6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase currentView;
        string title;

        public MainWindowViewModel()
        {
            CurrentView = mainView = new ListNotesViewModel();
            Title = "Ежедневник";
        }

        public string Title
        {
            get => title;
            set => title = value;
        }

        public ViewModelBase CurrentView
        {
            set => this.RaiseAndSetIfChanged(ref currentView, value);
            get => currentView;
        }

        public ListNotesViewModel mainView
        {
            get;
        }

        public void Change(NoteData Item)
        {
            AddNoteViewModel addView ;
            if (Item == null)
            {
                addView = new AddNoteViewModel();
            }
            else 
                addView = new AddNoteViewModel(Item);
            
            Title = "Ежедневник - Новая заметка";

            Observable.Merge(addView.Add, addView.Cancel.Select(_ => (NoteData?)null))
                .Take(1)
                .Subscribe(newNote =>
                {
                    if (newNote != null)
                    {
                        
                       mainView.UpdateSingleList(newNote, Item);
                    }
                    CurrentView = mainView;
                    mainView.CheckDate();
                       
                }

                );

            CurrentView = addView;
        
        }

        public void DelItem(NoteData a)
        {
            mainView.DeleteNote(a);
            mainView.CheckDate();
        }
    }
}
