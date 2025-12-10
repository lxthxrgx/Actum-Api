namespace Models.model
{
    public class Groups
    {
        public int Id { get; set; }
        public int NumberGroup {get; set;}
        public string NameGroup { get; set; } = "Назва групи";
        public string Address { get; set; } = "Адреса";
        public double Area { get; set; } = 1.0;
        public bool IsAlert { get; set; } = false;
        public DateTime DateCloseDepartment { get; set; } = DateTime.MinValue;
        public ICollection<Counterparty> Counterparty { get; set; } = new List<Counterparty>();
        public ICollection<Guard> Guard { get; set; } = new List<Guard>();
        public ICollection<Sublease> Sublease { get; set; } = new List<Sublease>();
    }
}