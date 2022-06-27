using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecondMiniProject.Associations.Composition;
using SecondMiniProject.DataValidators;

namespace SecondMiniProject.Associations.Composition;

public class StorageHouse
{
    private readonly int _id;
    private string _name;
    private string _location;
    private readonly ISet<StorageUnit> _storageUnits;

    public StorageHouse(int id, string name, string location)
    {
        _id = id;

        if (StorageHouseDataValidator.ValidateStorageHouseName(name))
        {
            _name = name;
        }

        if (StorageHouseDataValidator.ValidateStorageHouseLocation(location))
        {
            _location = location;
        }

        _storageUnits = new HashSet<StorageUnit>();
    }

    public int Id { get => _id; }
    public string Name
    {
        get => _name;

        set
        {
            if (StorageHouseDataValidator.ValidateStorageHouseName(value))
            {
                _name = value;
            }
        }
    }
    public string Location
    {
        get => _location;

        set
        {
            if (StorageHouseDataValidator.ValidateStorageHouseLocation(value))
            {
                _location = value;
            }
        }
    }

    public ISet<StorageUnit> StorageUnits { get => _storageUnits; }

    public void AddExistingStorageUnit(StorageUnit storageUnit)
    {
        if (StorageHouseDataValidator.ValidateStorageUnit(storageUnit))
        {
            storageUnit.StorageHouse = this;
        }
    }

    public void RemoveStorageUnit(StorageUnit storageUnit)
    {
        if (StorageHouseDataValidator.ValidateStorageUnit(storageUnit))
        {
            storageUnit.StorageHouse = null;
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is StorageHouse house &&
               _id == house._id &&
               _name == house._name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_id, _name);
    }
}
