using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtributesValidation
{
    public static class UserValidator
    {
        public static List<string> ValidateUser(this IValidatable validatable)
        {
            List<string> errors = new List<string>();

            var type = validatable.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var attrs = property.GetCustomAttributes(false);

                foreach (var a in attrs)
                {
                    if (a is MinLengthAttribute minLength)
                    {
                        if (property.Name == "Login")
                        {
                            if (!minLength.IsValid(validatable.Login))
                            {
                                errors.Add($"{property.Name} Недостаточно символов");
                            }
                        }

                        if (property.Name == "Password")
                        {
                            if (!minLength.IsValid(validatable.Password))
                            {
                                errors.Add($"{property.Name} Недостаточно символов");
                            }
                        }
                    }

                    if (a is RequiredAttribute required)
                    {
                        if (property.Name == "Login")
                        {
                            if (!required.IsValid(validatable.Login))
                            {
                                errors.Add($"{property.Name} Вы ничего не ввели");
                            }
                        }

                        if (property.Name == "Password")
                        {
                            if (!required.IsValid(validatable.Password))
                            {
                                errors.Add($"{property.Name} Вы ничего не ввели");
                            }
                        }

                    }
                }
            }

            return errors;
        }
    }
}
