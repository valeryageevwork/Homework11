using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11
{
    public class DataOfRecord
    {
        public DateTime DateTimeChangingRecord { get; set; }
        public string NameChanging { get; set; }
        public string TypeChanging { get; set; }
        public string WhoChanging { get; set; }

        public DataOfRecord(DateTime date_time_changing_record, string name_changing, 
                            string type_changing, string who_changing)
        {
            DateTimeChangingRecord = date_time_changing_record;
            NameChanging = name_changing;
            TypeChanging = type_changing;
            WhoChanging = who_changing;
        }
    }
}
