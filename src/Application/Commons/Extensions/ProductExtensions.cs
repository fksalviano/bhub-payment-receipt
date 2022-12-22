using Application.Commons.Domain;

namespace Application.Commons.Extensions;

public static class ProductExtensions
{
    public static bool IsFisical(this Product product) => product.Type == ProductType.Fisical;

    public static bool IsBook(this Product product) => product.Type == ProductType.Book;

    public static bool IsVideo(this Product product) => product.Type == ProductType.Video;
}
