using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Homework11
{
    public class Consultant : IChangingRecords
    {
        protected string name;
        protected string surname;
        protected string phone_number;
        protected string passport_number;
        protected string passport_series;
        protected DataOfRecord data_of_record;

        public string Name
        {
            get => name;
        }
        public string Surname
        {
            get => surname;
        }
        public string PhoneNumber
        {
            get => phone_number;
            set => phone_number = value;
        }
        public string PassportNumber
        {
            get => passport_number;
            set
            {
                if (value != null)
                    passport_number = "****";
                else
                    passport_number = null;
            }
        }
        public string PassportSeries
        {
            get => passport_series;
            set
            {
                if (value != null)
                    passport_series = "******";
                else
                    passport_series = null;
            }
        }
        public DataOfRecord DataRecord
        {
            get
            {
                return data_of_record;
            }
        }

        public Consultant(string name, string surname, string phone_number, string passport_series, string passport_number,
                          string name_changing, string type_changing, string who_changing)
        {
            this.name = name;
            this.surname = surname;
            PhoneNumber = phone_number;
            PassportNumber = passport_number;
            PassportSeries = passport_series;
            data_of_record = new DataOfRecord(DateTime.Now, name_changing, type_changing, who_changing);
        }
    }
}
