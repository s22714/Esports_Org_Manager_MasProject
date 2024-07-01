namespace Esports_Org_Manager.Entities
{
    /// <summary>
    /// A class being asociated with a single entity of employees membership in a certain team.
    /// If given on association with class membership it cannot be changed.
    /// 
    /// the class consists of variables and their public setters and getters:
    ///     - _id: primary key used by entity framework
    ///     - _signDate: date on whitch the contract has been accepted and signed by employee
    ///     - _isRenegotiable: states that the therms of contract can be altered in any way
    ///     - _validityPeriod: how much time in months the contract is supposed to be upheld
    ///     - _membershipId: foreign key from class Membership used by Entity Framework
    ///     - _membership: object with which current Contract object is connected
    ///     - _alreadyused: bool variable that helps to prevent object being reasigned to somebody else, it has no setters
    /// </summary>
    public class Contract
    {
        private int _id;
        private DateTime _signDate;
        private bool _isRenegotiable;
        private int _validityPeriod;

        // contract foreign key
        private int _membershipId;
        public int membershipId { get => _membershipId; set => _membershipId = value; }
        private Membership _membership = null!;
        private bool _alreadyUsed;

        public int id { get => _id; set => _id = value; }
        public DateTime signDate 
        { 
            get => _signDate; 
            set
            { 
                _signDate = value; 
            } 
        }
        public bool isRenegotiable { get => _isRenegotiable; set => _isRenegotiable = value; }
        public int validityPeriod 
        { 
            get => _validityPeriod; 
            set 
            { 
                if (value < 0) throw new ArgumentException(nameof(value));
                _validityPeriod = value; 
            }
        }
        public Membership membership { get => _membership; }

        /// <summary>
        /// An empty constructor supposedly used by Entity Framework as stated in the documentation
        /// </summary>
        private Contract() { }

        /// <summary>
        /// Here you can create a Contract without yet assigning it to a chosen Membership Class
        /// </summary>
        /// <param name="signDate"></param>
        /// <param name="isRenegotiable"></param>
        /// <param name="validityPeriod"></param>
        public Contract(DateTime signDate, bool isRenegotiable, int validityPeriod)
        {
            this.signDate = signDate;
            this.isRenegotiable = isRenegotiable;
            this.validityPeriod = validityPeriod;
            _alreadyUsed = false;
        }

        /// <summary>
        /// A function that starts a process of renegotiating a contract, it can be used by an employee
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Renegotiate()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// A method that can be called if an employee wants to accept a proposed by management contract
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Accept()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// A method that joins Contract object with chosen Membership object, while checking if a contract has already been assigned to someone
        /// </summary>
        /// <param name="membership"></param>
        /// <exception cref="ArgumentException"></exception>
        public void SetMembership(Membership membership) 
        {
            if (_membership == membership) return;
            if (_membership != null || _alreadyUsed) throw new ArgumentException();
            _membership = membership;
            membership.AddContract(this);
            _alreadyUsed = true;
        }

        /// <summary>
        /// A method that removes an association between contract and membership class
        /// </summary>
        /// <param name="membership"></param>
        public void RemoveMembership(Membership membership) 
        { 
            if (_membership == null) return;
            _membership = null;
            membership.RemoveContract(this);
        }
    }
}
