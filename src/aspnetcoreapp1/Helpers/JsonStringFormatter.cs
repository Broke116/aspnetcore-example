using Newtonsoft.Json;

namespace aspnetcoreapp1.Helpers
{
    public class JsonStringFormatter : IStringFormatter
    {
        private readonly IGreeter _greeter;

        public JsonStringFormatter(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public string FormatIt(object input)
        {
            return JsonConvert.SerializeObject(new { Greeting = _greeter.SendGreeting("Admin"), Content = input });
        }
    }
}
