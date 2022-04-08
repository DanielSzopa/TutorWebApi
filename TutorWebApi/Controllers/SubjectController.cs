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
        public async Task<ActionResult> Create([FromBody] NewSubjectDto newSubjectDto)
        {
            await _subjectService.CreateSubject(newSubjectDto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update([FromBody] NewSubjectDto newSubjectDto, [FromRoute]int id)
        {           
            await _subjectService.UpdateSubject(newSubjectDto,id);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<SubjectDto>>> Get()
        {
            var subjects = await _subjectService.GetAllSubjects();
            return Ok(subjects);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            await _subjectService.DeleteSubject(id);
            return NoContent();
        }
      
    }
}
