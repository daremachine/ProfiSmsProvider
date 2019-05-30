namespace App.Infrastructure.Services.Sms.ProfiSmsApi
{
    /// <summary>
    /// Sms response
    /// </summary>
    /// <see cref="https://document.profisms.cz/index.php?CTRL=api_sms#response_ok"/>
    public interface ISmsResponse
    {
        /// <summary>
        /// Jedná se o podpis ze strany API, slouží k validaci, že odpověď skutečně pochází ze strany ProfiSMS.
        /// </summary>
        /// <see cref="https://document.profisms.cz/index.php?CTRL=api_common#response"/>
        bool IsValid { get; }
        
        int ErrorCode { get; }
        string ErrorMessage { get; }
        bool HasError { get; }
        
        float ProcessTime { get; }
        string Text { get; }
        string Msisdn { get; }
        string PId { get; }
        string UserSource { get; }
        bool IsDeliveryRequired { get; }
        string DeliverStatus { get; }
        string SmsStatus { get; }
        int SmsId { get; }
        decimal Price { get; }
        decimal PriceVat { get; }
    }
}