using ACG_Api.Database;
using Microsoft.EntityFrameworkCore;
using ACG_Api.model;

namespace ACG_Api.service{

    public class GuardService
    {
        private readonly DatabaseModel _context;
        public GuardService(DatabaseModel context)
        {
            _context = context;
        }
        public async Task<List<Guard>> Get()
        {
            return await _context.Guard.ToListAsync();
        }

        public async Task<Guard> GetById(int Id)
        {
            if (Id == 0)
                throw new ArgumentException("Id can't be 0", nameof(Id));

            var data = await _context.Guard.Where(x => x.Id == Id).SingleOrDefaultAsync();
            if (data == null)
                throw new InvalidOperationException($"Can't find data by this Id: {Id}");

            return data;
        }
    }
}