using AutoMapper;
using Jims_Managment_System_Or.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jims_Managment_System_Or.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly DataContext _con;
        private readonly IMapper _mapper;
        public CourseController(DataContext con, IMapper mapper)
        {
            _con = con;
            _mapper = mapper;
        }

        [HttpGet]

        public IEnumerable<Course> Get()
        {
            return _con.Courses.Select(co => _mapper.Map<Course>(co));
        }

        [HttpGet("Course Details")]
        public async Task<Course> Get(int Cid)
        {
            var co = await _con.Courses.FindAsync(Cid);
            return _mapper.Map<Course>(co);
        }

        [HttpPost]

        public IEnumerable<Course> AddData(Course loc)
        {
            _con.Courses.Add(_mapper.Map<Course>(loc));
            _con.SaveChanges();
            return _con.Courses.Select(co => _mapper.Map<Course>(co));

        }

        [HttpPut]
        public async Task<ActionResult<List<Course>>> UpdateAdmin(Course request)
        {
            var dbloc = _con.Courses.Where(Course => Course.Cid == request.Cid).Single();
            if (dbloc == null)
                return BadRequest("Not Found");
            else
                dbloc.Cid = request.Cid;
            dbloc.Name = request.Name;
            dbloc.Cfees = request.Cfees;
            dbloc.totalstudents = request.totalstudents;
            dbloc.duration = request.duration;
            await _con.SaveChangesAsync();
            return Ok(_con.Courses.Select(co => _mapper.Map<Course>(co)));
        }

        [HttpDelete("Delete Course")]
        public IEnumerable<Course> Delete(int Cid)
        {
            var item = _con.Courses.Where(Course => Course.Cid == Cid).Single();
            _con.Courses.Remove(item);
            _con.SaveChanges();
            return _con.Courses.Select(co => _mapper.Map<Course>(co));
        }
    }
}
