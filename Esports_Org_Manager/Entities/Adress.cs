namespace Esports_Org_Manager.Entities
{
    /// <summary>
    /// This class is mostly being used as a variable in many other classes, it consists of three fields
    /// and have no methods.
    /// 
    /// variables:
    /// - _cityName: string
    /// - _streetName: string
    /// - _number: int
    /// 
    /// methods: none
    /// 
    /// associations: none
    /// 
    /// Validation of variables consists of checking for:
    ///     - null valiues
    ///     - empty values ("")
    ///     - _number being less than 1
    /// </summary>
    public class Adress
    {
        private string _cityName = null!;
        private string _streetName = null!;
        private int _number;


        public string cityName 
        { 
            get => _cityName; 
            set 
            {
                if (value == "") throw new ArgumentException(nameof(value));
                _cityName = value ?? throw new ArgumentNullException(nameof(value)); 
            }
        }
        public string streetName 
        { 
            get => _streetName; 
            set
            {
                if (value == "") throw new ArgumentException(nameof(value));
                _streetName = value ?? throw new ArgumentNullException(nameof(value)); 
            }
        }
        public int number 
        { 
            get => _number; 
            set 
            { 
                if (value < 1) throw new ArgumentException(nameof(value));
                _number = value; 
            }
        }

        /// <summary>
        /// A simple constructor whitch is used to build Adress class objects, it uses public setters that in themselves incorporate
        /// a more through validation, so a more detailed validation here is not needed.
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="streetName"></param>
        /// <param name="number"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Adress(string cityName, string streetName, int number)
        {
            this.cityName = cityName ?? throw new ArgumentNullException(nameof(cityName));
            this.streetName = streetName ?? throw new ArgumentNullException(nameof(streetName));
            this.number = number;
        }

        public override string ToString()
        {
            return ($"City name: {cityName}\n" +
                $"Street name: {streetName}\n" +
                $"Number: {number}");
        }
    }
}
