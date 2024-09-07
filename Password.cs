using System.Text;

namespace PasswordGenerator
{
    public class Password
    {
        private const string LOWERCHARS = "abcdefghijklmnopqrstuvwxyz";
        private const string UPPERCHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string NUMBERS = "0123456789";
        private const string SPECIAL = "!@#$&*";

        private PasswordOptions _passwordOptions;
        private string _password;
        private int _minimumSize;
        private int _maximumSize;

        /// <summary>
        /// Create a password object that generate passwords of variable length
        /// </summary>
        /// <param name="minimumSize">
        /// Passwod minimum size
        /// </param>
        /// <param name="maximumSize">
        /// Passwod maximum size
        /// </param>
        /// <param name="options">
        /// enum value that represent allowed password letters
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="options"/> has no any option
        /// </exception>
        /// /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="minimumSize"/> or <paramref name="maximumSize"/> has a zero or a negative value
        /// </exception>
        ///<exception cref="ArgumentException">
        ///Thrown when <paramref name="minimumSize"/> greater than <paramref name="maximumSize"/>
        /// </exception>
        public Password(int minimumSize,int maximumSize, PasswordOptions options)
        {
            if (!IsLengthValid(minimumSize) || !IsLengthValid(maximumSize))
                throw new ArgumentException("Password must have a positive length");

            if (options == 0)
                throw new ArgumentException("At least one password option " +
                                            "(e.g., numbers, lowercase, uppercase, or special characters)" +
                                            " must be selected.");
            if (minimumSize > maximumSize)
                throw new ArgumentException("Maximum size must be less than or equal minimum size");

            _minimumSize = minimumSize;
            _maximumSize = maximumSize;
            _passwordOptions = options;
        }

        /// <summary>
        /// Create a password object that generate passwords of fixed length
        /// </summary>
        /// <param name="fixedSize">
        /// Passwod size
        /// </param>
        /// <param name="options">
        /// enum value that represent allowed password letters
        /// </param>
        /// /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="fixedSize"/> has a zero or a negative value
        /// </exception>
        public Password(int fixedSize, PasswordOptions options) : this(fixedSize,fixedSize,options)
        { }

        private string Generate(int minSize, int maxSize) 
        {
            int length = Random.Shared.Next(minSize,maxSize + 1);
            char[] pass = new char[length];
            int index = 0;

            var options = new List<PasswordOptions>();

            foreach (var option in Enum.GetValues<PasswordOptions>())
            {
                if((_passwordOptions & option) == option) 
                    options.Add(option);
            }

            while (index < length) 
            {
                int randOptionIndex = Random.Shared.Next(0, options.Count);
                var randOption = options[randOptionIndex];

                char randChar = '\0';
                switch (randOption) 
                {
                    case PasswordOptions.IncludeUpperCase:
                        randChar = UPPERCHARS[Random.Shared.Next(0,UPPERCHARS.Length)];
                        break;
                    case PasswordOptions.IncludeLowerCase:
                        randChar = LOWERCHARS[Random.Shared.Next(0, LOWERCHARS.Length)];
                        break;
                    case PasswordOptions.IncludeNumbers:
                        randChar = NUMBERS[Random.Shared.Next(0, NUMBERS.Length)];
                        break;
                    case PasswordOptions.IncludeSpecialCharacters:
                        randChar = SPECIAL[Random.Shared.Next(0, SPECIAL.Length)];
                        break;
                }

                pass[index] = randChar;
                index++;
            }
            _password = new string(pass);
            return _password;
        }

        /// <summary>
        /// Generate random passwords
        /// </summary>
        /// <returns>
        /// Password as a string
        /// </returns>
        public string Generate() => Generate(_minimumSize, _maximumSize);

        private bool IsLengthValid(int length) => length > 0;

    }
}
