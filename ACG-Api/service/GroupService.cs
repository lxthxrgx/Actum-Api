using Microsoft.EntityFrameworkCore;
using Actum_Api.Database;
using Models.model;

namespace Actum_Api.service
{
    public class GroupService
    {
        private readonly DatabaseModel _context;

        public GroupService(DatabaseModel context) { _context = context; }

        public async Task<IEnumerable<Groups>> GetAll()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Groups> GetById(int id)
        {
            if (id == 0)
                throw new Exception($"Id can't be null. Now id = {id}.");

            Groups data = await _context.Groups.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null)
                throw new Exception($"data by this id is null: {id}, NumberGroup: {data.NumberGroup}");

            return data;
        }
    }
}
