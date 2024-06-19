namespace TelegramBotInteractiveMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InteractiveMenu();
        }

        static void InteractiveMenu()
        {
            string greetingText = "Welcome to our telegram bot!";
            string avaliableOptions = "Please choose the option:\n \t/start\n \t/help\n \t/info\n \t/exit\n";
            string? userName = null;
            string? echoValue = null;
            string? userAnswer;

            Console.WriteLine(greetingText);

            do
            {
                Console.WriteLine();
                Console.WriteLine(userName != null ? $"{userName},\n" + avaliableOptions + "\t/echo" : avaliableOptions);

                userAnswer = Console.ReadLine();

                if (!string.IsNullOrEmpty(userAnswer))
                {
                    string[] arr = userAnswer.Split(' ');
                    string option = arr[0];

                    if (option == "/echo")
                    {
                        userAnswer = option;
                        echoValue = string.Join(" ", arr[1..]);
                    }

                    Console.WriteLine();
                    Console.WriteLine(OutputText(userAnswer, userName, echoValue));

                    if (option == "/start")
                    {
                        userName = Console.ReadLine();
                    }
                }
            }
            while (userAnswer != "/exit");
        }
        static string OutputText(string? inputText, string? name, string? echoValue)
        {
            string helpText = "These are common commands:\n " +
                "\t/start \tAllows you to add your name\n" +
                "\t/help \tShows you avaliable commands\n" +
                "\t/info \tShows the version of the program and the date it was created\n" +
                "\t/exit \tExit the program\n" +
                "\t/echo \tThis option is only available if you have already entered your name.\n " +
                "The echo option allows you to enter your own text \n " +
                "Example: /echo Hi buddy!";
            string infoText = "version: 1.00, date of creation: 2024-06-03";

            string result = inputText switch
            {
                "/start" => "Please enter your name!",
                "/help" => name != null ? $"{name}, \n" + helpText : helpText,
                "/info" => name != null ? $"{name}, \n" + infoText : infoText,
                "/echo" => echoValue != null ? (name != null ? $"{name}, \n" + echoValue : echoValue) : "The text is empty!",
                "/exit" => name != null ? $"Bey! See you soon, {name}!" : "Bey! See you soon!",
                _ => name != null ? $"{name}, {inputText} option is not available!" : $"{inputText} option is not available!"
            };
            return result;
        }
    }
}