namespace NaijaCartApi.Contracts.QueryHelpers
{
    public class DateRangeQuery
    {
        public DateRangeQuery() { }

        public DateRangeQuery(DateTime? dateFrom, DateTime? dateTo)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        public DateTime? DateFrom { get; private set; }

        public DateTime? DateTo { get; private set; }

        internal bool CanSearch => DateFrom.HasValue && DateTo.HasValue;
    }
}
