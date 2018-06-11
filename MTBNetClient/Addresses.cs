using System;

namespace MTBNetClient
{
    public static class Addresses
    {
        public static string BaseAddress;
        public static string BooksApi;
        public static string SignalRAddress;
        public static string Can29HubAddress;
        public static string Can29Address;
        public static string MTBConnectionHubAddress;
        public static string MTBAPIHubAddress;
        public static string MTBConnectionAddress;



        static Addresses()
        {
            BaseAddress = GetAddressFromLocal();
            SignalRAddress = BaseAddress + "chatHub";
            Can29HubAddress = BaseAddress + "can29Hub";
            Can29Address = BaseAddress + "api/Can29/";
            MTBConnectionAddress = BaseAddress + "api/MTBConnection/";
            BooksApi = BaseAddress + "api/BookChapters/";
            MTBConnectionHubAddress = BaseAddress + "connectionHub";
            MTBAPIHubAddress = BaseAddress + "apiHub";
        }

        private static string GetAddressFromLocal()
        {
            //client IP read currentDirectory\Configure\Configure.xml
            string currentDirectory = System.Environment.CurrentDirectory;
            string xmlPath = currentDirectory + @"\Configure\Configure.xml";
            string baseAddress = XmlHelper.ReadXmlReturnNode(xmlPath, "ServerIP");
            Console.WriteLine("Current Server address is:{0}", baseAddress);
            return baseAddress;
        }
    }
}
