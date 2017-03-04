namespace aspnetcoreapp1.Helpers
{
    public class GreetMessage : IGreeter
    {
        public string SendGreeting(string msg)
        {
            return "Hello " + msg;
        }
    }
}