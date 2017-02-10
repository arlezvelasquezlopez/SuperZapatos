using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.InventoryControl.Contracts.ServiceLibrary.Contracts
{
    public interface IStoreAppplicationService
    {
        IEnumerable<StoreDTO> GetAll();
        StoreDTO FindById(int id);
        int Create(StoreDTO storeDto);
        int Delete(int id);
        int Update(StoreDTO storeDto);
    }
}
