namespace Actum_Api.model.DTO
{
    public class CreateGroupDto
    {
        public int NumberGroup { get; set; }
        public string NameGroup { get; set; } = null!;
        public string? Pibs { get; set; }
        public string Address { get; set; } = null!;
        public double? Area { get; set; }
        public bool? IsAlert { get; set; }
        public DateTime? DateCloseDepartment { get; set; }
        public string CreatedBy { get; set; } = null!;
    }
}
