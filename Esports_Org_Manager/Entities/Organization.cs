using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Esports_Org_Manager.Entities
{
    /// <summary>
    /// an esports organization to whitch assigned are teams and employees
    /// </summary>
    public class Organization
    {

        private string _name = null!;
        private DateTime _creationDate;
        private string _logo = null!;
        private IDictionary<string,Team>? _teams = new Dictionary<string, Team>();
        private IList<Employee>? _employees = new List<Employee>();

        // entity framework virtual teams mapping
        public virtual List<Team>? virtTeams { get; private set; } = new List<Team>();
        
        public string name 
        { 
            get => _name; 
            set 
            {
                if (_name == value) return;
                if (value == "") throw new ArgumentException(nameof(value));
                _name = value ?? throw new ArgumentNullException(nameof(value)); 
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
        public string logo 
        { 
            get => _logo; 
            set 
            {
                if (value == "") throw new ArgumentException(nameof(value));
                _logo = value ?? throw new ArgumentNullException(nameof(value)); 
            } 
        }
        public IDictionary<string, Team>? teams { get => _teams.AsReadOnly(); private set => _teams = value; }
        public IList<Employee>? employees { get => _employees.AsReadOnly(); private set => _employees = value; }

        /// <summary>
        /// private constructor used by Entity Framework
        /// </summary>
        private Organization() 
        {
        }

        public Organization(string name, DateTime creationDate, string logo)
        {
            if (name == "") throw new ArgumentException(nameof(name));
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.creationDate = creationDate;
            this.logo = logo ?? throw new ArgumentNullException(nameof(logo));
        }

        public void CreateEmployee(Employee employee)
        {
            if (_employees.Contains(employee)) return;
            _employees.Add(employee);
            employee.SetOrganization(this);
        }

        public void CreateTeam(Team team)
        {
            if (_teams.ContainsKey(team.name)) return;
            _teams.Add(team.name, team);
            virtTeams.Add(team);
            team.SetOrganization(this);
        }

        public void RemoveTeam(Team team) 
        {
            if (!_teams.ContainsKey(team.name)) return;
            _teams.Remove(team.name);
            virtTeams.Remove(team);
            team.RemoveOrganization(this);
        }

        public void DeleteEmployee(Employee employee)
        {
            if (!_employees.Contains(employee)) return;
            _employees.Remove(employee);
            employee.RemoveOrganization(this);
        }

        public void CreateTourney()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return (JsonConvert.SerializeObject(this));
        }
    }
}
