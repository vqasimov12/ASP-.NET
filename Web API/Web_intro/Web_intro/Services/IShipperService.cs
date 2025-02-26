using Web_intro.DTOs.ShipperDTOs;
using Web_intro.Entities;

namespace Web_intro.Services;

public interface IShipperService
{
    Shipper AddShipper(AddShipperDTO shipper);
    bool RemoveShipper(int id);
    Shipper GetShipper(int id);
    List<Shipper> GetAll();
    bool Update(UpdateShipperDTO shipper);
}