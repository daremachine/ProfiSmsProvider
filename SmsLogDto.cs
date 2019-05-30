using System;
using App.Core.AccountContext;
using App.Core.Entities;

namespace App.Infrastructure.Services.Sms.ProfiSmsApi
{
    public class SmsLogDto
    {
        public int ErrorCode { get; protected set; }
        public string ErrorMessage { get; protected set; }
        public float ProcessTime { get; protected set; }
        public string Text { get; protected set; }
        public string Msisdn { get; protected set; }
        public string PId { get; protected set; }
        public string UserSource { get; protected set; }
        public bool IsDeliveryRequired { get; protected set; } = false;
        public bool IsDelivered { get; protected set; } = false;
        public DateTime DeliveredDate { get; protected set; }
        public string DeliverStatus { get; protected set; } = "nostate";
        public string SmsStatus { get; protected set; }
        public int SmsId { get; protected set; }
        public decimal Price { get; protected set; }
        public decimal PriceVat { get; protected set; }
        public Guid AccountId { get; protected set; }
        public Account Account { get; protected set; }
        public Guid? SourceId { get; protected set; }
        
        public User Sender { get; protected set; }
        public Guid OfficeId { get; protected set; }
        public Office Office { get; protected set; }

        public SmsLogDto() { }

        public SmsLogDto(int errorCode,
            string errorMessage,
            float processTime,
            string text,
            string msisdn,
            string pId,
            string userSource,
            bool isDeliveryRequired,
            int smsId,
            decimal price,
            decimal priceVat,
            string smsStatus,
            Guid accountId,
            Guid? sourceId,
            User sender,
            Office office)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ProcessTime = processTime;
            Text = text;
            Msisdn = msisdn;
            PId = pId;
            UserSource = userSource;
            IsDeliveryRequired = isDeliveryRequired;
            SmsId = smsId;
            Price = price;
            PriceVat = priceVat;
            SmsStatus = smsStatus;
            AccountId = accountId;
            SourceId = sourceId;
            Sender = sender;
            Office = office;
        }
    }
}