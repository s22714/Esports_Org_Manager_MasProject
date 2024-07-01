using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Esports_Org_Manager.Entities
{
    public enum AvailabilityStatus
    {
        available,
        unavailable
    }
    public class Team
    {
        private int _id;
        private string _name = null!;
        private string _gamePlayed = null!;
        private DateTime _creationDate;
        private string? _logo;
        private int _minimalAgeEligibility;
        private int _minimalNumberOfPlayers;
        private string _region = null!;
        private AvailabilityStatus _status;

        // organization foreign key
        public string? organizationName { get; set; }
        private Organization? _organization;
        private IList<TeamTourney> _tourneys = new List<TeamTourney>();
        private IList<Membership> _memberships = new List<Membership>();

        public string name 
        { 
            get => _name; 
            set 
            {
                if (_name ==  value) return;
                if (value == "") throw new ArgumentException(nameof(value));
                _name = value ?? throw new ArgumentNullException(nameof(value)); ; 
            }
        }
        public string gamePlayed 
        { 
            get => _gamePlayed; 
            set 
            {
                if (value == "") throw new ArgumentException();
                _gamePlayed = value ?? throw new ArgumentNullException(nameof(value)); 
            }
        }
        public DateTime creationDate 
        { 
            get => _creationDate; 
            set 
            { 
                if (value > DateTime.Now) throw new ArgumentException(nameof(value));
                _creationDate = value; 
            }
        }
        public string? logo 
        { 
            get => _logo; 
            set 
            {
                if (value == "") throw new ArgumentException(nameof(value));
                _logo = value; 
            }
        }
        public int minimalAgeEligibility 
        { 
            get => _minimalAgeEligibility; 
            set 
            { 
                if (value < 0) throw new ArgumentException(nameof(value));
                _minimalAgeEligibility = value; 
            } 
        }
        public string region 
        { 
            get => _region; 
            set 
            {
                if (value == "") throw new ArgumentException(nameof(value));
                _region = value ?? throw new ArgumentNullException(nameof(value)); 
            }
        }
        public AvailabilityStatus status 
        { 
            get => _status; 
            set => _status = value; 
        }
        public Organization? organization { get => _organization; }
        public IList<TeamTourney> tourneys { get => _tourneys.AsReadOnly(); }
        public IList<Membership> memberships { get => _memberships.AsReadOnly(); }
        public int minimalNumberOfPlayers 
        { 
            get => _minimalNumberOfPlayers; 
            set 
            { 
                if (value < 0) throw new ArgumentException(nameof(value));
                _minimalNumberOfPlayers = value; 
            }
        }
        public int id { get => _id; set => _id = value; }

        private Team()
        {
        }

        public Team(string name, string gamePlayed, DateTime creationDate, string? logo, int minimalAgeEligibility, string region, int minimalNumberOfPlayers)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.gamePlayed = gamePlayed ?? throw new ArgumentNullException(nameof(gamePlayed));
            this.creationDate = creationDate;
            this.logo = logo;
            this.minimalAgeEligibility = minimalAgeEligibility;
            this.region = region ?? throw new ArgumentNullException(nameof(region));
            this.minimalNumberOfPlayers = minimalNumberOfPlayers;
        }

        public void RemoveEmployee(Membership membership)
        {
            if (!_memberships.Contains(membership)) return;
            _memberships.Remove(membership);
            membership.RemoveTeam(this);
        }

        public void AddEmployee(Membership membership)
        {
            if (_memberships.Contains(membership)) return;
            _memberships.Add(membership);
            membership.AddTeam(this);
        }

        public void AddTourney(TeamTourney tourney)
        {
            if (status == AvailabilityStatus.unavailable) throw new ArgumentException(nameof(status));
            if (_tourneys.Contains(tourney)) return;
            _tourneys.Add(tourney);
            tourney.AddTeam(this);
        }

        public void RemoveTourney(TeamTourney tourney)
        {
            if (!_tourneys.Contains(tourney)) return;
            _tourneys.Remove(tourney);
            tourney.RemoveTeam(this);
        }

        public void SetOrganization(Organization organization) 
        {
            if (_organization != null) return;
            _organization = organization;
            organization.CreateTeam(this);
        }

        public void RemoveOrganization(Organization organization)
        {
            if (_organization == null) return;
            _organization = null;
            organization.RemoveTeam(this);
        }

        public void CheckTeamTourneyJoinAvailability()
        {
            var counter = 0;
            foreach(var mem in memberships ?? throw new ArgumentException("No memberships imported or exist."))
            {
                if (mem.employee.status == AvailabilityStatus.available) counter++;
            }
            if (counter < minimalNumberOfPlayers) status = AvailabilityStatus.unavailable;
            else status = AvailabilityStatus.available;
        }
    }
}
