using Web_intro.Context;
using Web_intro.Entities;

namespace Web_intro.Repositories;

public class ShipperRepository(AppDbContext appDbContext) : IShipperRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public void Add(Shipper shipper)
    {
        _appDbContext.Add(shipper);
        _appDbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var shipper = _appDbContext.Shippers.FirstOrDefault(x => x.ShipperID == id);
        if (shipper is null)
            return;
        _appDbContext.Shippers.Remove(shipper);
        _appDbContext.SaveChanges();
    }

    public IQueryable<Shipper> GetAll() => _appDbContext.Shippers;

    public Shipper Get(int id) => _appDbContext.Shippers.FirstOrDefault(x => x.ShipperID == id)!;

    public void Update(Shipper shipper)
    {
        _appDbContext.Shippers.Update(shipper);
        _appDbContext.SaveChanges();
    }
}
