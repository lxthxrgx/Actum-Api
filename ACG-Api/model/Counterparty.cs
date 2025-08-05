// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Text.Json.Serialization;
// using System.Threading.Tasks;
// using ACG_Api.model.General;

// namespace ACG_Api.model{
//     public class Counterparty : IDelete, ICreate
//     {
//         public int Id {get; set;}

//         public int Id_Group { get; set; }

//         [JsonIgnore]
//         public required Group Group { get; set; }

//         public required string Fullname {get; set;}
//         public required string Address {get; set;}
//         public required string Edryofop {get; set;}
//         public required string BanckAccount {get; set;}
//         public required string Director {get; set;}
//         public required string ResPerson {get; set;}
//         public required string Phone {get; set;}
//         public required string Email {get; set;}
//         public required string Status {get; set;}

//         [JsonIgnore]
//         public DateTime CreatedAt { get; set; } = DateTime.Now;
//         [JsonIgnore]
//         public required string CreatedBy { get; set; }
//         [JsonIgnore]
//         public bool IsDeleted { get; set; } = false;
//         [JsonIgnore]
//         public DateTime DeleteTime { get; set; } = DateTime.UtcNow;
//         [JsonIgnore]
//         public required string DeletedBy { get; set; }
//     }
// }