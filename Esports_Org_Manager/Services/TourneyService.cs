using Esports_Org_Manager.Data;
using Esports_Org_Manager.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Esports_Org_Manager.Services
{
    public class TourneyService
    {
        private readonly DataContext _context;

        public TourneyService(DataContext context)
        {
            _context = context;
        }
        public async Task<TeamTourney> GetTeamTourney(int id)
        {
            return await _context.TeamTourneys.Where(i => i.id == id).Include(x => x.independentOrganizer).Include(x => x.teams).FirstOrDefaultAsync();
        }
        public async Task<SoloTourney> GetSoloTourney(int id)
        {
            return await _context.SoloTourneys.Where(i => i.id == id).Include(x => x.independentOrganizer).Include(x => x.employees).FirstOrDefaultAsync();
        }
        public async Task<List<Tourney>> GetAllTourneysWithDetails()
        {
            var sololist = await _context.SoloTourneys.Include(x => x.independentOrganizer).ToListAsync();
            var teamlist = await _context.TeamTourneys.Include(x => x.independentOrganizer).ToListAsync();

            var result = new List<Tourney>();
            result.AddRange(sololist);
            result.AddRange(teamlist);

            return result;
        }
        public async Task<List<Tourney>> GetAllTourneys()
        {
            
            var sololist = await _context.SoloTourneys.ToListAsync();
            var teamlist = await _context.TeamTourneys.ToListAsync();

            var result = new List<Tourney>();
            result.AddRange(sololist);
            result.AddRange(teamlist);

            return result;
        }

        public async Task<List<IndependentContractor>> GetAllContractors()
        {
            return await _context.IndependentContractos.ToListAsync();
        }

        public async Task SaveNewSoloTourney(SoloTourney tourney)
        {
            await _context.Tourneys.AddAsync(tourney);
            await _context.SaveChangesAsync();
        }
        public async Task SaveNewTeamTourney(TeamTourney tourney)
        {
            await _context.Tourneys.AddAsync(tourney);
            await _context.SaveChangesAsync();
        }

        public async Task SaveNewIndepCon(IndependentContractor independentContractor)
        {
            await _context.IndependentContractos.AddAsync(independentContractor);
            await _context.SaveChangesAsync();
        }
    }
}
