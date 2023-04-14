using AutoMapper;
using Jims_Managment_System_Or.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jims_Managment_System_Or.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _con;
        private readonly IMapper _mapper;
        public AdminController(DataContext con, IMapper mapper)
        {
            _con = con;
            _mapper = mapper;
        }

        [HttpGet]

        public IEnumerable<Admin> Get()
        {
            return _con.Admins.Select(ad => _mapper.Map<Admin>(ad));
        }

        [HttpGet("Admin Details")]
        public async Task<Admin> Get(int AdminId)
        {
            var ad = await _con.Admins.FindAsync(AdminId);
            return _mapper.Map<Admin>(ad);
        }

        [HttpPost]

        public IEnumerable<Admin> AddData(Admin loc)
        {
            _con.Admins.Add(_mapper.Map<Admin>(loc));
            _con.SaveChanges();
            return _con.Admins.Select(ad => _mapper.Map<Admin>(ad));

        }

        [HttpPut]
        public async Task<ActionResult<List<Admin>>> UpdateAdmin(Admin request)
        {
            var dbloc = _con.Admins.Where(Admins => Admins.AdminId == request.AdminId).Single();
            if (dbloc == null)
                return BadRequest("Not Found");
            else
                dbloc.AdminId = request.AdminId;
                dbloc.Name = request.Name;
                dbloc.Number = request.Number;
                dbloc.Email = request.Email;
                await _con.SaveChangesAsync();
                return Ok(_con.Admins.Select(ad => _mapper.Map<Admin>(ad)));
        }

        [HttpDelete("Delete Admins")]
        public IEnumerable<Admin> Delete(int AdminId)
        {
            var item = _con.Admins.Where(Admins => Admins.AdminId == AdminId).Single();
            _con.Admins.Remove(item);
            _con.SaveChanges();
            return _con.Admins.Select(ad => _mapper.Map<Admin>(ad));
        }
    }
}
