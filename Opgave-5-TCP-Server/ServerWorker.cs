using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib.Model;

namespace Opgave_5_TCP_Server
{
    internal class ServerWorker
    {
        private static List<Book> books = new List<Book>
        {
            new Book("Harry Potter", "J.K. Rowling", 99, "1234567890123"),
            new Book("Ringenes Herre", "J.K.K. Tolkien", 80, "9876543210987"),
            new Book("Da Vinci Mysteriet", "Dan Brown", 70, "5297430972567"),
        };
        public ServerWorker()
        {
        }

        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 4646);
            server.Start();

            while (true)
            {
                Task.Run(() =>
                {
                    TcpClient socket = server.AcceptTcpClient();
                    DoClient(socket);
                });
            }
        }

        public void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                string str = sr.ReadLine();

                if (str != null)
                {
                    var strings = str.Split('/');

                    switch (strings[0].ToLower())
                    {
                        case "getall":
                            books.ForEach(sw.WriteLine);
                            break;
                        case "get":
                            sw.WriteLine(books.Find(i => i.Isbn13 == strings[1]));
                            break;
                        case "save":
                            books.Add(new Book(strings[1], strings [2], Convert.ToInt32(strings[3]), strings[4]));
                            books.ForEach(sw.WriteLine);
                            break;
                        default:
                            sw.WriteLine("Error. Please choose GetAll, Get or save");
                            break;
                    }
                }
                sw.Flush();
            }
        }
    }
}
