using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Subject;

namespace TutorWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]   
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateSubject([FromBody] NewSubjectDto newSubjectDto)
        {
            await _subjectService.CreateSubject(newSubjectDto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateSubject([FromBody] NewSubjectDto newSubjectDto, [FromRoute]int id)
        {           
            await _subjectService.UpdateSubject(newSubjectDto,id);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetSubjects()
        {
            var subjects = await _subjectService.GetAllSubjects();
            return Ok(subjects);
        }
      
    }
}
