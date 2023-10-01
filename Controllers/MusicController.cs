using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MusicController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMusic()
        {
            var musicDetails = await _context.Music.ToListAsync();
            return Ok(musicDetails);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneMusic(int id)
        {
            var music = await _context.Music.FindAsync(id);
            if (music == null)
            {
                return NotFound(new { message = "Music Details don't exist." });
            }
            return Ok(music);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewMusic(MusicViewModel music)
        {


            await _context.Music.AddAsync(music);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOneMusic), new { id = music.Id }, music);


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            var music = await _context.Music.FindAsync(id);
            if (music == null)
            {
                return NotFound(new { message = "Music Details do not exist" });
            }
            _context.Music.Remove(music);
            await _context.SaveChangesAsync();
            return Ok(music);
        }
    }
}