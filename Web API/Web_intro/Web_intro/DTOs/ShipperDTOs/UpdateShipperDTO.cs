namespace Web_intro.DTOs.ShipperDTOs;

public record UpdateShipperDTO
{
    public int ShipperId { get; set; }
    public string ShipperName { get; }
    public string Phone { get; set; }

}
