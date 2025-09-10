namespace BeauProject.Shared.Application.DTOs.Files
{
    public class FilesDto
    {
        public string EntityName { get; set; }
        public string EntityId { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public byte[]? FileContent { get; set; }
        public string? FilePath { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
