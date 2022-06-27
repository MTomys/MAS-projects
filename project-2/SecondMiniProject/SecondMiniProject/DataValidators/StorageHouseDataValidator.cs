using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Associations.Composition;
using SecondMiniProject.CommonMessages;

namespace SecondMiniProject.DataValidators;

public class StorageHouseDataValidator
{
    public static bool ValidateStorageHouseName(string name)
    {
        if (String.IsNullOrEmpty(name))
        {
            throw new ArgumentException(CommonErrorMessages.GetInvalidStorageHouseNameMessage(name));
        }
        return true;
    }

    public static bool ValidateStorageHouseLocation(string location)
    {
        if (String.IsNullOrEmpty(location))
        {
            throw new ArgumentException(CommonErrorMessages.GetInvalidStorageHouseLocationMessage(location));
        }
        return true;
    }

    public static bool ValidateStorageUnit(StorageUnit storageUnit)
    {
        ArgumentNullException.ThrowIfNull(storageUnit, CommonErrorMessages.GetInvalidStorageHouseStorageUnitMessage());
        return true;
    }
}
