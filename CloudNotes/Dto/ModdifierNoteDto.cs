using System.ComponentModel.DataAnnotations;

namespace CloudNotes.Dto
{
    public class ModdifierNoteDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Titre { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
    }
}
