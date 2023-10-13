namespace CodeBees.ScanToInvest.Vision.API.Entities
{
    public class Address
    {
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postal_Code { get; set; }
    }

    public class Branding
    {
        public string Logo_Url { get; set; }
        public string Icon_Url { get; set; }
    }

    public class Results
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
        public double Market_Cap { get; set; }
        public string Phone_Number { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        public string Sic_Code { get; set; }
        public string Sic_Description { get; set; }
        public string Ticker_Root { get; set; }
        public string Homepage_Url { get; set; }
        public int Total_Employees { get; set; }
        public string List_Date { get; set; }
        public Branding Branding { get; set; }
        public long Share_Class_Shares_Outstanding { get; set; }
        public long Weighted_Shares_Outstanding { get; set; }
        public int Round_Lot { get; set; }
    }

    public class StockDetailResponse
    {
        public string Request_Id { get; set; }
        public Results Results { get; set; }
        public string Status { get; set; }
    }

}
