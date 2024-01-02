namespace IrelandLog.Models
{
    public class Pic
    {
        public int PicId { get; set; }
        public string PicName { get; set; } = string.Empty;
        public string? location { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        public string ThumbnailUrl { get; set; } = string.Empty;

        public Category Category { get; set; } = default!;

    }
}
