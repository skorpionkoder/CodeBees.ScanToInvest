namespace CodeBees.ScanToInvest.Vision.API.Entities
{
    public class Result
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public string Market { get; set; }
        public string Locale { get; set; }
        public string Primary_Exchange { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public string Currency_Name { get; set; }
        public string Cik { get; set; }
        public string Composite_Figi { get; set; }
        public string Share_Class_Figi { get; set; }
        public DateTime Last_Updated_Utc { get; set; }
        public string Source_Feed { get; set; }
    }

    public class StocksResponse
    {
        public List<Result> Results { get; set; }
        public string Status { get; set; }
        public string Request_Id { get; set; }
        public int Count { get; set; }
        public string Next_Url { get; set; }
    }

}
