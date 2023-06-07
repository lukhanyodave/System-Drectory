namespace DirFileLocation.Models
{
    public class DirFileInfo
    {
        public int id { get; set; }
        public string Path { get; set; } = string.Empty;
        public long Size { get; set; }
        public string Attributes { get; set; } = string.Empty;
    }
}
