namespace Application.Commons.Domain;

public class Product
{
    public string Name { get; set; } = null!;
    public ProductType Type { get; set; }
    public Video? Video { get; set; }
}
