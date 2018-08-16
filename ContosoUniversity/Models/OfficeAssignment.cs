using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
		[Key]
		public int InstructorID { get; set; }
		[StringLength(50)]
		[Display(Name = "Office Location")]
		public string Location { get; set; }

		[Required] // unnecessary because we already require the InstructorID, but just to point out that OfficeAssigment only exists if it has an Instructor assigned
		public Instructor Instructor { get; set; }
    }
}
