using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Practices.Prism.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MTBNetClient
{
    public class MTBNetClientViewModel
    {
        private HttpClient Client { get; set; }
        private ObservableCollection<string> _devices { get; set; }
        private ObservableCollection<string> _components { get; set; }

        private readonly IMessagingService _messagingService;
        private HubConnection _mtbConnection;


        public ObservableCollection<string> Messages { get; } = new ObservableCollection<string>();

        public MTBNetClientViewModel(IMessagingService messagingService)
        {
            _messagingService = messagingService;
        }

        public ICommand LoadedCommand
        {
            get
            {
                return new DelegateCommand(OnLoadRaised);
            }
        }

        public ICommand ConnectMTBCommand
        {
            get
            {
                return new DelegateCommand(OnConnectMTBRaised);
            }
        }

        private void OnLoadRaised()
        {
            Client = new HttpClient();
        }

        private async void OnConnectMTBRaised()
        {
            #region MTB
            CloseConnection(_mtbConnection);
            _mtbConnection = new HubConnectionBuilder()
                        .WithUrl(new Uri(Addresses.MTBConnectionHubAddress))
                        .Build();

            //_mtbConnection.Closed += HubConnectionClosed;

            //_mtbConnection.On<string, int>("BroadcastMessage", OnMessageReceived);
            //_mtbConnection.On<int>("TimerAction", Test);
            _mtbConnection.On<string, object> ("BroadcastMessage", (changedParam, value) =>
            {
                Console.WriteLine("Parameter:" + changedParam + "   Value is: " + value);
            });


            try
            {
                if (_mtbConnection != null)
                {
                    await  _mtbConnection.StartAsync();
                }
            }
            catch (HttpRequestException ex)
            {
                _messagingService.ShowMessage(ex.Message);
            }

            //GetAllAssemmbly();

            Console.WriteLine("Load Client Succeed");

            #endregion
        }

        private async void GetAllAssemmbly()
        {
            object mtbversion = await GetDataFromServer(Addresses.MTBConnectionAddress, "MTBVersion");
            Console.WriteLine("mtbversion is {0}", mtbversion);
        }


        private void CloseConnection(HubConnection connection)
        {
            connection?.StopAsync();
            connection?.DisposeAsync();
        }

        private void HubConnectionClosed(Exception ex)
        {
            _messagingService.ShowMessage(ex.Message);
        }

        private void OnMessageReceived(string changedParam, int value)
        {
            Console.WriteLine("Parameter:" + changedParam + "   Value is: " + value);
            App.Current.Dispatcher.Invoke(() =>
            {
                switch (changedParam)
                {
                    case "Objective":
                        
                        break;
                    case "Reflector":
                        
                        break;
                    case "Brightness":
                        
                        break;
                    case "RLTL":
                        
                        break;
                    default:
                        break;
                }
            });
        }

        private void OnChangeMessageReceived(string changeFiled, object value)
        {
            Console.WriteLine("Change field is:{0}, and value is {1}", changeFiled, value);
        }

        private async Task<object> GetDataFromServer(string baseUri, string childUri)
        {
            try
            {
                string Uri = baseUri;

                HttpResponseMessage response = await Client.GetAsync(Uri + childUri);
                if (response.IsSuccessStatusCode)
                {
                    string test = response.Content.ReadAsStringAsync().Result;
                    return JasonToTypeConverter<object>(test);
                }

                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        private T JasonToTypeConverter<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }


    }
}
