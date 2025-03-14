namespace Application.CQRS.Cars.Commands.Responses;

public class AddCarResponse
{
    public string Model { get; set; }
    public string Vendor { get; set; }
    public DateTime Year { get; set; }
    public decimal IntitialPrice { get; set; }
}
