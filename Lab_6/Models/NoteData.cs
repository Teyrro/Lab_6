using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6.Models
{
    public class NoteData
    {
        public string Name { get; set; }

        public string Text { get; set; }

    
        public NoteData (string name, string text)
        {
            Name = name;
            Text = text;
       
        }
    }
}
