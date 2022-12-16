using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppAPICrud.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppAPICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSearchController : ControllerBase
    {
        private readonly DataContext _context;
        public UserSearchController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUserSearch(string? city = "", string? gender = "", int? before = null, int? after = null, DateTime? time = null)
        {
            //только город
            if (city != "" & gender == "" & before == null & after == null && time == null)
            {
                var users = await _context.Users.Where(u => u.City == city).ToListAsync();
                
                return Ok(users);
            }
            //пол и город
            if (city != "" & gender != "" & before == null & after == null & time == null)
            {
                var users = await _context.Users.Where(u => u.City == city && u.Gender == gender).ToListAsync();
                return Ok(users);
            }

             //пол город и возраст от
             if (city != "" & gender != "" & before != null & after == null && time == null)
             {
                 var users = await _context.Users.Where(u => u.City == city && u.Gender == gender && u.Age >= before).ToListAsync();
                 
                 return Ok(users);
             }
             //пол город и возраст до 
             if (city != "" & gender != "" & before == null & after != null && time == null)
             {
                 var users = await _context.Users.Where(u => u.City == city && u.Gender == gender && u.Age <= after).ToListAsync();
                 
                 return Ok(users);
             }
             //Всё кроме время
             if (city != "" & gender != "" & before != null & after != null & time == null)
             {
                 var users = await _context.Users.Where(
                     u => u.City == city && u.Gender == gender && (u.Age >= before && u.Age <= after)).ToListAsync();
                
                return Ok(users);
             }
             //Только гендр
             if (city == "" & gender != "" & before == null & after == null & time == null)
             {
                 var users = await _context.Users.Where(
                     u => u.Gender == gender ).ToListAsync();
                 
                 return Ok(users);
              }
             //Только время
             if (city == "" & gender == "" & before == null & after == null & time != null)
             {
                 var users = await _context.Users.Where(u => u.DataRegistration == time).ToListAsync();
                 
                 return Ok(users);
             }
             // Город и время
             if (city != "" & gender == "" & before == null & after == null & time != null)
             {
                 var users = await _context.Users.Where(u => u.City == city && u.DataRegistration == time).ToListAsync();
                 
                 return Ok(users);
             }
             // Город и время и гендер
             if (city != "" & gender != "" & before == null & after == null & time != null)
             {
                 var users = await _context.Users.Where(u => u.City == city && u.Gender == gender && u.DataRegistration == time).ToListAsync();
                 
                 return Ok(users);
             }
             
             // Город и время и гендер и время от
             if (city != "" & gender != "" & before != null & after == null & time != null)
             {
                 var users = await _context.Users.Where(
                     u => u.City == city && u.Gender == gender && u.DataRegistration == time && u.Age >= before).ToListAsync();
                 
                 return Ok(users);
              }

             // Город и время и гендер и время до
             if (city != "" & gender != "" & before == null & after != null & time != null)
             {
                 var users = await _context.Users.Where(
                     u => u.DataRegistration == time && u.City == city && u.Gender == gender && u.Age <= after).ToListAsync();
                 
                 return Ok(users);
             }
             
             //Город и время,  возраст от
             if (city != "" & gender == "" & before != null & after == null & time != null)
             {
                 var users = await _context.Users.Where(
                     u => u.DataRegistration == time && u.City == city && u.Age >= before).ToListAsync();
                 
                 return Ok(users);
             }
             
             //Город и время,  возраст до
             if (city != "" & gender == "" & before == null & after != null & time != null)
             {
                 var users = await _context.Users.Where(
                      u => u.DataRegistration == time && u.City == city && u.Age <= after).ToListAsync();
                
                 return Ok(users);
             }

            //Время и ОТ
            if (city == "" & gender == "" & before != null & after == null & time != null)
            {
                var users = await _context.Users.Where(
                      u => u.DataRegistration == time && u.Age >= before).ToListAsync();

                return Ok(users);
            }
           
             
             //Время и ДО
             if (city == "" & gender == "" & before == null & after != null & time != null)
             {
                 var users = await _context.Users.Where(
                       u => u.DataRegistration == time && u.Age <= after).ToListAsync();
                 
                 return Ok(users);
             }
             
             //Гендр и время
             if (city == "" & gender != "" & before == null & after == null & time != null)
             {
                 var users = await _context.Users.Where(
                       u => u.DataRegistration == time && u.Gender == gender).ToListAsync();
                
                 return Ok(users);
              }
             //Гендр ОТ
             if (gender != "" && city == "" & before != null & after == null && time == null)
             {
                 var users = await _context.Users.Where(
                       u => u.Gender == gender && u.Age >= before).ToListAsync();
                 
                  return Ok(users);
              }
             
             //Гендр и возраст только до
             if (gender != "" && city == "" && before == null && after != null && time == null)
             {
                 var users = await _context.Users.Where(
                       x => x.Gender == gender && x.Age <= after).ToListAsync();
                 
                 return Ok(users);
              }
             
             //гендр и возраст от до
             if (gender != "" && city == "" & before != null & after != null && time == null)
             {
                 var users = await _context.Users.Where(
                       u => u.Gender == gender && (u.Age >= before && u.Age <= after)).ToListAsync();
                 return Ok(users);
             }
             //Город и возраст от
             if (gender == "" && city != "" & before != null & after == null && time == null)
             {
                 var users = await _context.Users.Where(
                       u => u.City == city && u.Age >= before).ToListAsync();
                 
                  return Ok(users);
             }

             //Город и возраст от до
             if (gender == "" && city != "" & before != null & after != null && time == null)
             {
                 var users = await _context.Users.Where(
                      u => u.City == city && (u.Age >= before && u.Age <= after)).ToListAsync();
                  return Ok(users);
             }
             //возраст от
             if (gender == "" && city == "" & before != null & after == null && time == null)
             {
                 var users = await _context.Users.Where(
                      u => (u.Age >= before)).ToListAsync();
                 
                  return Ok(users);
             }
             //вораста до
             if (gender == "" && city == "" & before == null & after != null && time == null)
             {
                 var users = await _context.Users.Where(
                      u => (u.Age <= after)).ToListAsync();
                 
                  return Ok(users);
             }
             //от и до
             if (gender == "" && city == "" & before != null & after != null && time == null)
             {
                var users = await _context.Users.Where(x => (x.Age >= before && x.Age <= after)).ToListAsync();
                 return Ok(users);
             }
            return BadRequest("Not found ");
        }
    }
}
