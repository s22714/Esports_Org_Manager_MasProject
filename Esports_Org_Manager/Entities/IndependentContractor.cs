namespace Esports_Org_Manager.Entities
{
    /// <summary>
    /// a class describing Independent contractors that can be assigned to a tourney as an organizer
    /// </summary>
    public class IndependentContractor
    {
        private int _id;
        private string _name = null!;
        private string _email = null!;
        private double _price;

        // list of tourneys organized by an organization
        private IList<Tourney> _tourneys = new List<Tourney>();

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
        public string email 
        { 
            get => _email; 
            set 
            {
                if (value == "") throw new ArgumentException(nameof(value));
                _email = value ?? throw new ArgumentNullException(nameof(value));
            }
        }
        public double price 
        { 
            get => _price; 
            set 
            {
                if (value < 0) throw new ArgumentException(nameof(value));
                _price = value; 
            }
        }
        public IList<Tourney> tourneys { get => _tourneys.AsReadOnly(); private set => _tourneys = value; }
        
        /// <summary>
        /// private constructor used by Entity Framework
        /// </summary>
        private IndependentContractor() { }

        /// <summary>
        /// public constructor of class IndependentConstructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="price"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public IndependentContractor(string name, string email, double price)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.email = email ?? throw new ArgumentNullException(nameof(email));
            this.price = price;
        }

        /// <summary>
        /// a method connecting contractor to a tourney as an organizer
        /// </summary>
        /// <param name="tourney"></param>
        public void AssignToTourney(Tourney tourney)
        {
            if (_tourneys.Contains(tourney)) return;
            _tourneys.Add(tourney);
            tourney.AddIndependentOrganizer(this);
        }

        /// <summary>
        /// method that unassignes contractor as an organizer
        /// </summary>
        /// <param name="tourney"></param>
        public void RemoveFromTourney(Tourney tourney)
        {
            if (!_tourneys.Contains(tourney)) return;
            _tourneys.Remove(tourney);
            tourney.RemoveIndependentOrganizer(this);
        }

        public override string ToString()
        {
            return ($"Name: {name} | Email: {email} | Price: {price}");
        }
    }
}
