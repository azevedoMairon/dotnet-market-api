using IWantApp.Repository.Data;

namespace IWantApp.Endpoints.Category;

public class CategoryPost
{
    public static string Template => "/categories";

    public static string[] Methods => new string[] {HttpMethod.Post.ToString()};
    // public static Delegate Handle => Action;

    public IResult Action(CategoryRequest categoryRequest, ApplicationDbContext applicationDbContext)
    {
        return Results.Ok("Ok");
    }
}
