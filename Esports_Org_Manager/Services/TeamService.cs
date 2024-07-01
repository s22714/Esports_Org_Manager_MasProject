using Esports_Org_Manager.Data;
using Esports_Org_Manager.Entities;
using Microsoft.EntityFrameworkCore;

namespace Esports_Org_Manager.Services
{
    public class TeamService
    {
        private readonly DataContext _context;

        public TeamService(DataContext context)
        {
            _context = context;
        }

        public async Task SaveNewMembership(Membership membership)
        {
            
            if (membership.startDate > DateTime.Now) throw new ArgumentException(nameof(membership));
            if (membership.endDate < DateTime.Now || membership.endDate <= membership.startDate) throw new ArgumentException(nameof(membership));
            
            membership.team.CheckTeamTourneyJoinAvailability();
            await _context.Memberships.AddAsync(membership);
            await _context.SaveChangesAsync();
            
            
        }

        public async Task SaveNewTeam(Team team)
        {
            var res = await CheckUniqueName(team);
            if(res == team) throw new ArgumentException(nameof(team));
            team.CheckTeamTourneyJoinAvailability();
            await _context.AddAsync(team);
            await _context.SaveChangesAsync();
        }
        
        public async Task<List<Team>> GetAllTeams()
        {
            var teams = await _context.Teams.Include(m => m.memberships).ThenInclude(m => m.employee).ToListAsync();
            foreach (var team in teams)
            {
                team.CheckTeamTourneyJoinAvailability();
            }
            return teams;
        }
        
        public async Task<List<Membership>> GetAllMemberships()
        {
            var mems = await _context.Memberships.Include(m => m.team).Include(m => m.employee).ToListAsync();

            return mems;
        }

        public async Task<Team> CheckUniqueName(Team team)
        {
            return await _context.Teams.Where(x => x.organizationName == team.organizationName).FirstAsync(x => x.name == team.name);
        }

        public async Task<AvailabilityStatus> CheckTeamTourneyQualificationAbility(Team team)
        {
            var t = await _context.Teams.FirstAsync(x => x.id == team.id);
            if (t != null) throw new ArgumentException(nameof(t));

            var mems = await _context.Memberships.Where(x => x.team == t).ToListAsync();
            int result = 0;
            foreach (var mem in mems)
            {
                var emp = await _context.Employees.FirstAsync(x => x.id == mem.employee.id);
                if (emp.status == AvailabilityStatus.available)
                {
                    result++;
                }
            }
            if(result < team.minimalNumberOfPlayers)
            {
                return AvailabilityStatus.unavailable;
            }
            return AvailabilityStatus.available;
        }

        public async Task<Team> GetTeamWithDetailsWithID(int id)
        {
            return await _context.Teams.Include(x => x.organization)
                .Include(x => x.memberships).ThenInclude(x => x.employee)
                .Include(x => x.memberships).ThenInclude(x => x.contracts).FirstAsync(x => x.id == id);
        }
    }
}
