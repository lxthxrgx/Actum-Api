using Actum_Api.Database;
using Microsoft.EntityFrameworkCore;
using Models.model;
using static Actum_Api.Controllers.ControllerGroup.groupController;

namespace Actum_Api.service
{
    public class GroupService
    {
        private readonly DatabaseModel _context;

        public GroupService(DatabaseModel context) { _context = context; }

        public async Task<Groups?> GetById(int id)
        {
            if (id == 0)
                Console.WriteLine("Id cant be 0");
            return await _context.Groups.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<List<Groups?>> Get()
        {
            List<Groups> data = await _context.Groups.ToListAsync();
            if(data == null)
            {
                Console.WriteLine("No groups found");
            }
            return data;
        }

        public async Task<Groups> Create(GroupPostDto group)
        {
            Groups dataToAdd = new Groups
            {
                Id = 0,
                NumberGroup = group.NumberGroup,
                NameGroup = group.NameGroup,
                Address = group.Address,
                Area = group.Area,
                IsAlert = group.IsAlert
            };
            _context.Groups.Add(dataToAdd);
            await  _context.SaveChangesAsync();
            return dataToAdd;
        }

        public async Task<List<int>> GetNumberGroups()
        {
            List<int> numberGroups = await _context.Groups
                .Select(g => g.NumberGroup)
                .Distinct()
                .ToListAsync();
            return numberGroups;

        }
    }
}
