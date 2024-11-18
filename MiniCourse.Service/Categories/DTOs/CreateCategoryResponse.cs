namespace MiniCourse.Service.Categories.DTOs
{
    public record CreateCategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
