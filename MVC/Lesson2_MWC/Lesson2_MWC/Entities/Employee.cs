using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Lesson2_MWC.Entities
{
    public class Employee
    {
        [Range(1,20)]
        public int Id { get; set; }

        [Required]
        [DisplayName("User name")]
        public string Firstname { get; set; }

        [Required]
        [DisplayName("User surname")]
        public string Lastname { get; set; }

        public int Cityİd {  get; set; }
    }
}
