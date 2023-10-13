namespace CodeBees.ScanToInvest.Vision.API.Entities
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class BoundingPoly
    {
        public List<Vertex> Vertices { get; set; }
    }

    public class Google
    {
        public string Status { get; set; }
        public List<Item> Items { get; set; }
        public double Cost { get; set; }
    }

    public class Item
    {
        public BoundingPoly Bounding_Poly { get; set; }
        public string Description { get; set; }
        public double Score { get; set; }
    }

    public class VisionResponse
    {
        public Google Google { get; set; }
    }

    public class Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

}