using ACG_Api.Database;
using Microsoft.EntityFrameworkCore;
namespace ACG_Api.service
{
    public interface IGroupService
    {
        
    }

    public class GroupService : IGroupService
    {
        private readonly DatabaseModel _context;

        public GroupService(DatabaseModel context) { _context = context; }

        public async Task<IEnumerable<Group>> GetAll()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group> GetById(int id)
        {
            if (id == 0)
                throw new Exception($"Id can't be null. Now id = {id}.");

            Group data = await _context.Groups.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null)
                throw new Exception($"data by this id is null: {id}, NumberGroup: {data.NumberGroup}");

            return data;
        }
    }
}
