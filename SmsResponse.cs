using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace App.Infrastructure.Services.Sms.ProfiSmsApi
{
    public class SmsResponse : ISmsResponse
    {
        public int ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }
        public bool HasError => ErrorCode > 0;
        public bool IsValid { get; private set; }
        public float ProcessTime { get; private set; }
        public string Text { get; private set; }
        public string Msisdn { get; private set; }
        public string PId { get; private set; }
        public string UserSource { get; private set; }
        public bool IsDeliveryRequired { get; private set; }
        public string DeliverStatus { get; private set; }
        public string SmsStatus { get; private set; }
        public int SmsId { get; private set; }
        public decimal Price { get; private set; }
        public decimal PriceVat { get; private set; }

        public SmsResponse(string password,
            string passwordHash,
            string responseJson,
            string text,
            string msisdn,
            string pId,
            string userSource,
            bool isDeliveryRequired)
        {
            JObject obj = JsonConvert.DeserializeObject<dynamic>(responseJson);

            ErrorCode = (int) obj["error"]["code"];
            ErrorMessage = (string) obj["error"]["message"];
            ProcessTime = (float) obj["_time"];
            PId = (string) obj["data"]["pid"];
            DeliverStatus = (string) obj["data"]["sms"][0]["delivery"];
            SmsId = (int) obj["data"]["sms"][0]["id"];
            SmsStatus = (string) obj["data"]["sms"][0]["state"];
            Price = (decimal) obj["data"]["price"];
            PriceVat = (decimal) obj["data"]["pricevat"];
            
            string pwdHash;
            string keyHash;

            using (var a = MD5.Create())
            {
                pwdHash = string.Join("",
                    a.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("x2")));
            }

            using (var b = MD5.Create())
            {
                keyHash = string.Join("",
                    b.ComputeHash(Encoding.UTF8.GetBytes(pwdHash + passwordHash)).Select(x => x.ToString("x2")));
            }

            IsValid = (string) obj["_key"] == keyHash;

            Text = text;
            Msisdn = msisdn;
            PId = pId;
            UserSource = userSource;
            IsDeliveryRequired = isDeliveryRequired;
        }
    }
}