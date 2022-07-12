using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Homework11
{
    public class Manager : Consultant, IChangingRecords
    {
        public new string Name
        {
            get => name;
            set => name = value;
        }
        public new string Surname
        {
            get => surname;
            set => surname = value;
        }
        public new string PhoneNumber
        {
            get => phone_number;
            set => phone_number = value;
        }
        public new string PassportNumber
        {
            get => passport_number;
            set => passport_number = value;
        }
        public new string PassportSeries
        {
            get => passport_series;
            set => passport_series = value;
        }

        public Manager(string name, string surname, string phone_number, string passport_series, string passport_number,
                       string name_changing, string type_changing, string who_changing) :
                  base(name, surname, phone_number, passport_series, passport_number, 
                       name_changing, type_changing, who_changing)
        {
            PassportNumber = passport_number;
            PassportSeries = passport_series;
        }
    }
}
