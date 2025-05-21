using ACG_Api.model.General;
using ACG_Api.model;
using System.Text.Json.Serialization;
namespace ACG_Api.model
{
    interface I2D
    {
        int Id { get; set; }
        int NumberGroup { get; set; }
        string NameGroup { get; set; }
    }

    interface I2DOtherInfo
    {
        string? Pibs { get; set; }
        string Address { get; set; }
        double? Area { get; set; }
        bool? isAlert { get; set; }
        DateTime? DateCloseDepartment { get; set; }
    }

    public class Group : I2D, I2DOtherInfo, IDelete, ICreate
    {
        public int Id { get; set; }

        public int NumberGroup {get;set;}
        public string NameGroup {get; set;}

        public string? Pibs { get; set; } = "ПІП";
         public string Address { get; set; } = "Адреса";
        public double? Area { get; set; } = 1.0;
        public bool? isAlert { get; set; } = false;
        public DateTime? DateCloseDepartment { get; set; } = DateTime.MinValue;

        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public string CreatedBy { get; set; } = "";
        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;
        [JsonIgnore]
        public DateTime DeleteTime { get; set; } = DateTime.MinValue;
        [JsonIgnore]
        public string DeletedBy { get; set; } = "";
        [JsonIgnore]
        public ICollection<Counterparty> Counterparty { get; } = new List<Counterparty>();
        [JsonIgnore]
        public ICollection<Guard> Guard { get; } = new List<Guard>();
        [JsonIgnore]
        public ICollection<Sublease> Sublease { get; } = new List<Sublease>();
    }
}
