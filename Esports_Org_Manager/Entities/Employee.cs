
using System.Security.Cryptography.X509Certificates;

namespace Esports_Org_Manager.Entities
{
    /// <summary>
    /// A discriminator stating a type of employee that has been added to the system
    /// </summary>
    public enum EmployeeType
    {
        Player,
        Coach,
        ContentCreator
    }

    /// <summary>
    /// The class lets you add an employee to the system.
    /// It also lets you swap their types between Player - Coach - Content Creator. 
    /// The created entity has to have a type thats derived from one of these three.
    /// Variables specific to one of the types cannot be accessed by any of the others.
    /// </summary>
    public class Employee : IPlayer, ICoach, IContentCreator
    {
        private int _id;
        private string _name = null!;
        private string _lastName = null!;
        private string _nick = null!;
        private string _email = null!;
        private Adress _adress = null!;
        private double _wage;
        private AvailabilityStatus _status;

        // employee type variable. Used as a discriminator
        private EmployeeType _employeeTypeDiscriminator;

        // variables derived from ContentCreator class
        private List<string>? _channels;
        private int? _numberOfVideosPerWeek;
        private int? _numberOfHoursStreamingPerWeek;

        // a variable derived from Coach class
        private Dictionary<int, int>? _placementBonuses;

        // a variable derived from Player class
        private int? _procentageOfWinnings;

        // List of memberships thet the player had or has in the system
        private IList<Membership> _memberships = new List<Membership>();

        // organization foreign key used by Entity Framework
        public string? organizationName { get; set; }

        // organization that the employee is assigned to
        private Organization? _organization;

        // connections only accessed by an employee of type ContentCreator
        private IList<Tourney>? _tourneyParticipations = new List<Tourney>();
        private IList<Tourney>? _tourneyCasts = new List<Tourney>();

        // tourneys thet an employee played or plays in
        private IList<SoloTourney> _tourneysPlayed = new List<SoloTourney>();

        public int id { get => _id; private set => _id = value; }
        public string name 
        { 
            get => _name; 
            set 
            { 
                if (value == "") throw new ArgumentException(nameof(value));
                _name = value ?? throw new ArgumentNullException(nameof(value)); 
            }
        }
        public string lastName 
        { 
            get => _lastName; 
            set 
            {
                if (value == "") throw new ArgumentException(nameof(value));
                _lastName = value ?? throw new ArgumentNullException(nameof(value)); 
            }
        }
        public string nick 
        { 
            get => _nick; 
            set 
            {
                if (value == "") throw new ArgumentException(nameof(value));
                _nick = value ?? throw new ArgumentNullException(nameof(value)); 
            }
        }
        public string email 
        {
            get => _email; 
            set 
            {
                if (value == "") throw new ArgumentException(nameof(value));
                _email = value ?? throw new ArgumentNullException(nameof(value)); 
            }
        }
        public Adress adress { get => _adress; set => _adress = value; }
        public double wage 
        { 
            get => _wage; 
            set 
            {
                if (value < 0) throw new ArgumentException(nameof(value));
                _wage = value; 
            }
        }
        public AvailabilityStatus status { get => _status; set => _status = value; }

        public EmployeeType employeeTypeDiscriminator { get => _employeeTypeDiscriminator; private set => _employeeTypeDiscriminator = value; }

        public List<string>? channels 
        { 
            get
            {
                if (employeeTypeDiscriminator != EmployeeType.ContentCreator) return null;
                return _channels; 
            }
            set 
            {
                if (employeeTypeDiscriminator != EmployeeType.ContentCreator) value = null;
                if (value != null && value.Count < 1) throw new ArgumentException(nameof(value));
                _channels = value; 
            }
        }
        public int? numberOfVideosPerWeek 
        {
            get
            {
                if (employeeTypeDiscriminator != EmployeeType.ContentCreator) return null;
                return _numberOfVideosPerWeek;
            } 
            set 
            {
                if (employeeTypeDiscriminator != EmployeeType.ContentCreator) value = null;
                if (value < 0) throw new ArgumentException();
                _numberOfVideosPerWeek = value; 
            }
        }
        public int? numberOfHoursStreamingPerWeek 
        { 
            get
            { 
                if (employeeTypeDiscriminator != EmployeeType.ContentCreator) return null;
                return _numberOfHoursStreamingPerWeek; 
            }
            set 
            {
                if (employeeTypeDiscriminator != EmployeeType.ContentCreator) value = null;
                _numberOfHoursStreamingPerWeek = value; 
            }
        }

        public Dictionary<int, int>? placementBonuses 
        { 
            get  
            { 
                if (employeeTypeDiscriminator != EmployeeType.Coach) return null;
                return _placementBonuses; 
            }
            set 
            {
                if (employeeTypeDiscriminator != EmployeeType.Coach) value = null;
                if (value != null && value.Count < 1) throw new ArgumentException(nameof(value));
                _placementBonuses = value; 
            }
        }

