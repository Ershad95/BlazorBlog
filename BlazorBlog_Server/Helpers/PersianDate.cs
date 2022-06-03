using System.Globalization;

namespace BlazorBlog_Server.Helpers
{
    public static class PersianDate
    {
        public static string ToPersianDate(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();

            return string.Format("{0:0000}/{1:00}/{2:00}",
                pc.GetYear(date),
                pc.GetMonth(date),
                pc.GetDayOfMonth(date));
        }
    }
}
