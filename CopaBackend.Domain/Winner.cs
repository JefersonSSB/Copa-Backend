using System;
using System.Collections.Generic;
using System.Text;

namespace CopaBackend.Domain
{
    public class Winner
    {
        public string Nome { get; set; }
        public int Position { get; set; }

        public static Winner New(string nome, int position)
        {
            return new Winner() { Nome = nome, Position = position };
        }
    }
}
