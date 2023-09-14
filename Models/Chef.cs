
#pragma warning disable CS8618  //#1

using System.ComponentModel.DataAnnotations;  //connected to line 11 this will bring itself in when iadd the KEY

namespace ChefsN.Models;

public class Chef
{
    [Key]
    public int ChefID { get; set; }

    [Required(ErrorMessage = "First Name is required")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    //past & minimum 

    [Required(ErrorMessage = "Date of Birth is required")]
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    [PastDate(ErrorMessage = "Date of Birth must be in the past")]
    [MinimumAge(18, ErrorMessage = "Chef must be at least 18 years old")]
    public DateTime DateOfBirth { get; set; }

    public int Age()
    {
        TimeSpan Dif = DateTime.Now - DateOfBirth;
        return Dif.Days/365;
    }
    public List<Dish> Dishes { get; set; } = new(); // Navigation property for the Chef's dishes
}


//PastAtt to uses in the model
public class PastDateAttribute : ValidationAttribute
{
    //is called during validation and is where you define your custom validation logic.
    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    {

        DateTime Input = (DateTime)value;
        DateTime Now = DateTime.Now; //This gets the current date and time.

        if (Input > Now)  //input date is greater than the current date (
        {
            return new ValidationResult("Date must be in the past");  // checks if the validation is good to go
        }
        else
        {
            return ValidationResult.Success; //everything is good to go
        }

    }

}



//MinimumAgeAtt
public class MinimumAgeAttribute : ValidationAttribute  //checks if a person who is at least a certain age 18
{
    private readonly int _minimumAge; //stores the minimum age requirement

    public MinimumAgeAttribute(int minimumAge)  //is called during validation and contains the custom logic
    {
        _minimumAge = minimumAge;
    }

    protected override ValidationResult? IsValid(object value, ValidationContext validationContext)  //defines the custom validation rules 
    {
        if (value is DateTime dateOfBirth)  //It checks if the property value is a DateTime
        {
            var today = DateTime.Today; //gets the current date
            var age = today.Year - dateOfBirth.Year; //this is clculating the age of the person
            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }

            if (age < _minimumAge)
            {
                return new ValidationResult($"Chef must be at least {_minimumAge} years old"); //Validation showing that the person is under 18
            }
        }

        return ValidationResult.Success; //this was successful and able to go
    }
}









