using System;
using System.Collections.Generic;

namespace DailyReportApp.Models
{
    public class DailyReportListViewModel
    {
        public IEnumerable<DailyReport> DailyReports { get; set; }
        public DateTime SelectedDate { get; set; } // To pass the date to the view for display

        // Summary properties
        public decimal TotalDepit { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal NetDifference { get; set; }

        public DailyReportListViewModel()
        {
            DailyReports = new List<DailyReport>();
        }
    }
}
