namespace CloudNotes.Entities
{
    public record Note
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Titre { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
        
