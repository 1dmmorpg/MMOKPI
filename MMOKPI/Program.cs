using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace MMOKPI
{
    class Program
    {
        static ITelegramBotClient botClient = new TelegramBotClient("687056656:AAHq_gtma0pgLCQmDMHcgNhvnC3ZgeZdxn4");

        static void Main(string[] args)
        {
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Hello, World! I am bot {me.Id} and my name is {me.FirstName}");
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            Message msg = e.Message;

            if (msg != null)
            {
                Console.WriteLine($"Received a message {msg.Text} in chat with {msg.Chat.Username}");

                await botClient.SendTextMessageAsync(
                    chatId: msg.Chat.Id,
                    text: $"Hello {msg.From.FirstName}!");
            }
        }
    }
}
