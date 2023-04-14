using AutoMapper;
using Jims_Managment_System_Or.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jims_Managment_System_Or.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _con;
        private readonly IMapper _mapper;
        public StudentController(DataContext con, IMapper mapper)
        {
            _con = con;
            _mapper = mapper;
        }

        [HttpGet]

        public IEnumerable<Students> Get()
        {
            return _con.Studentss.Select(fu => _mapper.Map<Students>(fu));
        }

        [HttpGet("Students Details")]
        public async Task<Students> Get(int Sid)
        {
            var co = await _con.Studentss.FindAsync(Sid);
            return _mapper.Map<Students>(co);
        }

        [HttpPost]

        public IEnumerable<Students> AddData(Students loc)
        {
            _con.Studentss.Add(_mapper.Map<Students>(loc));
            _con.SaveChanges();
            return _con.Studentss.Select(co => _mapper.Map<Students>(co));

        }

        [HttpPut]
        public async Task<ActionResult<List<Students>>> UpdateAdmin(Students request)
        {
            var dbloc = _con.Studentss.Where(Students => Students.Sid == Students.Sid).Single();
            if (dbloc == null)
                return BadRequest("Not Found");
            else
                dbloc.Sid = request.Sid;
            dbloc.Name = request.Name;
            dbloc.Number = request.Number;
            dbloc.Email = request.Email;
            dbloc.Cid = request.Cid;
            dbloc.Attendance = request.Attendance;
            dbloc.totalpercentage = request.totalpercentage;
            await _con.SaveChangesAsync();
            return Ok(_con.Studentss.Select(co => _mapper.Map<Students>(co)));
        }

        [HttpDelete("Delete Student")]
        public IEnumerable<Students> Delete(int Sid)
        {
            var item = _con.Studentss.Where(Students => Students.Sid == Sid).Single();
            _con.Studentss.Remove(item);
            _con.SaveChanges();
            return _con.Studentss.Select(co => _mapper.Map<Students>(co));
        }
    }
}
