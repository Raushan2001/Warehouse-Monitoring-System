using Microsoft.AspNetCore.Html;
using System.Net.Mail;
using System.Net;
using System.Threading;
using WarehouseMonitoring.Context;

namespace WarehouseMonitoring.BackgroundServices
{
    public class StoreBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public StoreBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var _dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    var hasvests = _dbContext.Harvests.ToList();

                    foreach (var harvest in hasvests)
                    {
                        var _crop = _dbContext.CroupTypes.FirstOrDefault(x => x.Id == harvest.CroupTypeId);

                        var expiredDate = harvest.DateOfStorage.AddDays(_crop.MaxStorageLife);

                        if (expiredDate <= DateTime.Now)
                        {
                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");



                            client.Port = 587;
                            client.DeliveryMethod = SmtpDeliveryMethod.Network;
                            client.UseDefaultCredentials = false;
                            System.Net.NetworkCredential credentials =
                                new System.Net.NetworkCredential("wms.alerts@outlook.com", "1qaz2wsx@#");
                            client.EnableSsl = true;
                            client.Credentials = credentials;



                            try
                            {
                                var mail = new MailMessage("wms.alerts@outlook.com", "RaushanrashidWMS@outlook.com");
                                mail.Subject = "WMS Expiaration Repot";
                                mail.IsBodyHtml = true;
                                mail.Body = "Please release the stock as soon as possible since "+_crop.Name+" at storage Should be released on or before "+expiredDate;
                                client.Send(mail);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                throw ex;
                            }




                        }

                        
                    }

                    await Task.Delay(new TimeSpan(24, 1, 0));

                    //await Task.CompletedTask;
                }
            }
        }
    }
}


