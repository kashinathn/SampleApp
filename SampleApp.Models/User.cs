using System.ComponentModel.DataAnnotations;
using SampleApp.Infrastructure;

namespace SampleApp.Models
{
    public class User : IEntityKey<int>
    {
        public virtual int Id { get; set; }
        [Display(Name = "User Name")]
        [Required]
        public virtual string Name { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [EmailAddress]
        public virtual string EmailAddress { get; set; }

        [Display(Name = "Address 1")]
        [Required]
        public virtual string AddressLine1 { get; set; }

        [Display(Name = "Address 2")]
        [Required]
        public virtual string AddressLine2 { get; set; }

        [Display(Name = "Post Code")]
        [Required]
        public virtual string PostCode { get; set; }

        [Display(Name = "Created Date")]
        public virtual string CreatedDate { get; set; }
    }
}
