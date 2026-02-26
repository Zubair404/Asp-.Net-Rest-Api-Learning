using System;
using Microsoft.VisualBasic;

namespace WebApi.Controllers
{
    public class GetCourseListRequest
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public string? Search { get; set; }
    }
}
