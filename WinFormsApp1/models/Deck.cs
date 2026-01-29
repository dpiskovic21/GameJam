using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.models
{
    public static class Deck
    {
        public static List<Card> Cards { get; set; } = new List<Card>(60);
    }
}
