using Newtonsoft.Json.Linq;

namespace Esports_Org_Manager.Entities
{
    public enum TourneyState
    {
        Created,
        Canceled,
        Proceeding,
        Finished
    }
    public enum ViewingType
    {
        Online,
        Offline
    }
    public enum OrganizerType
    {
        Independent,
        Own
    }
    public abstract class Tourney : IOnline, IOffline
    {
        private int _id;
        private TourneyState _state;
        private string _name = null!;
        private DateTime _date;
        private string _format = null!;
        private double _awardPool;
        private List<int> _procentPerPlace = new List<int>();
        private string _timeUntill;

        private List<string>? _streamLinks;

        private double? _ticketPrice;
        private Adress? _adress;

        private HashSet<ViewingType> _viewTypeDiscriminator = new HashSet<ViewingType>();

        private OrganizerType _organizerDiscriminator;

        public int independentOrganizerId { get; set; }
        private IndependentContractor? _independentOrganizer;
        private IList<Employee>? _ownOrganizers;
        private IList<Employee>? _casters;

        public int id { get => _id; set => _id = value; }
        public TourneyState state { get => _state; set => _state = value; }
        public string name 
        { 
            get => _name; 
            set 
            { 
                if (value == "") throw new ArgumentException(nameof(value));
                _name = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
        public DateTime date 
        { 
            get => _date; 
            set 
            { 
                if (value < DateTime.Now.AddDays(14) && state == TourneyState.Created) throw new ArgumentException("Tourney too close");
                _date = value; 
            }
        }
        public string format 
        { 
            get => _format; 
            set 
            {
                if (value == "") throw new ArgumentException(nameof(value));
                _format = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
        public double awardPool 
        { 
            get => _awardPool; 
            set
            { 
                if (value < 0) throw new ArgumentException(nameof(value));
                _awardPool = value; 
            }
        }
        public List<int> procentPerPlace 
        { 
            get => _procentPerPlace; 
            set 
            {
                if (value != null && value.Count < 1) throw new ArgumentException(nameof(value)); 
                _procentPerPlace = value ?? throw new ArgumentException(nameof(value)); 
            }
        }
        public string timeUntill 
        { 
            get => _timeUntill; 
            private set => _timeUntill = value; 
        }

        public List<string>? streamLinks 
        {
            get 
            {
                if (!viewTypeDiscriminator.Contains(ViewingType.Online)) throw new ArgumentException(nameof(viewTypeDiscriminator));
                return _streamLinks; 
            }
            set 
            {
                if (!viewTypeDiscriminator.Contains(ViewingType.Online)) value = null;
                _streamLinks = value; 
            }
        }

        public double? ticketPrice 
        { 
            get 
            {
                if (!viewTypeDiscriminator.Contains(ViewingType.Offline)) throw new ArgumentException(nameof(viewTypeDiscriminator));
                return _ticketPrice; 
            }
            set
            { 
                if (value != null && value < 0) throw new ArgumentException(nameof(value));
                _ticketPrice = value;
            }
        }
        public Adress? adress 
        {
            get
            {
                if (!viewTypeDiscriminator.Contains(ViewingType.Offline)) throw new ArgumentException(nameof(viewTypeDiscriminator));
                return _adress; 
            }
            set => _adress = value; 
        }

        public HashSet<ViewingType> viewTypeDiscriminator { get => _viewTypeDiscriminator; private set => _viewTypeDiscriminator = value; }

        public OrganizerType organizerDiscriminator { get => _organizerDiscriminator; private set => _organizerDiscriminator = value; }

        public IndependentContractor? independentOrganizer { get => _independentOrganizer; private set => _independentOrganizer = value; }
        public IList<Employee>? ownOrganizers { get => _ownOrganizers.AsReadOnly(); private set => _ownOrganizers = value; }
        public IList<Employee>? casters { get => _casters.AsReadOnly(); private set => _casters = value; }
        
        protected Tourney() { }

        protected Tourney(TourneyState state, string name, DateTime date, string format, double awardPool, List<int> procentPerPlace, OrganizerType organizerDiscriminator)
        {
            this.state = state;
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.date = date;
            this.format = format ?? throw new ArgumentNullException(nameof(format));
            this.awardPool = awardPool;
            this.procentPerPlace = procentPerPlace ?? throw new ArgumentNullException(nameof(procentPerPlace));
            this.organizerDiscriminator = organizerDiscriminator;

            this._timeUntill = CalculateTimeUntillTourney();

            if (organizerDiscriminator == OrganizerType.Own)
            {
                _ownOrganizers = new List<Employee>();
                _casters = new List<Employee>();
            }
        }

        public void MakeOnline(List<string> streamLinks)
        {
            _viewTypeDiscriminator.Add(ViewingType.Online);
            _streamLinks = streamLinks;
        }

        public void MakeOffline(double ticketPrice, Adress adress)
        {
            _viewTypeDiscriminator.Add(ViewingType.Offline);
            _adress = adress;
            _ticketPrice = ticketPrice;
        }

        public void AddIndependentOrganizer(IndependentContractor independentContractor)
        {
            if (_organizerDiscriminator != OrganizerType.Independent) throw new ArgumentException();
            if (_independentOrganizer != null) return;
            _independentOrganizer = independentContractor;
            independentContractor.AssignToTourney(this);
        }

        public void RemoveIndependentOrganizer(IndependentContractor independentContractor)
        {
            if (_organizerDiscriminator != OrganizerType.Independent) throw new ArgumentException();
            if (_independentOrganizer == null) return;
            _independentOrganizer = null;
            independentContractor.RemoveFromTourney(this);
        }

        public void AddOwnOrganizer(Employee contentCreator)
        {
            if (_organizerDiscriminator != OrganizerType.Own) throw new ArgumentException();
            if (_ownOrganizers == null) throw new ArgumentException();
            if (_ownOrganizers.Contains(contentCreator)) return;
            _ownOrganizers.Add(contentCreator);
            contentCreator.MakeParticipant(this);
        }

        public void RemoveOwnOrganizer(Employee contentCreator)
        {
            if (_organizerDiscriminator != OrganizerType.Own) throw new ArgumentException();
            if (_ownOrganizers == null) throw new ArgumentException();
            if (_casters == null) throw new ArgumentException();
            if (_ownOrganizers.Contains(contentCreator))
            {
                _ownOrganizers.Remove(contentCreator);
                contentCreator.RemoveParticipant(this);
            }
            if (_casters.Contains(contentCreator))
            {
                _casters.Remove(contentCreator);
                contentCreator.RemoveCaster(this);
            }
            
        }

        public void AddCaster(Employee contentCreator)
        {
            if (_organizerDiscriminator != OrganizerType.Own) throw new ArgumentException();
            if (_ownOrganizers == null) throw new ArgumentException();
            if (_casters == null) throw new ArgumentException();
            if (!_ownOrganizers.Contains(contentCreator)) throw new ArgumentException();
            if (_casters.Contains(contentCreator)) return;
            _casters.Add(contentCreator);
            contentCreator.MakeCaster(this);
        }

        public void RemoveCaster(Employee contentCreator)
        {
            if (_organizerDiscriminator != OrganizerType.Own) throw new ArgumentException();
            if (_ownOrganizers == null) throw new ArgumentException();
            if (_casters == null) throw new ArgumentException();
            if (!_ownOrganizers.Contains(contentCreator)) throw new ArgumentException();
            if (!_casters.Contains(contentCreator)) return;
            _casters.Remove(contentCreator);
            contentCreator.RemoveCaster(this);
        }

        public void Reschedule()
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Finish()
        {
            throw new NotImplementedException();
        }

        public string CalculateTimeUntillTourney()
        {
            var res = (date - DateTime.Now).Days;
            if (res <= 0) return "-";
            return (res.ToString() + " days");
        }
    }
}
