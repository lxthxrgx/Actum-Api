namespace Models.model
{
    public class Groups
    {
        public int Id { get; private set; }
        public int NumberGroup {get; private set;}
        public string NameGroup { get; private set; } = "Назва групи";
        public string Address { get; private set; } = "Адреса";
        public double Area { get; private set; } = 1.0;
        public bool IsAlert { get; private set; } = false;
        public DateTime DateCloseDepartment { get; set; } = DateTime.MinValue;
        public ICollection<Counterparty> Counterparty { get; set; } = new List<Counterparty>();
        public ICollection<Guard> Guard { get; set; } = new List<Guard>();
        public ICollection<Sublease> Sublease { get; set; } = new List<Sublease>();
    }
}