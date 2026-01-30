using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.models
{
    public class LeaderboardDTO
    {
        public string username {  get; set; }
        public int score { get; set; }
        public DateTime timestamp { get; set; }
    }
}
