namespace Mandrill
{
    public class Search
    {
        public string query { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public string[] tags { get; set; }
        public string[] senders { get; set; }
        public string limit { get; set; }
    }
}
