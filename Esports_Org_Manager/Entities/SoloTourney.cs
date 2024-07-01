

namespace Esports_Org_Manager.Entities
{
    public class SoloTourney : Tourney
    {
        private bool _allowCoaching;
        private IDictionary <int, int> _placements = new Dictionary<int, int> ();
        private IList<Employee> _employees = new List<Employee> ();
        
        public bool allowCoaching { get => _allowCoaching; set => _allowCoaching = value; }

        // Dictionary<Team.id,points>
        public IDictionary<int, int> placements { get => _placements.OrderBy(x => x.Value).ToDictionary().AsReadOnly(); private set => _placements = value; }
        public IList<Employee> employees { get => _employees.AsReadOnly(); private set => _employees = value; }

        private SoloTourney() : base() { }

        public SoloTourney(bool allowCoaching, TourneyState state, string name, DateTime date, string format, double awardPool, List<int> procentPerPlace, OrganizerType organizerDiscriminator) : base(state, name, date, format, awardPool, procentPerPlace, organizerDiscriminator)
        {
            this.allowCoaching = allowCoaching;
        }

        public void AddEmployee(Employee employee)
        {
            if (_employees.Contains(employee)) return;
            _placements.Add(employee.id, 0);
            _employees.Add(employee);
            employee.AddTourneyAsPlayer(this);
        }

        public void RemoveEmployee(Employee employee)
        {
            if(!_employees.Contains(employee)) return;
            _placements.Remove(employee.id);
            _employees.Remove(employee);
            employee.RemoveTourneyAsPlayer(this);
        }

        public void SetEmployeePoints(Employee employee, int points)
        {
            if (!_placements.ContainsKey(employee.id)) throw new ArgumentException();
            _placements[employee.id] = points;
        }
    }
}
