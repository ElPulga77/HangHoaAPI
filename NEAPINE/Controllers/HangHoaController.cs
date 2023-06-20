using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEAPINE.Models;
using System;
using System.Linq;

namespace NEAPINE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private quanlyhoadonContext db = new quanlyhoadonContext();
        [HttpGet]
        public IActionResult getDShanghoa()
        {
            try
            {
                return Ok(db.Hanghoas.ToList());
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult getHanghoa(string id) 
        {
            try
            {
                Hanghoa a = db.Hanghoas.Find(id);
                if (a == null) return NotFound();
                else return Ok(a);  
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult deleteHanghoa(string id)
        {
            try
            {
                Hanghoa a = db.Hanghoas.Find(id);
                if (a == null) return NotFound();
                else
                {
                    db.Hanghoas.Remove(a);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult postHanghoa(Hanghoa hh)
        {
            try
            {
                db.Hanghoas.Add(hh);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult putHanghoa(Hanghoa hh)
        {
            try
            {
                Hanghoa x = db.Hanghoas.Find(hh.Mahang);
                if(x==null)
                return NotFound();
                x.Tenhang = hh.Tenhang;
                x.Dvt = hh.Dvt;
                x.Dongia = hh.Dongia;
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("hoadon")]
        public IActionResult getDSHoadon()
        {
            try
            {
                return Ok(db.Hoadons.ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("hoadon")]
        public IActionResult postHoadon(Hoadon hd)
        {
            try
            {
                db.Hoadons.Add(hd);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
