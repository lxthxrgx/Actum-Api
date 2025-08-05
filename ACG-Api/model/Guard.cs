// using System.Data;
// using System.Text.RegularExpressions;
// using ACG_Api.model.General;
// using Models;

// namespace ACG_Api.model
// {
//     public interface IGuard
//     {

//     }

//     public class Guard
//     {
//         public int Id { get; set; }
//         public int GroupId { get; set; }
//         public string Group GroupTable { get; set; }
//         public string address { get; set; }
//         public string OhronnaComp { get; set; }
//         public string NumDog { get; set; }
//         public string? NumDog2 { get; set; }
//         public DateTime StrokDii { get; set; }
//         public DateTime? StrokDii2 { get; set; }
//         public string? ResPerson { get; set; }
//         public string? Phone { get; set; }
//         public string? Email { get; set; }

//         public ICollection<PathToFilesGuard> PathToFilesGuard { get; } = new List<PathToFilesGuard>();
//     }
// }