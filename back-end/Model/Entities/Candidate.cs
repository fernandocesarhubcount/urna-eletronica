namespace Model.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ViceName { get; set; }
        public int Legend { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
