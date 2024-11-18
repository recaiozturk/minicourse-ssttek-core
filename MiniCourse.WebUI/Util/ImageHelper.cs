namespace MiniCourse.WebUI.Util
{
    public class ImageHelper
    {
        public static async Task<string> AddImageAsync(IFormFile imageFile)
        {
            var fileName = Path.GetFileName(imageFile.FileName);
            var newIamgeName=Guid.NewGuid().ToString() + "_" + fileName.Replace(" ", ""); ;
            var filePath = Path.Combine("wwwroot/img", newIamgeName.ToString());

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return newIamgeName;
        }

        public static void DeleteOldImage(string fileName)
        {

            if(fileName == null) return;

            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
            string filePath = Path.Combine(imagePath, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
