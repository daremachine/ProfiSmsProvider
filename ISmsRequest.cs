namespace App.Infrastructure.Services.Sms.ProfiSmsApi
{
    public interface ISmsRequest
    {
        string Url { get; }
        RequestCtrlEnum Ctrl { get; }
        string Login { get; }
        string Password { get; }
        string Service { get; }
        string Call { get; }
        string Text { get; }
        string Msisdn { get; }
        string PId { get; }
        string UserSource { get; }
        int Delivery { get; }
        string Address { get; }
        string Source { get; }
    }
}