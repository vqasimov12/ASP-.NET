using Ecommerce.Application.Abstract;
using Ecommerce.DataAccess.Abstract;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Concrete;

public class SupplierService(ISupplierDal supplierDal) : ISupplierService
{
    private readonly ISupplierDal _supplierDal = supplierDal;
    public List<Supplier> GetAll()=> _supplierDal.GetList();
    public Supplier GetById(int id) => _supplierDal.Get(x => x.SupplierId == id);
    public void Add(Supplier supplier) => _supplierDal.Add(supplier);
    public void Update(Supplier supplier) => _supplierDal.Update(supplier);
    public void Delete(int id)
    {
        var supplier = _supplierDal.Get(x => x.SupplierId == id);
        _supplierDal.Delete(supplier);
    }
}
