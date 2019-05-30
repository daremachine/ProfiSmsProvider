using System;
using System.Globalization;

namespace App.Infrastructure.Services.Sms.ProfiSmsApi
{
    /// <summary>
    /// SMS request
    /// </summary>
    /// <see cref="https://document.profisms.cz/index.php?CTRL=api_common#request"/>
    public class SmsRequest : ISmsRequest
    {
        public string Url { get; private set; }
        public RequestCtrlEnum Ctrl { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Service => "sms";
        public string Call { get; private set; }
        public string Text { get; private set; }
        public string Msisdn { get; private set; }
        public string PId { get; private set; }
        public string UserSource { get; private set; }
        public int Delivery { get; private set; }
        public string Address { get; private set; }
        public string Source { get; private set; }

        public SmsRequest(RequestCtrlEnum ctrl,
            string text,
            string msisdn,
            string pid,
            string userSource,
            string source)
        {
            Call = new TimeSpan(DateTime.UtcNow.Ticks).TotalMilliseconds.ToString(CultureInfo.InvariantCulture);
            Ctrl = ctrl;
            Text = text;
            Msisdn = msisdn;
            PId = pid;
            UserSource = userSource;
            Source = source;
        }

        public void SetFromConfig(string login, string password, string url, bool delivery, string address)
        {
            Login = login;
            Password = password;
            Url = url;
            Delivery = delivery ? 1 : 0;
            Address = address;
        }
    }
}