using ACG_Api.Database;
using Microsoft.EntityFrameworkCore;

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
    }
}