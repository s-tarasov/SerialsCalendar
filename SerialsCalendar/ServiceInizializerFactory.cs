using System;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;

namespace SerialsCalendar
{
    public class ServiceInizializerFactory
    {
        public static Task<BaseClientService.Initializer> GetServiceInizializerAsync(string clientId, string clientSecret)
        {
            if (clientId == null) throw new ArgumentNullException("clientId");
            if (clientSecret == null) throw new ArgumentNullException("clientSecret");

            return GetServiceInitializerInternalAsync(clientId, clientSecret);
        }

        private static async Task<BaseClientService.Initializer> GetServiceInitializerInternalAsync(string clientId, string clientSecret)
        {
            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                },
                new[] { CalendarService.Scope.Calendar },
                "user",
                CancellationToken.None);

            return new BaseClientService.Initializer
            {
                HttpClientInitializer = credential
            };
        }
    }
}