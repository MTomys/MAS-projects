using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Associations.Composition;
using SecondMiniProject.Associations.Composition.Impl;
using SecondMiniProject.Interfaces;

namespace SecondMiniProject.Tests.CompositionAssociation;

public class CompositionAssociationTestModelBuilder
{
    private static readonly int StorageUnitId = 1;
    private static readonly double StorageUnitCapacity = 2.5;
    private static readonly string StorageUnitName = "StorageUnitTestName";

    private static readonly int StorageHouseId = 1;
    private static readonly string StorageHouseName = "StorageHouseTestName";
    private static readonly string StorageHouseLocation = "StorageHouseTestLocation";

    private static readonly IReferenceManager<StorageUnit, StorageHouse> ReferenceManager = new StorageHouseReferenceManagerImpl();
        
    public static StorageUnit GetStorageUnit()
    {
        return new StorageUnit(StorageUnitId, StorageUnitCapacity, StorageUnitName, GetStorageHouse(), ReferenceManager);
    }
    public static StorageUnit GetStorageUnitWithSpecificStorageHouse(StorageHouse storageHouse)
    {
        return new StorageUnit(StorageUnitId, StorageUnitCapacity, StorageUnitName, storageHouse, ReferenceManager);
    }

    public static StorageHouse GetStorageHouse()
    {
        return new StorageHouse(StorageHouseId, StorageHouseName, StorageHouseLocation);
    }

    public static StorageHouse GetSecondStorageHouse()
    {
        return new StorageHouse(StorageHouseId + 1, $"Second{StorageHouseName}", $"Second{StorageHouseLocation}");
    }

}
