namespace Pedeai.App.Catalog.Restaurants.Entities
{
  public class RestaurantEntity(
    string name,
    string fantasyName,
    string cnpj
  ) {
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = name;
    public string FantasyName { get; set; } = fantasyName;
    public string Cnpj { get; set; } = cnpj;
    public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; private set; }
  }
}