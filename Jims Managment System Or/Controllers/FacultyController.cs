using AutoMapper;
using Jims_Managment_System_Or.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Jims_Managment_System_Or.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly DataContext _con;
        private readonly IMapper _mapper;
        public FacultyController(DataContext con, IMapper mapper)
        {
            _con = con;
            _mapper = mapper;
        }

        [HttpGet]

        public IEnumerable<Faculty> Get()
        {
            return _con.Faculties.Select(fu => _mapper.Map<Faculty>(fu));
        }

        [HttpGet("Faculty Details")]
        public async Task<Faculty> Get(int Fid)
        {
            var co = await _con.Faculties.FindAsync(Fid);
            return _mapper.Map<Faculty>(co);
        }

        [HttpPost]

        public IEnumerable<Faculty> AddData(Faculty loc)
        {
            _con.Faculties.Add(_mapper.Map<Faculty>(loc));
            _con.SaveChanges();
            return _con.Faculties.Select(co => _mapper.Map<Faculty>(co));

        }

        [HttpPut]
        public async Task<ActionResult<List<Faculty>>> UpdateAdmin(Faculty request)
        {
            var dbloc = _con.Faculties.Where(Faculty => Faculty.Fid == Faculty.Fid).Single();
            if (dbloc == null)
                return BadRequest("Not Found");
            else
                dbloc.Fid = request.Fid;
            dbloc.Name = request.Name;
            dbloc.Number = request.Number;
            dbloc.Email = request.Email;
            dbloc.Department = request.Department;
            dbloc.Cid = request.Cid;
            await _con.SaveChangesAsync();
            return Ok(_con.Faculties.Select(co => _mapper.Map<Faculty>(co)));
        }

        [HttpDelete("Delete Faculty")]
        public IEnumerable<Faculty> Delete(int Fid)
        {
            var item = _con.Faculties.Where(Faculty => Faculty.Fid == Fid).Single();
            _con.Faculties.Remove(item);
            _con.SaveChanges();
            return _con.Faculties.Select(co => _mapper.Map<Faculty>(co));
        }
    }
}
