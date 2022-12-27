namespace Application.Commons.Domain;

public class Video
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Video? TutorialVideo { get; set; }
}
