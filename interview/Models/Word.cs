using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interview.Models
{
    public class Word
    {
        public string Literal { get; set; }
        public int Length => Literal.Length;

        public Word(string literal)
        {
            Literal = literal;
        }
    }
}
