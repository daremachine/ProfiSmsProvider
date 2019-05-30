using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;

namespace App.Infrastructure.Services.Sms.ProfiSmsApi
{
    public static class SmsRequestUrlFactory
    {
        /// <summary>
        /// Create request url with query parameters
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string Create(ISmsRequest request)
        {
            var parameters = new Dictionary<string, string>
            {
                {"CTRL", request.Ctrl.ToString()},
                {"_login", request.Login},
                {"_password", request.Password},
                {"_service", request.Service},
                // {"_service", "general"}, // is for testing
                {"_call", request.Call},
                {"text", request.Text},
                {"msisdn", request.Msisdn},
                {"delivery", request.Delivery.ToString()}
            };
            
            if(request.Delivery == 1) parameters.Add("Address", request.Address);
            if(!string.IsNullOrEmpty(request.PId)) parameters.Add("pid", request.PId);
            if(!string.IsNullOrEmpty(request.Source)) parameters.Add("source", request.Source);
            if(!string.IsNullOrEmpty(request.UserSource)) parameters.Add("usersource", request.UserSource);

            return QueryHelpers.AddQueryString(request.Url, parameters);
        }
    }
}