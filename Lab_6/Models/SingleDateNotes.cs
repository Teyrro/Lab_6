using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6.Models
{
    public class SingleDateNotes
    {
        public DateTimeOffset Date { get; private set; }

        List<NoteData> notes;
        public List<NoteData> Notes
        {
            get => notes;
            set => notes = value;
        }

        public SingleDateNotes(DateTimeOffset date, List<NoteData> notes)
        {
            Date = date;
            Notes = notes;
        }

    }
}
