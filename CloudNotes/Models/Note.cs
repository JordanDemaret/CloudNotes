namespace CloudNotes.Models
{
    public record Note
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Description { get; set; } = string.Empty;
    }
}
        
