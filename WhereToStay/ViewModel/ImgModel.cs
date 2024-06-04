using WhereToStay.Models;

namespace WhereToStay.ViewModel
{
    public class ImgModel
    {
        public int image_id { get; set; }
        public byte[]? img { get; set; }

        public string? description { get; set; }

        public IFormFile UploadedImage { get; set; }

    }
}