        public int? procentageOfWinnings 
        { 
            get
            {
                if (employeeTypeDiscriminator != EmployeeType.Player) return null;
                return _procentageOfWinnings; 
            }
            set
            {
                if (employeeTypeDiscriminator != EmployeeType.Player) value = null;
                if (value < 0) throw new ArgumentException(nameof(value));
                _procentageOfWinnings = value; 
            }
        }

        public IList<Membership> memberships { get => _memberships.AsReadOnly(); private set => _memberships = value; }
        public Organization? organization { get => _organization; private set => _organization = value; }
        public IList<Tourney>? tourneyParticipations { get => _tourneyParticipations.AsReadOnly(); private set => _tourneyParticipations = value; }
        public IList<Tourney>? tourneyCasts { get => _tourneyCasts.AsReadOnly(); private set => _tourneyCasts = value; }
        public IList<SoloTourney> tourneysPlayed { get => _tourneysPlayed.AsReadOnly(); private set => _tourneysPlayed = value; }
        
        /// <summary>
        /// private constructor for Entity Framework
        /// </summary>
        private Employee()
        {
        }

        /// <summary>
        /// Publicly used constructor for class employee.
        /// If right variables are gived the constructor picks an employee type.
        /// if no variables are given, or not all for chosen type, the constructor throws an error.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="nick"></param>
        /// <param name="email"></param>
        /// <param name="adress"></param>
        /// <param name="wage"></param>
        /// <param name="status"></param>
        /// <param name="channels"></param>
        /// <param name="numberOfVideosPerWeek"></param>
        /// <param name="numberOfHoursStreamingPerWeek"></param>
        /// <param name="placementBonuses"></param>
        /// <param name="procentageOfWinnings"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Employee(string name, string lastName, string nick, string email, Adress adress, double wage, AvailabilityStatus status, List<string>? channels, int? numberOfVideosPerWeek, int? numberOfHoursStreamingPerWeek, Dictionary<int, int>? placementBonuses, int? procentageOfWinnings)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.nick = nick ?? throw new ArgumentNullException(nameof(nick));
            this.email = email ?? throw new ArgumentNullException(nameof(email));
            this.adress = adress ?? throw new ArgumentNullException(nameof(adress));
            this.wage = wage;
            this.status = status;

            if (procentageOfWinnings != null)
            {
                this.employeeTypeDiscriminator = EmployeeType.Player;
                this.procentageOfWinnings = procentageOfWinnings;
            }
            else if (channels != null && numberOfHoursStreamingPerWeek != null && numberOfVideosPerWeek != null)
            {
                this.employeeTypeDiscriminator = EmployeeType.ContentCreator;
                this.channels = channels;
                this.numberOfHoursStreamingPerWeek = numberOfHoursStreamingPerWeek;
                this.numberOfVideosPerWeek = numberOfVideosPerWeek;
                _tourneyCasts = new List<Tourney>();
                _tourneyParticipations = new List<Tourney>();
            }
            else if(placementBonuses != null)
            {
                this.employeeTypeDiscriminator = EmployeeType.Coach;
                this.placementBonuses = placementBonuses;
            }
            else
            {
                throw new ArgumentException("No employee type could be assigned");
            }
        }

        public double CalculateAllIncome()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// change employee type to player
        /// </summary>
        /// <param name="procenatgeOfWinnings"></param>
        public void MakePlayer(int procenatgeOfWinnings)
        {
            _employeeTypeDiscriminator = EmployeeType.Player;
            _placementBonuses = null;
            _channels = null;
            _numberOfVideosPerWeek = null;
            _numberOfHoursStreamingPerWeek = null;
            _tourneyCasts = null;
            _tourneyParticipations = null;

            _procentageOfWinnings = procenatgeOfWinnings;
        }

        /// <summary>
        /// change employee type to coach
        /// </summary>
        /// <param name="placementBonuses"></param>
        public void MakeCoach(Dictionary<int, int> placementBonuses)
        {
            _employeeTypeDiscriminator = EmployeeType.Coach;
            _placementBonuses = placementBonuses;
            _channels = null;
            _numberOfVideosPerWeek = null;
            _numberOfHoursStreamingPerWeek = null;
            _tourneyCasts = null;
            _tourneyParticipations = null;

            _procentageOfWinnings = null;
        }

        /// <summary>
        /// make employee type content creator
        /// </summary>
        /// <param name="channels"></param>
        /// <param name="numberOfWideosPerWeek"></param>
        /// <param name="numberOfHoursStreamingPerWeek"></param>
        public void MakeContentCreator(List<string> channels, int numberOfWideosPerWeek, int numberOfHoursStreamingPerWeek)
        {
            _employeeTypeDiscriminator = EmployeeType.ContentCreator;
            _placementBonuses = null;
            _channels = channels;
            _numberOfVideosPerWeek = numberOfWideosPerWeek;
            _numberOfHoursStreamingPerWeek = numberOfHoursStreamingPerWeek;
            _tourneyCasts = new List<Tourney>();
            _tourneyParticipations = new List<Tourney>();

            _procentageOfWinnings = null;
        }

