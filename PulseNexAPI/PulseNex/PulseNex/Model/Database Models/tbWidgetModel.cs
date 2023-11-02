namespace PulseNex.Model.Database_Models
{
    public class tbWidgetModel
    {
        public int GUIDWidget { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string ImageId { get; set; }
    }

    public class tbWidgetInsertModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string ImageId { get; set; }
    }

    public class tbWidgetUpdateModel
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string ImageId { get; set; }
    }
}
