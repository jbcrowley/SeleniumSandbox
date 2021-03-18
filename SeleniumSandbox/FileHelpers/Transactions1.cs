using FileHelpers;
using System;

namespace SeleniumSandbox.Files
{
    [DelimitedRecord(",")]
    [IgnoreFirst] // ignore the CSV headers
    public class Transactions1
    {
        [FieldConverter(ConverterKind.Date, "MM/dd/yyyy")]
        public DateTime TransactionDate;
        public string CheckNumber;
        public string Description;
        public decimal DebitAmount;
        public decimal CreditAmount;
    }
}