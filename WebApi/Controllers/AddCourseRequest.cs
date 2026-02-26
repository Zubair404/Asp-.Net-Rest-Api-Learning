using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{
    public class AddCourseRequest
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Department { get; set; }
        public string? ProfessorFirstName { get; set; }
        public string? ProfessorLastName { get; set; }
    }
}
