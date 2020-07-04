namespace indorizaikaDataService.Models
{
    public class RecipeDetailModel
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string VideoPath { get; set; }
        public string ThumbnailPath { get; set; }
        public string FullImagePath { get; set; }
    }
}
