namespace Esports_Org_Manager.Entities
{
    /// <summary>
    /// a class connecting teams to employees. every connection can be made many times.
    /// </summary>
    public class Membership
    {
        private int _id;
        private DateTime _startDate;
        private DateTime _endDate;

        // team employee foreign keys
        private int _teamId;
        private int _employeeId;
        public int teamId { get => _teamId; private set => _teamId = value; }
        public int employeeId { get => _employeeId; private set => _employeeId = value; }

        private Team _team = null!;
        private Employee _employee = null!;
        private IList<Contract> _contracts = new List<Contract>();

        public int id { get => _id; private set => _id = value; }
        public DateTime startDate
        { 
            get => _startDate; 
            set  
            { 
                _startDate = value; 
            }
        }
        public DateTime endDate 
        { 
            get => _endDate; 
            set 
            { 
                _endDate = value; 
            }
        }
        public Team team { get => _team; private set => _team = value; }
        public Employee employee { get => _employee; private set => _employee = value; }
        public IList<Contract> contracts { get => _contracts.AsReadOnly(); private set => _contracts = value; }

        /// <summary>
        /// private constructor used by Entity Framework
        /// </summary>
        private Membership() { }

        /// <summary>
        /// public constructor for a membership. 
        /// there is no way of creating a membership without a team and employee objects
        /// the constructor automatically makes the connections
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="team"></param>
        /// <param name="employee"></param>
        public Membership(DateTime startDate, DateTime endDate, Team team, Employee employee)
        {
            if(team == null || employee == null) throw new ArgumentNullException(nameof(team));
            this.startDate = startDate;
            this.endDate = endDate;

            AddEmployee(employee);
            AddTeam(team);
        }

        /// <summary>
        /// a method connecting membership to an employee
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployee(Employee employee)
        {
            if (_employee != null) return;
            _employee = employee;
            employee.AddMembership(this);
        }

        /// <summary>
        /// a method connecting membership to a team
        /// </summary>
        /// <param name="team"></param>
        public void AddTeam(Team team)
        {
            if (_team != null) return;
            _team = team;
            team.AddEmployee(this);
        }

        /// <summary>
        /// a method that disconnects membership and team
        /// </summary>
        /// <param name="team"></param>
        public void RemoveTeam(Team team)
        {
            if (_team == null) return;
            _team = null;
            team.RemoveEmployee(this);
            if (_employee != null)
                RemoveEmployee(_employee);
        }

        /// <summary>
        /// a method that disconnects employee from a membership
        /// </summary>
        /// <param name="employee"></param>
        public void RemoveEmployee(Employee employee)
        {
            if (employee == null) return;
            _employee = null;
            employee.RemoveMembership(this);
            if ( _team != null)
                RemoveTeam(_team);
        }

        /// <summary>
        /// method that adds contract to all contracts list
        /// connects a contract to a membership
        /// </summary>
        /// <param name="contract"></param>
        public void AddContract(Contract contract)
        {
            if (_contracts.Contains(contract)) return;
            _contracts.Add(contract);
            contract.SetMembership(this);
        }

        /// <summary>
        /// a method removing contract from membership
        /// </summary>
        /// <param name="contract"></param>
        public void RemoveContract(Contract contract)
        {
            if (!_contracts.Contains(contract)) return;
            _contracts.Remove(contract);
            contract.RemoveMembership(this);
        }

    }
}
