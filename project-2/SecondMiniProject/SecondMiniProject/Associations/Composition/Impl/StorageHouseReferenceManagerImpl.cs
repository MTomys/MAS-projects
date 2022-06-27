using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Interfaces;

namespace SecondMiniProject.Associations.Composition.Impl;

public class StorageHouseReferenceManagerImpl : IReferenceManager<StorageUnit, StorageHouse>
{
    public void AddNewReference(StorageUnit storageUnit, StorageHouse storageHouse)
    {
        storageHouse.StorageUnits.Add(storageUnit);
    }

    public void DeleteCurrentReference(StorageUnit storageUnit, StorageHouse storageHouse)
    {
        throw new NotImplementedException();
    }

    public void DeleteCurrentReference(StorageUnit storageUnit)
    {
        storageUnit.StorageHouse.StorageUnits.Remove(storageUnit);
    }

    public void ReplaceCurrentReference(StorageUnit storageUnit, StorageHouse storageHouse)
    {
        DeleteCurrentReference(storageUnit);
        AddNewReference(storageUnit, storageHouse);
    }
}
