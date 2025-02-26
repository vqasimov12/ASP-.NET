using Web_intro.Entities;

namespace Web_intro.Repositories;

public interface IShipperRepository
{
    void Add(Shipper shipper);
    void Update(Shipper shipper);
    void Delete(int id);
    Shipper Get(int id);
    IQueryable<Shipper> GetAll();
}
