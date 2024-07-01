using Esports_Org_Manager.Data;
using Esports_Org_Manager.Entities;
using Microsoft.EntityFrameworkCore;

namespace Esports_Org_Manager.Services
{
    public class OrganizationService
    {
        private readonly DataContext _context;

        public OrganizationService(DataContext context)
        {
            _context = context;
        }

        public async Task SaveOrganization(Organization organization)
        {
            var res = await CheckUniqueName(organization.name);
            if (res == organization) throw new ArgumentException(nameof(organization));
            await _context.AddAsync(organization);
            await _context.SaveChangesAsync();
        }

        public async Task<Organization> CheckUniqueName(string name)
        {
            return await _context.Organizations.FirstAsync(x => x.name == name);
            
        }

        public async Task<List<Organization>> GetAllOrganizations()
        {
            var orgs = await _context.Organizations.ToListAsync();

            return orgs;
        }
        
    }
}
