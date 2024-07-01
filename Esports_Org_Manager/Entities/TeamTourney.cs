
namespace Esports_Org_Manager.Entities
{
    /// <summary>
    /// class derived from abstract class tourney
    /// </summary>
    public class TeamTourney : Tourney
    {
        private int _playerChangePointsPenalty;
        private IDictionary<int,int> _placements = new Dictionary<int,int>();
        private IList<Team> _teams = new List<Team>();
        public IList<Team> teams { get => _teams.AsReadOnly(); private set => _teams = value; }

        public int playerChangePointsPenalty 
        { 
            get => _playerChangePointsPenalty;
            set
            { 
                if (value  < 0) throw new ArgumentException(nameof(value));
                _playerChangePointsPenalty = value; 
            }
        }

        // Dictionary<Team.id,points>
        public IDictionary<int, int> placements { get => _placements.OrderBy(x => x.Value).ToDictionary().AsReadOnly(); private set => _placements = value; }
        
        private TeamTourney() : base() { }

        /// <summary>
        /// constructor of class TeamTourney
        /// </summary>
        /// <param name="playerChangePointsPenalty"></param>
        /// <param name="state"></param>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <param name="format"></param>
        /// <param name="awardPool"></param>
        /// <param name="procentPerPlace"></param>
        /// <param name="organizerDiscriminator"></param>
        public TeamTourney(int playerChangePointsPenalty, TourneyState state, string name, DateTime date, string format, double awardPool, List<int> procentPerPlace, OrganizerType organizerDiscriminator) : base(state, name, date, format, awardPool, procentPerPlace, organizerDiscriminator)
        {
            this.playerChangePointsPenalty = playerChangePointsPenalty;
        }

        /// <summary>
        /// add team to competition
        /// </summary>
        /// <param name="team"></param>
        public void AddTeam(Team team)
        {
            if (_teams.Contains(team)) return;
            _placements.Add(team.id, 0);
            _teams.Add(team);
            team.AddTourney(this);
        }
        /// <summary>
        /// remove team from competition
        /// </summary>
        /// <param name="team"></param>
        public void RemoveTeam(Team team)
        {
            if (!_teams.Contains(team)) return;
            _placements.Remove(team.id);
            _teams.Remove(team);
            team.RemoveTourney(this);
        }

        /// <summary>
        /// set points of a team in competition
        /// </summary>
        /// <param name="team"></param>
        /// <param name="points"></param>
        /// <exception cref="ArgumentException"></exception>
        public void SetTeamPoints(Team team, int points)
        {
            if (!_placements.ContainsKey(team.id)) throw new ArgumentException();
            _placements[team.id] = points - _playerChangePointsPenalty;
        }
    }
}
