using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace App.Infrastructure.Services.Sms.ProfiSmsApi
{
    /// <summary>
    /// ProfiSms provider
    /// </summary>
    /// <see cref="https://document.profisms.cz/index.php"/>
    public class ProfiSmsProvider : ISmsProvider
    {
        private readonly IConfiguration _configuration;
        private static readonly HttpClient Client = new HttpClient();

        public ProfiSmsProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc />
        public async Task<ISmsResponse> SendSms(SmsRequest smsRequest)
        {
            // add request config parameters
            smsRequest.SetFromConfig(_configuration.GetSection("ProfiSms:Login").Value,
                GeneratePassword(_configuration.GetSection("ProfiSms:Password").Value, smsRequest.Call),
                _configuration.GetSection("ProfiSms:Url").Value,
                bool.Parse(_configuration.GetSection("ProfiSms:Delivery").Value),
                _configuration.GetSection("ProfiSms:Address").Value);

            var response = await Client.GetStringAsync(SmsRequestUrlFactory.Create(smsRequest));

            return new SmsResponse(_configuration.GetSection("ProfiSms:Password").Value,
                smsRequest.Password,
                response,
                smsRequest.Text,
                smsRequest.Msisdn,
                smsRequest.PId,
                smsRequest.UserSource,
                smsRequest.Delivery != 0);
        }

        /// <summary>
        /// Generate password
        /// </summary>
        /// <see cref="https://document.profisms.cz/index.php?CTRL=api_sms#parameters_examples"/>
        /// <param name="password"></param>
        /// <param name="call"></param>
        /// <returns></returns>
        private static string GeneratePassword(string password, string call)
        {
            string pwdHash;
            string hash;

            using (var a = MD5.Create())
            {
                pwdHash = string.Join("",
                    a.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("x2")));
            }

            using (var b = MD5.Create())
            {
                hash = string.Join("",
                    b.ComputeHash(Encoding.UTF8.GetBytes(pwdHash + call)).Select(x => x.ToString("x2")));
            }

            return hash;
        }
    }
}