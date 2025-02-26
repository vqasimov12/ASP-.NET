using Web_intro.DTOs.ShipperDTOs;
using Web_intro.Entities;
using Web_intro.Repositories;

namespace Web_intro.Services;

public class ShipperService(IShipperRepository repository) : IShipperService
{
    private readonly IShipperRepository _repository = repository;

    public Shipper AddShipper(AddShipperDTO shipper)
    {
        var newShipper = new Shipper()
        {
            Phone = shipper.Phone,
            CompanyName = shipper.CompanyName,
        };
        _repository.Add(newShipper);
        return newShipper;

    }

    public List<Shipper> GetAll() => [.. _repository.GetAll()];

    public Shipper GetShipper(int id)=>_repository.Get(id);

    public bool RemoveShipper(int id)
    {
        _repository.Delete(id);
        return true;
    }

    public bool Update(UpdateShipperDTO shipper)
    {
        var currentShipper = _repository.Get(shipper.ShipperId);
        currentShipper.Phone = shipper.Phone;
        currentShipper.CompanyName = shipper.ShipperName;
        _repository.Update(currentShipper);
        return true;
    }
}