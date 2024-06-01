using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace ConsoleLoader
{
    internal class Program
    {

        public static void setTitle()
        {
            Console.Clear();
            Console.WriteLine("\n" +
                "__  _  ________" + "\n" +
                "\\ \\/ \\/ / ___ /    WebHook sender by pgshka" + "\n" +
                " \\     /\\___ \\     V.01" + "\n" +
                "  \\/\\_//____  >" + "\n" +
                "            \\/ " + "\n");
        }
        public static string getText(string title)
        {
            Console.WriteLine(title);
            string value = Console.ReadLine();
            setTitle();
            return value;
        }
        public static int getInt(string title)
        {
            Console.WriteLine(title);
            int value = Convert.ToInt32(Console.ReadLine());
            setTitle();
            return value;
        }

        static void Main(string[] args)
        {
            setTitle();
            string url = getText("Webhook: ");
            string text = getText("Text: ");
            int max = getInt("Count: ");

            for (int i = 0; i <= max; i++)
            {
                setTitle();
                try
                {
                    Console.WriteLine("Ready: " + i + "/" + max);
                    WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/json");
                    string payload = "{\"content\": \"" + text + "\"}";
                    client.UploadData(url, Encoding.UTF8.GetBytes(payload));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            setTitle();

            Console.WriteLine("End, press any key to exit..");
            Console.ReadKey();
        }
    }
}
