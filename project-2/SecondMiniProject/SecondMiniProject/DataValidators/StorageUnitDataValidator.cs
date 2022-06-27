using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Associations.Composition;
using SecondMiniProject.CommonMessages;
namespace SecondMiniProject.DataValidators;

public class StorageUnitDataValidator
{
    public static bool ValidateStorageUnitName(string name)
    {
        if (String.IsNullOrEmpty(name))
        {
            throw new ArgumentException(CommonErrorMessages.GetInvalidStorageUnitNameMessage(name)); 
        }
        return true;
    }

    public static bool ValidateStorageUnitCapacity(double capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException(CommonErrorMessages.GetInvalidStorageUnitCapacityMessage(capacity));
        }
        return true;
    }

    public static bool ValidateStorageUnitStorageHouse(StorageHouse storageHouse)
    {
        ArgumentNullException.ThrowIfNull(storageHouse, CommonErrorMessages.GetInvalidStorageUnitStorageHouseMessage());
        return true;
    }

    public static bool CheckIfStorageHouseDoesNotContainDuplicate(StorageUnit storageUnit, StorageHouse storageHouse)
    {
        if (storageHouse.StorageUnits.Contains(storageUnit))
        {
            throw new ArgumentException(CommonErrorMessages.GetInvalidStorageUnitStorageHouseHasDuplicateMessage());
        }
        return true;
    }
}
