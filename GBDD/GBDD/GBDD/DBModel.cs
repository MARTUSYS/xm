using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace GBDD
{
    public class DBModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Region { get; set; }
        public string Subdivision { get; set; }
        public string Position { get; set; }
        public string Full_name { get; set; }

        public string Last_name { get; set; }
        public string First_name { get; set; }
        public string Patronymic { get; set; }
        public Int64 Phone { get; set; }
        public string Email { get; set; }
        public string Event_location { get; set; }

        public bool Organization { get; set; }
        public string Name_of_company { get; set; }
        public string Additional_information { get; set; }
        public DateTime Date { get; set; }
    }
}
