public class ConsoleMessage : IUI
{
    
    public void PrintMessage(string message, string messageType)
    {
         if(messageType == "error")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message+"\n");
            Console.ResetColor();
        }
        else if(messageType == "success")
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(message+"\n");
            Console.ResetColor();
        }
        else if (messageType == "info")
        {
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine(message+"\n");
            Console.ResetColor();
        }
    }
}