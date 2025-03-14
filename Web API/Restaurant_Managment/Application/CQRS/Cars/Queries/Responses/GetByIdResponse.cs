namespace Application.CQRS.Cars.Queries.Responses;

public record GetByIdResponse
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string Vendor { get; set; }
    public DateTime Year { get; set; }
    public decimal InitialPrice { get; set; }
}
