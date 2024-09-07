# Password Generator

This project includes a `Password` class that allows you to generate passwords with various options such as including uppercase, lowercase, numbers, and special characters.

## Usage

To use the `Password` class, first initialize it with the desired password length and the options for character types you want to include. You can choose between a fixed-length password or provide a minimum and maximum length range for a randomly sized password.

### Constructor Parameters

- `minimumSize` (int): The minimum length of the password.
- `maximumSize` (int): The maximum length of the password.
- `fixedSize`   (int): The password size.
- `options` (PasswordOptions): A combination of flags that determine which character types to include. You can combine multiple options using the bitwise OR (`|`) operator.

### Available Password Options

- `PasswordOptions.IncludeUpperCase`: Include uppercase letters.
- `PasswordOptions.IncludeLowerCase`: Include lowercase letters.
- `PasswordOptions.IncludeNumbers`: Include digits.
- `PasswordOptions.IncludeSpecialCharacters`: Include special characters like `!@#$&*`.

### Example : Generate a password with a fixed size of 12 characters

```csharp
using PasswordGenerator;

class Example
{
    static void Main(string[] args)
    {
        var passwordOptions = PasswordOptions.IncludeUpperCase |
                              PasswordOptions.IncludeLowerCase |
                              PasswordOptions.IncludeNumbers |
                              PasswordOptions.IncludeSpecialCharacters;
                              
        Password passwordGenerator = new Password(12, passwordOptions);
        string password = passwordGenerator.Generate();
        
        Console.WriteLine($"Generated Password: {password}");
    }
}
