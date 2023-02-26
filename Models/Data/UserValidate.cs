using System.ComponentModel.DataAnnotations;
using TicketsAPI.Models.Repository;

namespace TicketsAPI.Models.Data
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class UserValidate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = ValidationResult.Success;
            string[] memberNames = new string[] { validationContext.MemberName };

            var _dbContext = (ApplicationDBContext)validationContext
                         .GetService(typeof(ApplicationDBContext));

            UserRepository _userRepository = new UserRepository(_dbContext);
            User user = _userRepository.GetByIdAsync(Convert.ToInt32(value));

            if(user is null)
                result = new ValidationResult(string.Format(this.ErrorMessage, 1000), memberNames);

            return result;
        }
    }
}
