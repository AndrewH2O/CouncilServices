using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CouncilServices.Models
{
    public enum CustomerType
    {
        Citizen=1, Organization=2, Anonymous=3
    }

    public enum Service
    {
        Housing=1,

        Benefits =2,

        [Display(Name = "Council Tax")]
        CouncilTax =3,

        [Display(Name = "Fly Tipping")]
        FlyTipping =4,

        [Display(Name = "Missed Bin")]
        MissedBin =5 
    }

    public enum Title
    {
        Mr=1,Mrs=2,Ms=3
    }

    public class Customer:IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Select a service")]
        public Service Service { get; set; }

        [Display(Name = "Customer")]
        [Required]
        [Range(1,3,ErrorMessage="Select a customer type")]
        public CustomerType CustomerType { get; set; }
        
        
        public Title? Title { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Organisation { get; set; }

        //"General date short time" format specifier
        [Display(Name = "Queued At:")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime QueuedAt { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(CustomerType == CustomerType.Citizen)
            {
                if (Title == null||Title == 0)
                {
                    yield return new ValidationResult("Select a title", new[] { "Title" });
                }

                if (FirstName == null || FirstName == "")
                {
                    yield return new ValidationResult("Select a first name", new[] { "FirstName" });
                }

                if (LastName == null || LastName == "")
                {
                    yield return new ValidationResult("Select a last name", new[] { "LastName" });
                }
            }

            if (CustomerType == CustomerType.Organization)
            {
                if (Organisation == null || Organisation == "")
                {
                    yield return new ValidationResult("Select an Organisation", new[] { "Organisation" });
                }
            }

            if (CustomerType == 0)
            {
                yield return new ValidationResult("Select a customer type", new[] { "CustomerType" });
            }
        }
    }
}