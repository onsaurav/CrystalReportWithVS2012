using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalReportWithVS2012.ReportClasses.ReportData
{
    public class AMIN_ITEMS
    {
        public int Id { get; set; }
        public string CATEGORY { get; set; }
        public string NAME { get; set; }
        public string COLOUR { get; set; }
        public string BRAND { get; set; }
        public string SIZE { get; set; }
        public string UNITS { get; set; }
        public string REMARKS { get; set; }
        public string USERID { get; set; }
        public DateTime RECORD_INSERTED_DATE { get; set; }
        public DateTime RECORD_UPDATED_DATE { get; set; }
    }
}
