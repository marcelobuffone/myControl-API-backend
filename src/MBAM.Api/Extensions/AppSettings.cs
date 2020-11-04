
namespace MBAM.Api.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int HoursExpiration { get; set; }
        public string Issuer { get; set; }
        public string ValidAudience { get; set; }
    }
}
