using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student
    {
		public int ID { get; set; }
		[Required]
		[StringLength(50)]
		public string LastName { get; set; }
		[Required]
		[StringLength(50, ErrorMessage = "First name connot be longer than 50 characters.")] // limit input to 50 characters and provides validation [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")] 
		[Column("FirstName")]
		[Display(Name = "First Name")]
		public string FirstMidName { get; set; } // [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")] would apply restrictions to the input, in this case first letter should be Uppercase followed by alphabetical characters
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "Enrollment Date")]
		public DateTime EnrollmentDate { get; set; }
		[Display(Name = "Full Name")]
		public string FullName
		{
			get
			{
				return LastName + ", " + FirstMidName;
			}
		}
		public ICollection<Enrollment> Enrollments { get; set; }
	}
}
