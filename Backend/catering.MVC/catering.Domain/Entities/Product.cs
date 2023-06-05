using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace catering.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string ImageName { get; set; } = default!;

        [NotMapped]
        public IFormFile ImageFile { get; set; } = default!;
        public void SetImageName()
        {
            ImageName = Path.GetFileNameWithoutExtension(ImageFile.FileName)
                + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(ImageFile.FileName);
        }
    }
}
