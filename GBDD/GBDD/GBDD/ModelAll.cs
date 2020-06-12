using System;
using System.Collections.Generic;
using System.Text;

namespace GBDD
{
    public class ModelAll
    {
        public string Region { get; set; }
        public string Subdivision { get; set; }
        public string Position { get; set; }
        public string Full_name { get; set; }

        public string Last_name { get; set; }
        public string First_name { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Event_location { get; set; }

        public bool Organization { get; set; }
        public string Name_of_company { get; set; }
        public string Additional_information { get; set; }
        public Int64 Outgoing_number { get; set; }
        public DateTime date_of_registration_of_the_document_in_the_organization { get; set; }
        public Int64 Registered_Mail_Number { get; set; }
        public string DataNull { get; set; }
        public DateTime Date { get; set; }


        public string Text { get; set; }
    }
}
