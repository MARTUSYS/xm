using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GBDD
{
    public class AppealModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
    }
}
