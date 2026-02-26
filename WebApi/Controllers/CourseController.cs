using System.Collections.Generic;
using System.Linq;
using Asp_.Models.Courses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Courses;
using Services.Courses;
using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<CourseDto>> GetList([FromQuery]GetCourseListRequest request)
        {
            var svcCourses = _courseService.GetCourseList(request.Skip ?? 0, request.Take ?? 25, request.Search);// ?? new Course[0];
            var courseDto = svcCourses.Select(c => _mapper.Map<CourseDto>(c)).ToList();

            if (!courseDto.Any())
                return NotFound();

            return Ok(courseDto);
        }
        [HttpGet]
        [Route("{courseId:int}")]
        public ActionResult<CourseDto> GetCourse(int courseId)
        {
            var svcCourse = _courseService.GetCourse(courseId);
            if (svcCourse == null)
                return NotFound();

            var courseDto = _mapper.Map<CourseDto>(svcCourse);
            return Ok(courseDto);
        }
        [HttpPost]
        public ActionResult<CourseDto> CreateCourse([FromBody] AddCourseRequest request)
        {
            var courseEntity = _mapper.Map<Course>(request);
            var id = _courseService.AddCourse(courseEntity);
            var course = _courseService.GetCourse(id);
            var courseDto = _mapper.Map<CourseDto>(course);

           return CreatedAtAction(nameof(GetCourse), new { courseId = id }, courseDto);
        }
        [HttpDelete]
        [Route("{courseId:int}")]
        public IActionResult DeleteCourse(int courseId)
        {
            if (!_courseService.DoesCourseExists(courseId))
                return NotFound();

            _courseService.DeleteCourse(courseId);
            return NoContent();
        }
        [HttpPut]
        [Route("{courseId:int}")]
        public IActionResult UpdateCourse([FromRoute]int courseId, [FromBody] UpdateCourseRequest request)
        {
            var existingCourse = _courseService.GetCourse(courseId);
            if (existingCourse == null)
                return NotFound();

            var courseEntity = _mapper.Map<Course>(request);
            courseEntity.Id = courseId;
            _courseService.UpdateCourse(courseEntity);
            return NoContent();
        }
    }

}
