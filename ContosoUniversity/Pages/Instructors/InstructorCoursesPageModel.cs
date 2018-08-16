using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoUniversity.Models.SchoolViewModels;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Pages.Instructors
{
    public class InstructorCoursesPageModel : PageModel
    {
		public IList<AssignedCourseData> AssignedCourseDataList;

		public void PopulateAssignedCourseData(SchoolContext context, Instructor instructor)
		{
			var allCourses = context.Course;
			var instructorCourses = new HashSet<int>(instructor.CourseAssigments.Select(c => c.CourseID));
			AssignedCourseDataList = new List<AssignedCourseData>();
			foreach (var course in allCourses)
			{
				AssignedCourseDataList.Add(new AssignedCourseData
				{
					CourseID = course.CourseID,
					Title = course.Title,
					Assigned = instructorCourses.Contains(course.CourseID)
				});
			}
		}

		public void UpdateInstructorCourses(SchoolContext context, string[] selectedCourses, Instructor instructorToUpdate)
		{
			if (selectedCourses == null)
			{
				instructorToUpdate.CourseAssigments = new List<CourseAssignment>();
				return;
			}

			var selectedCoursesHS = new HashSet<string>(selectedCourses);
			var instructorCourses = new HashSet<int>(instructorToUpdate.CourseAssigments.Select(c => c.Course.CourseID));
			foreach (var course in context.Course)
			{
				if (selectedCoursesHS.Contains(course.CourseID.ToString()))
				{
					if (!instructorCourses.Contains(course.CourseID))
					{
						instructorToUpdate.CourseAssigments.Add(
							new CourseAssignment
							{
								InstructorID = instructorToUpdate.ID,
								CourseID = course.CourseID
							});
					}
				}
				else
				{
					if (instructorCourses.Contains(course.CourseID))
					{
						CourseAssignment courseToRemove = instructorToUpdate.CourseAssigments.SingleOrDefault(i => i.CourseID == course.CourseID);
						context.Remove(courseToRemove);
					}
				}
			}
		}
    }
}
