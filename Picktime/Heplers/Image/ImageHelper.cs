﻿namespace Picktime.Heplers.Image
{
    public class ImageHelper
    {
        public static async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            // if (imageFile == null || imageFile.Length == 0)
            //  throw new ArgumentException("Invalid image file");

            if (imageFile == null || imageFile.Length == 0)
            {
                return null;
            }

            string fileName = Guid.NewGuid().ToString() + "-" + imageFile.FileName;
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            using (var fs = new FileStream(Path.Combine(directory, fileName), FileMode.Create))
            {
                await imageFile.CopyToAsync(fs);
            }

            return $"/uploads/{fileName}";
        }
    }
}