        /// <summary>
        /// send notification about qualifying to a tourney to an employee
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void SendQualificationNotification()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// assigne a contract to this employee
        /// </summary>
        /// <param name="contract"></param>
        public void AssignContract(Contract contract)
        {
            _memberships.First(x => x.endDate > DateTime.Now).AddContract(contract);
        }

        /// <summary>
        /// make employee cast in a tournament
        /// only works if en employee is already one of the organizers
        /// </summary>
        /// <param name="tourney"></param>
        /// <exception cref="ArgumentException"></exception>
        public void MakeCaster(Tourney tourney)
        {
            if (_tourneyParticipations == null) throw new ArgumentException();
            if (_tourneyCasts == null) throw new ArgumentException();
            if (!_tourneyParticipations.Contains(tourney)) throw new ArgumentException();
            if (_tourneyCasts.Contains(tourney)) return;
            _tourneyCasts.Add(tourney);
            tourney.AddCaster(this);
        }

        /// <summary>
        /// Remove employee from casting
        /// </summary>
        /// <param name="tourney"></param>
        /// <exception cref="ArgumentException"></exception>
        public void RemoveCaster(Tourney tourney)
        {
            if (_tourneyParticipations == null) throw new ArgumentException();
            if (_tourneyCasts == null) throw new ArgumentException();
            if (!_tourneyParticipations.Contains(tourney)) throw new ArgumentException();
            if (!_tourneyCasts.Contains(tourney)) return;
            _tourneyCasts.Remove(tourney);
            tourney.RemoveCaster(this);
        }

        /// <summary>
        /// make employee one of the organizers
        /// </summary>
        /// <param name="tourney"></param>
        /// <exception cref="ArgumentException"></exception>
        public void MakeParticipant(Tourney tourney)
        {
            if (_tourneyParticipations == null) throw new ArgumentException();
            if (_tourneyParticipations.Contains(tourney)) return;
            _tourneyParticipations.Add(tourney);
            tourney.AddOwnOrganizer(this);
        }

        /// <summary>
        /// remove employee from the organizers pool
        /// automaticly removes from casters pool
        /// </summary>
        /// <param name="tourney"></param>
        /// <exception cref="ArgumentException"></exception>
        public void RemoveParticipant(Tourney tourney)
        {
            if (_tourneyParticipations == null) throw new ArgumentException();
            if (_tourneyCasts == null) throw new ArgumentException();
            if (_tourneyParticipations.Contains(tourney))
            {
                _tourneyParticipations.Remove(tourney);
                tourney.RemoveOwnOrganizer(this);
            }
            if (_tourneyCasts.Contains(tourney))
            {
                _tourneyCasts.Remove(tourney);
                tourney.RemoveCaster(this);
            }
        }

        /// <summary>
        /// adds employee to a tourney as a competitor
        /// </summary>
        /// <param name="tourney"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddTourneyAsPlayer(SoloTourney tourney)
        {
            if(status == AvailabilityStatus.unavailable) throw new ArgumentException(nameof(status));
            if (_tourneysPlayed.Contains(tourney)) return;
            _tourneysPlayed.Add(tourney);
            tourney.AddEmployee(this);
        }

        /// <summary>
        /// removes employee from a tourney competitors list
        /// </summary>
        /// <param name="tourney"></param>
        public void RemoveTourneyAsPlayer(SoloTourney tourney)
        {
            if (!_tourneysPlayed.Contains(tourney)) return;
            _tourneysPlayed.Remove(tourney);
            tourney.RemoveEmployee(this);
        }

        /// <summary>
        /// adds new membership
        /// the association is type Bag therefore no checking for unique connection
        /// </summary>
        /// <param name="membership"></param>
        public void AddMembership(Membership membership)
        {
            if (_memberships.Contains(membership)) return;
            _memberships.Add(membership);
            membership.AddEmployee(this);
        }

        /// <summary>
        /// Removes a membership from player
        /// </summary>
        /// <param name="membership"></param>
        public void RemoveMembership(Membership membership)
        {
            if (!_memberships.Contains(membership)) return;
            _memberships.Remove(membership);
            membership.RemoveEmployee(this);
        }

        /// <summary>
        /// assignes employee to an organization
        /// </summary>
        /// <param name="organization"></param>
        public void SetOrganization(Organization organization)
        {
            if (_organization != null) return;
            _organization = organization;
            organization.CreateEmployee(this);
        }

        /// <summary>
        /// unassignes employee from an organization
        /// </summary>
        /// <param name="organization"></param>
        public void RemoveOrganization(Organization organization)
        {
            if (_organization == null) return;
            _organization = null;
            organization.DeleteEmployee(this);
        }
    }
}
