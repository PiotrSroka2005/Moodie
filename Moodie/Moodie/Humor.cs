using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moodie
{
    public class Humor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public MoodEnum Humor { get; set; }
    }
}
