using Microsoft.Practices.Prism.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net;
using Microsoft.AspNetCore.Sockets.Client;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace WPFClient
{
    public class WPFClinetViewModel : INotifyPropertyChanged
    {
        HttpClient Client { get; set; }
        IEnumerable<BookChapter> Books { get; set; }
        private readonly IMessagingService _messagingService;
        private string _displayContent;
        private short _reflectorPosition;
        private short _objectPosition;
        private short _brightness;
        private short _rltl;
        private Servo _lightBrightness;
        private Servo _rltlPositon;


        public ObservableCollection<string> Messages { get; } = new ObservableCollection<string>();

        public WPFClinetViewModel(IMessagingService messagingService)
        {
            _messagingService = messagingService;
        }

        //ReflectorTextColor
        private string _reflectorTextColor ="#FFFFFF";
        public string ReflectorTextColor
        {
            get
            {
                return _reflectorTextColor;
            }
            set
            {
                _reflectorTextColor = value;
                OnPropertyChanged("ReflectorTextColor");
            }
        }

        private string _color1 = "#FFFFFF";
        public string Color1
        {
            get
            {
                return _color1;
            }
            set
            {
                _color1 = value;
                OnPropertyChanged("Color1");
            }
        }

        private string _color2 = "#FFFFFF";
        public string Color2
        {
            get
            {
                return _color2;
            }
            set
            {
                _color2 = value;
                OnPropertyChanged("Color2");
            }
        }

        private string _color3 = "#FFFFFF";
        public string Color3
        {
            get
            {
                return _color3;
            }
            set
            {
                _color3 = value;
                OnPropertyChanged("Color3");
            }
        }

        public string DisplayContent
        {
            get
            {
                return _displayContent;
            }
            set
            {
                _displayContent = value;
                OnPropertyChanged("DisplayContent");
            }
        }

        public short RLTL
        {
            get
            {
                return _rltl;
            }
            set
            {
                _rltl = value;
                OnPropertyChanged("RLTL");
            }
        }
        public short Brightness
        {
            get
            {
                return _brightness;
            }
            set
            {
                _brightness = value;
                OnPropertyChanged("Brightness");
            }
        }
        public short ObjectPosition
        {
            get
            {
                return _objectPosition;
            }
            set
            {
                _objectPosition = value;
                OnPropertyChanged("ObjectPosition");
            }
        }

        public short ReflectorPosition
        {
            get
            {
                return _reflectorPosition;
            }
            set
            {
                _reflectorPosition = value;
                OnPropertyChanged("ReflectorPosition");
            }
        }

        public Servo LightBrightness
        {
            get
            {
                return _lightBrightness;
            }
            set
            {
                _lightBrightness = value;
                OnPropertyChanged("LightBrightness");
            }
        }

        public Servo RLTLPositon
        {
            get
            {
                return _rltlPositon;
            }
            set
            {
                _rltlPositon = value;
                OnPropertyChanged("RLTLPositon");
            }
        }

        public string Name { get; set; }
        public string Message { get; set; }
        public ICommand TestCommand
        {
            get
            {
                return new DelegateCommand(OnTestRaised);
            }
        }

        //RightButtonUpCommand
        public ICommand RightButtonUpCommand
        {
            get
            {
                return new DelegateCommand(OnRightButtonUpRaised);
            }
        }

        private void OnRightButtonUpRaised()
        {
            ReflectorTextColor = "#FFFFFF";
            Color1 = "#FFFFFF";
            Color2 = "#FFFFFF";
            Color3 = "#FFFFFF";
        }

        private void OnTestRaised()
        {
            DisplayBooksInConsole();
        }

        private void DisplayBooksInConsole()
        {
            Console.WriteLine("Now there are {0} books. \n", Books.Count());
            foreach (var item in Books)
            {
                string display = "Title:" + item.Title;
                display += "\n";
                display += "Id:" + item.Id;
                display += "\n";
                Console.WriteLine(display);
            }
        }

        private void DisplayBooksInMainWindow()
        {
            DisplayContent += "Now there are {0} books. \n" + Books.Count();
            foreach (var item in Books)
            {
                DisplayContent += "Title:" + item.Title;
                DisplayContent += "\n";
                DisplayContent += "Id:" + item.Id;
                DisplayContent += "\n";
            }
        }

        public ICommand LoadedCommand
        {
            get
            {
                return new DelegateCommand(OnLoadRaised);
            }
        }
        public ICommand GetDataCommand
        {
            get
            {
                return new DelegateCommand(OnGetDataRaised);
            }
        }

        public ICommand AddDataCommand
        {
            get
            {
                return new DelegateCommand(OnAddDataRaised);
            }
        }

        public ICommand UpdateDataCommand
        {
            get
            {
                return new DelegateCommand(OnUpdateDataRaised);
            }
        }

        public ICommand DeleteSetDataCommand
        {
            get
            {
                return new DelegateCommand(OnDeleteSetDataRaised);
            }
        }


        public ICommand GetObjectPositionCommand
        {
            get
            {
                return new DelegateCommand(GetObjectRaised);
            }
        }

        public ICommand GetReflectorPositonCommand
        {
            get
            {
                return new DelegateCommand(GetReflectorRaised);
            }
        }

        public ICommand GetBrightnessCommand
        {
            get
            {
                return new DelegateCommand(GetBrightnessRaised);
            }
        }

        public ICommand GetRLTLCommand
        {
            get
            {
                return new DelegateCommand(GetRLTLRaised);
            }
        }

        //这边需要学习下SignalR,还有WebHooks
        //从server向client推送
        public ICommand CallBackCommand
        {
            get
            {
                return new DelegateCommand(OnCallBackRaised);
            }
        }

        public ICommand ConnectCommand
        {
            get
            {
                return new DelegateCommand(OnConnect);
            }
        }

        public ICommand SendCommand
        {
            get
            {
                return new DelegateCommand(OnSendMessage);
            }
        }

        public ICommand UpdatePosServoCommand
        {
            get
            {
                return new DelegateCommand(UpdatePosServo);
            }
        }

        //public ICommand UpdatePosChangerCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(UpdatePosChanger);
        //    }
        //}

        public ICommand RLCheckedCommand
        {
            get
            {
                return new DelegateCommand(RLCheckedRaised);
            }
        }

        public ICommand TLCheckedCommand
        {
            get
            {
                return new DelegateCommand(TLCheckedRaised);
            }
        }

        private void RLCheckedRaised()
        {
            UpdatePosChanger(1);
        }

        private void TLCheckedRaised()
        {
            UpdatePosChanger(2);
        }

        private HubConnection _hubConnection;
        private HubConnection _can29Connection;

        //private IHubProxy _hubProxy;


        public async void OnConnect()
        {
            CloseConnection(_hubConnection);
            _hubConnection = new HubConnectionBuilder()
                        .WithUrl(new Uri(Addresses.SignalRAddress))
                        .WithConsoleLogger()
                        .Build();
            _hubConnection.Closed += HubConnectionClosed;

            //_hubProxy = _hubConnection.CreateHubProxy("ChatHub");
            _hubConnection.On<string, string>("BroadcastMessage", OnMessageReceived);

            try
            {
                await _hubConnection.StartAsync();
            }
            catch (HttpRequestException ex)
            {
                _messagingService.ShowMessage(ex.Message);
            }
            _messagingService.ShowMessage("client connected");
        }

        public async void OnSendMessage()
        {
            await _hubConnection.InvokeAsync("Send", Name, Message);
        }

        public void OnMessageReceived(string name, string message)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add($"{name}: {message}");
            });

        }

        private void HubConnectionClosed(Exception ex)
        {
            _messagingService.ShowMessage(ex.Message);
        }

        private void CloseConnection(HubConnection connection)
        {
            connection?.StopAsync();
            connection?.DisposeAsync();
        }

        private async Task GetCurrentBooks()
        {
            string uri = Addresses.BooksApi;
            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string test = response.Content.ReadAsStringAsync().Result;
                Books = JasonToEnumableConverter<BookChapter>(test);
            }
            else
            {
                Console.WriteLine("Do not get any data from server.");
                Books = null;
            }
        }

        private async void OnDeleteSetDataRaised()
        {
            Console.WriteLine("Delete Data:");
            await GetCurrentBooks();
            //var chapter = Books.FirstOrDefault(c => c.Title == "Zeiss");

            //For test conventient only
            var chapter = Books.FirstOrDefault();

            if (chapter != null)
            {
                HttpResponseMessage resp = await Client.DeleteAsync(Addresses.BooksApi + chapter.Id);
                if (resp.IsSuccessStatusCode)
                {
                    DisplayContent += $"removed chapter {chapter.Title} succeed.";
                    DisplayContent += "\n";

                    Console.WriteLine($"removed chapter {chapter.Title} succeed.");
                }
                else
                {
                    Console.WriteLine("removed chapter {chapter.Title} failed!");
                }
            }

        }

        private async void OnUpdateDataRaised()
        {
            Console.WriteLine("Update Data");
            string uri = Addresses.BooksApi;
            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string test = response.Content.ReadAsStringAsync().Result;
                var chapters = JasonToEnumableConverter<BookChapter>(test);
                var chapter = chapters.FirstOrDefault(c => c.Title == "Zeiss");
                if (chapter != null)
                {
                    chapter.Number = 32;
                    chapter.Title = "Windows Apps";
                    //await Client.PutAsync(Addresses.BooksApi + chapter.Id, chapter);

                    string json = JsonConvert.SerializeObject(chapter);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage resp = await Client.PutAsync(uri + chapter.Id, content);
                    Console.WriteLine($"status from PUT {resp.StatusCode}");
                    resp.EnsureSuccessStatusCode();

                    DisplayContent += $"updated Zeiss chapter to {chapter.Title} succeed.";
                    DisplayContent += "\n";

                    Console.WriteLine($"updated chapter {chapter.Title}");
                }
            }
        }

        private Servo _posServo = new Servo()
        {

        };
        //binding interface
        public Servo PosServo
        {
            get
            {
                return _posServo;
            }
            set
            {
                _posServo = value;
                OnPropertyChanged("PosServo");

            }
        }
        private void UpdatePosServo()
        {
            if (PosServo == null) return;
            ReflectorTextColor = "#FFFFFF";
            Color1 = "#FFFFFF";
            Color2 = "#FF0000";
            Color3 = "#FFFFFF";
            UpdateServo(PosServo, "Servo");
            Brightness = PosServo.Position;
        }

        private Servo _posChanger;
        //binding interface
        public Servo PosChanger
        {
            get
            {
                return _posChanger;
            }
            set
            {
                _posChanger = value;
                OnPropertyChanged("PosChanger");
            }
        }
        private void UpdatePosChanger(short positon)
        {
            if (PosChanger == null) return;
            PosChanger.Position = positon;
            UpdateServo(PosChanger, "PosChanger");
            RLTL = positon;
        }

        private async void UpdateServo(Servo data, string childuri)
        {
            Console.WriteLine("Update Data");
            string uri = Addresses.Can29Address;

            var servo = new Servo();
            if (servo != null)
            {
                servo.CanAddr = data.CanAddr;
                servo.Mode = data.Mode;
                servo.Position = data.Position;

                string json = JsonConvert.SerializeObject(servo);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await Client.PutAsync(uri + childuri, content);
                Console.WriteLine($"status from PUT {resp.StatusCode}");
                resp.EnsureSuccessStatusCode();

                Console.WriteLine($"updated succeed.");
            }
        }

        //how to use:
        //int result = GetCan29Data(xxxx).Result;
        private async Task<short> GetCan29Data(string childUri)
        {
            try
            {
                string Uri = Addresses.Can29Address;

                HttpResponseMessage response = await Client.GetAsync(Uri + childUri);
                if (response.IsSuccessStatusCode)
                {
                    string test = response.Content.ReadAsStringAsync().Result;
                    return JasonToTypeConverter<short>(test);
                }

                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        //if result not right,change to async&&await
        //Following also has eventhandle, maybe not need this
        //just return is OK
        private async void GetObjectRaised()
        {
            ObjectPosition = await GetCan29Data("Object");
        }

        private async void GetReflectorRaised()
        {
            ReflectorPosition = await GetCan29Data("Reflector");
        }

        private async void GetBrightnessRaised()
        {
            Brightness = await GetCan29Data("Brightness");
            PosServo = new Servo()
            {
                CanAddr = 0x29,
                Position = (short)Brightness,
                Mode = 2
            };
        }

        private async void GetRLTLRaised()
        {
            RLTL = await GetCan29Data("RLTL");
            PosChanger = new Servo()
            {
                CanAddr = 0x1f,
                Position = (short)RLTL,
                Mode = 2
            };
        }
        private async void OnGetDataRaised()
        {
            try
            {
                string Uri = Addresses.BooksApi;

                HttpResponseMessage response = await Client.GetAsync(Uri);
                if (response.IsSuccessStatusCode)
                {
                    string test = response.Content.ReadAsStringAsync().Result;
                    Books = JasonToEnumableConverter<BookChapter>(test);
                }

                DisplayBooksInConsole();
                DisplayBooksInMainWindow();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //This way is also OK
        private void OnGetDataRaised1()
        {
            try
            {
                string Uri = Addresses.BooksApi;

                //创建一个异步GET请求，当请求返回时继续处理
                Client.GetAsync(Uri).ContinueWith(
                    (requestTask) =>
                    {
                        HttpResponseMessage response = requestTask.Result;

                        // 确认响应成功，否则抛出异常  
                        response.EnsureSuccessStatusCode();

                        // 异步读取响应为字符串  
                        //response.Content.ReadAsStringAsync().ContinueWith(
                        //(readTask) => Console.WriteLine(readTask.Result));
                        response.Content.ReadAsStringAsync().ContinueWith(
                                (readTask) => Books = JasonToEnumableConverter<BookChapter>(readTask.Result));
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void OnAddDataRaised()
        {
            Console.WriteLine("Add Data");
            BookChapter chapter = new BookChapter
            {
                Number = 42,
                Title = "Zeiss",
                Pages = 35
            };

            string json = JsonConvert.SerializeObject(chapter);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = await Client.PostAsync(Addresses.BooksApi, content);
            Console.WriteLine($"status from POST {resp.StatusCode}");
            resp.EnsureSuccessStatusCode();
            Console.WriteLine($"added resource at {resp.Headers.Location}");

            chapter = JasonToTConverter<BookChapter>(resp.Content.ReadAsStringAsync().Result);

            DisplayContent += $"added chapter {chapter.Title} with id {chapter.Id}";
            DisplayContent += "\n";
            Console.WriteLine($"added chapter {chapter.Title} with id {chapter.Id}");
        }

        private void OnCallBackRaised()
        {
            Console.WriteLine("success");
        }
        private async void OnLoadRaised()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Addresses.BaseAddress);



            CloseConnection(_can29Connection);
            _can29Connection = new HubConnectionBuilder()
                        .WithUrl(new Uri(Addresses.Can29HubAddress))
                        .WithConsoleLogger()
                        .Build();
            _can29Connection.Closed += HubConnectionClosed;

            _can29Connection.On<string, int>("BroadcastMessage", OnCan29MessageReceived);

            try
            {
                if (_can29Connection != null)
                {
                    await _can29Connection.StartAsync();
                }
            }
            catch (HttpRequestException ex)
            {
                _messagingService.ShowMessage(ex.Message);
            }

            Console.WriteLine("Load Client Succeed");

            GetObjectRaised();
            GetReflectorRaised();
            GetBrightnessRaised();
            GetRLTLRaised();

        }

        private void OnCan29MessageReceived(string changedParam, int value)
        {
            Console.WriteLine("Parameter:" + changedParam + "   Value is: " + value);
            App.Current.Dispatcher.Invoke(() =>
            {
                switch (changedParam)
                {
                    case "Objective":
                        ReflectorTextColor = "#FFFFFF";
                        Color1 = "#FF0000";
                        Color2 = "#FFFFFF";
                        Color3 = "#FFFFFF";
                        ObjectPosition = (short)value;
                        break;
                    case "Reflector":
                        ReflectorTextColor = "#FF0000";
                        Color1 = "#FFFFFF";
                        Color2 = "#FFFFFF";
                        Color3 = "#FFFFFF";
                        ReflectorPosition = (short)value;
                        break;
                    case "Brightness":
                        //ReflectorTextColor = "#FFFFFF";
                        //Color1 = "#FFFFFF";
                        //Color2 = "#FF0000";
                        //Color3 = "#FFFFFF";
                        Brightness = (short)value;
                        break;
                    case "RLTL":
                        ReflectorTextColor = "#FFFFFF";
                        Color1 = "#FFFFFF";
                        Color2 = "#FFFFFF";
                        Color3 = "#FF0000";
                        RLTL = (short)value;
                        break;
                    default:
                        break;
                }
            });
        }

        private void OnCan29MessageReceived(string changedParam, short value)
        {
            Console.WriteLine("Event received");
            //It seems do not need to get from server, except first time(before binding).
            App.Current.Dispatcher.Invoke(() =>
           {
               switch (changedParam)
               {
                   case "Objective":
                       ObjectPosition = value;
                       break;
                   case "Reflector":
                       ReflectorPosition = value;
                       break;
                   case "Brightness":
                       Brightness = value;
                       break;
                   case "RLTL":
                       RLTL = value;
                       break;
                   default:
                       break;
               }
           });
        }

        private void ReadChapters()
        {
            Console.WriteLine(nameof(ReadChapters));
            var client = new BookChapterClient(Addresses.BaseAddress);
            IEnumerable<BookChapter> chapters = client.GetAll(Addresses.BooksApi);

            foreach (BookChapter chapter in chapters)
            {
                Console.WriteLine(chapter.Title);
            }
            Console.WriteLine();
        }

        private static async Task ReadChapterAsync()
        {
            Console.WriteLine(nameof(ReadChapterAsync));
            var client = new BookChapterClient(Addresses.BaseAddress);
            var chapters = await client.GetAllAsync(Addresses.BooksApi);
            Guid id = chapters.First().Id;
            BookChapter chapter = await client.GetAsync(Addresses.BooksApi + id);
            Console.WriteLine($"{chapter.Number} {chapter.Title}");
            Console.WriteLine();
        }

        private static async Task ReadNotExistingChapterAsync()
        {

            Console.WriteLine(nameof(ReadNotExistingChapterAsync));
            string requestedIdentifier = Guid.NewGuid().ToString();
            try
            {
                var client = new BookChapterClient(Addresses.BaseAddress);
                BookChapter chapter = await client.GetAsync(Addresses.BooksApi + requestedIdentifier.ToString());
                Console.WriteLine($"{chapter.Number} {chapter.Title}");
            }
            catch (HttpRequestException ex) when (ex.Message.Contains("404"))
            {
                Console.WriteLine($"book chapter with the identifier {requestedIdentifier} not found");
            }
            Console.WriteLine();
        }

        private static async Task ReadXmlAsync()
        {
            Console.WriteLine(nameof(ReadXmlAsync));
            var client = new BookChapterClient(Addresses.BaseAddress);
            XElement chapters = await client.GetAllXmlAsync(Addresses.BooksApi);
            Console.WriteLine(chapters);
            Console.WriteLine();
        }

        private static async Task AddChapterAsync()
        {
            Console.WriteLine(nameof(AddChapterAsync));
            var client = new BookChapterClient(Addresses.BaseAddress);
            BookChapter chapter = new BookChapter
            {
                Number = 42,
                Title = "ASP.NET Web API",
                Pages = 35
            };
            chapter = await client.PostAsync(Addresses.BooksApi, chapter);
            Console.WriteLine($"added chapter {chapter.Title} with id {chapter.Id}");
            Console.WriteLine();
        }

        private static async Task UpdateChapterAsync()
        {
            Console.WriteLine(nameof(UpdateChapterAsync));
            var client = new BookChapterClient(Addresses.BaseAddress);
            var chapters = await client.GetAllAsync(Addresses.BooksApi);
            var chapter = chapters.SingleOrDefault(c => c.Title == "Windows Store Apps");
            if (chapter != null)
            {
                chapter.Number = 32;
                chapter.Title = "Windows Apps";
                await client.PutAsync(Addresses.BooksApi + chapter.Id, chapter);
                Console.WriteLine($"updated chapter {chapter.Title}");
            }

            Console.WriteLine();
        }

        private static async Task RemoveChapterAsync()
        {
            Console.WriteLine(nameof(RemoveChapterAsync));
            var client = new BookChapterClient(Addresses.BaseAddress);
            var chapters = await client.GetAllAsync(Addresses.BooksApi);
            var chapter = chapters.SingleOrDefault(c => c.Title == "ASP.NET Web Forms");
            if (chapter != null)
            {
                await client.DeleteAsync(Addresses.BooksApi + chapter.Id);
                Console.WriteLine($"removed chapter {chapter.Title}");
            }

            Console.WriteLine();
        }

        private IEnumerable<T> JasonToEnumableConverter<T>(string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }

        private T JasonToTypeConverter<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        private T JasonToTConverter<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string strPropertyInfo)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(strPropertyInfo));
            }
        }
    }
}
