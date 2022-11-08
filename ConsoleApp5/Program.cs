using System;
namespace CA2
{
    class Based
    {
        public void BasedDouble(double value)
        {
            Console.WriteLine(value);
        }
        public void BasedInt(int value)
        {
            Console.WriteLine(value);
        }
        public void BasedChar(char value)
        {
            Console.WriteLine(value);
        }
    }
    interface ITarget
    {
        void ClientDouble(double value);
        void ClientInt(int value);
        void ClientChar(char value);
    }
    class Adapter : Based, ITarget
    {
        public void ClientDouble(double value)
        {
            BasedDouble(value);
        }
        public void ClientInt(int value)
        {
            BasedInt(value * 2);
        }
        public void ClientChar(char value)
        {
            for (int i = 0; i < 5; i++)
                BasedChar(value);
        }
    }
    class Client
    {
        private ITarget client;

        public Client(ITarget _client)
        {
            client = _client;
        }
        public void Show()
        {
            client.ClientDouble(3.14);
            client.ClientInt(228);
            client.ClientChar('R');
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Adapter adapter = new Adapter();
            Client client = new Client(adapter);
            client.Show();
        }
    }
}
