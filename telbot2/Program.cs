using System;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Awesome
{
    class Program
    {
        static ITelegramBotClient botClient;

        static void Main()
        {
            //настроить github
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            /*ServicePointManager.Expect100Continue = true;   
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;*/

            botClient = new TelegramBotClient("token");

            /*var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
                $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );*/

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "You said:\n" + e.Message.Text
                );
            }
            else Console.WriteLine("Ниче не получил!!!");
        }
    }
}
