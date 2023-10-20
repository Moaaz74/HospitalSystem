using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models.Validation
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;
        public MinimumAgeAttribute(int MinimumAge) 
        {
            _minimumAge = MinimumAge;
        }

        public override bool IsValid(object? value)
        {
            if(value != null && value is DateTime date)
            {
                return date.Year >= _minimumAge;
            }return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"You must be at least {_minimumAge} years old to register.";
        }


    }
}
