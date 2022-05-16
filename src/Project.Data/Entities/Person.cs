namespace Project.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTimeOffset DOB { get; set; }
    }
}