using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.models
{
    public class Card
    {
        public int Value { get; set; }
        public String CardBackImagePath { get; set; }
        public Bitmap CardImage { get; set; }
    }
}
