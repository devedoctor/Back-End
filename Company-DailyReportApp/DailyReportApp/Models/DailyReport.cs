using System;
using System.ComponentModel.DataAnnotations; // For display attributes
using System.ComponentModel.DataAnnotations.Schema; // For [Column] if needed

namespace DailyReportApp.Models
{
    // Map to the existing table name in your database
    [Table("DailyReport")]
    public class DailyReport
    {
        // No [Key] attribute here for InvoiceNo or CustCode, as we'll define a composite key in DbContext
        [Display(Name = "رقم الفاتوره")]
        public int InvoiceNo { get; set; }

        [Display(Name = "كود العميل")]
        public int CustCode { get; set; }

        [Display(Name = "اسم العميل")]
        public string CustName { get; set; }

        [Display(Name = "القيمه")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")] // Specify column type for decimal
        public decimal Value { get; set; }

        [Display(Name = "التاريخ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")] // Specify column type for date
        public DateTime Date { get; set; }

        [Display(Name = "العام الدراسى")]
        public string StudyYear { get; set; }

        [Display(Name = "الموظف")]
        public string Users { get; set; }

        [Display(Name = "البيان")]
        public string Statement { get; set; }

        [Display(Name = "الحركه")]
        public string Action { get; set; }

        // New columns for summary data, assuming they exist in the DailyReport table
        [Display(Name = "Total Debit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalDepit { get; set; }

        [Display(Name = "Total Credit")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCredit { get; set; }

        [Display(Name = "Net Difference")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetDifference { get; set; }
    }
}
