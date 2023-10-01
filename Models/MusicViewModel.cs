using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class MusicViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Artist Name is required")]
        public string ArtistName { get; set; }
        [Required(ErrorMessage = "Song Name is required")]
        public string SongName { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }
    }
}