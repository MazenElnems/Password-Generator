using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{

    /// <summary>
    /// Specifies the options for generating a password. 
    /// </summary>
    [Flags]
    public enum PasswordOptions
    {
        /// <summary>
        /// Include uppercase letters (A-Z) in the generated password.
        /// </summary>
        IncludeUpperCase = 1,

        /// <summary>
        /// Include lowercase letters (a-z) in the generated password.
        /// </summary>
        IncludeLowerCase = 2,

        /// <summary>
        /// Include numeric digits (0-9) in the generated password.
        /// </summary>
        IncludeNumbers = 4,

        /// <summary>
        /// Include special characters (e.g., !@#$&*) in the generated password.
        /// </summary>
        IncludeSpecialCharacters = 8
    }

}


