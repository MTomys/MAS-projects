using SecondMiniProject.Interfaces;
using SecondMiniProject.DataValidators;
using SecondMiniProject.CommonMessages;

namespace SecondMiniProject.Associations.Composition;

public class StorageUnit
{
    private readonly int _id;
    private readonly double _capacity;
    private string _name;

    // Upon reaching the state _isUsable=false, the object cannot be used anymore (It once lost the association and is now "Gone")
    private bool _isUsable = true;

    private StorageHouse _storageHouse;
    private readonly IReferenceManager<StorageUnit, StorageHouse> _referenceManager;

    public StorageUnit(int id, double capacity, string name, StorageHouse storageHouse, IReferenceManager<StorageUnit, StorageHouse> referenceManager)
    {
        _id = id;

        if (StorageUnitDataValidator.ValidateStorageUnitName(name))
        {
            _name = name;
        }

        if (StorageUnitDataValidator.ValidateStorageUnitCapacity(capacity))
        {
            _capacity = capacity;
        }

        if (StorageUnitDataValidator.ValidateStorageUnitStorageHouse(storageHouse) &&
            StorageUnitDataValidator.CheckIfStorageHouseDoesNotContainDuplicate(this, storageHouse))
        {
            _storageHouse = storageHouse;
        }

        _referenceManager = referenceManager;

        referenceManager.AddNewReference(this, storageHouse);
    }

    public int Id { get => _id; }
    public double Capacity { get => _capacity; }
    public string Name
    {
        get => _name;

        set
        {
            if (StorageUnitDataValidator.ValidateStorageUnitName(value))
            {
                _name = value;
            }
        }
    }
    public bool IsUsable { get => _isUsable; }
    public StorageHouse StorageHouse
    {
        get => _storageHouse;

        set
        {
            if (_isUsable == false)
            {
                throw new InvalidOperationException(CommonErrorMessages.GetStorageUnitIsUnsusableMessage());
            }

            if (_storageHouse == value)
            {
                return;
            }

            if (value is null)
            {
                if (_storageHouse is not null)
                {
                    _referenceManager.DeleteCurrentReference(this);
                    _storageHouse = null;
                    _isUsable = false;
                }
            }
            else if (value is not null)
            {
                if (_storageHouse is not null)
                {
                    _referenceManager.ReplaceCurrentReference(this, value);
                    _storageHouse = value;
                }
            }
        }
    }
    public override bool Equals(object? obj)
    {
        return obj is StorageUnit unit &&
               _id == unit._id &&
               _name == unit._name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_id, _name);
    }
}
