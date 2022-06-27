using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SecondMiniProject.Associations.Composition;
using SecondMiniProject.Associations.Composition.Impl;
using SecondMiniProject.Tests.CompositionAssociation;
using SecondMiniProject.Interfaces;

namespace SecondMiniProject.Tests.CompositionAssociation;

public class CompositionAssociationTests
{
    private static readonly int StorageUnitId = 1;
    private static readonly double StorageUnitCapacity = 1.5;
    private static readonly string StorageUnitName = "StorageUnitName";
    private static readonly IReferenceManager<StorageUnit, StorageHouse> ReferenceManager = new StorageHouseReferenceManagerImpl();

    [Fact] 
    public void StorageUnit_CreateStorageUnit()
    {
        // Arrange
        StorageHouse storageHouse = CompositionAssociationTestModelBuilder.GetStorageHouse();

        // Act
        StorageUnit storageUnit = new StorageUnit(StorageUnitId, StorageUnitCapacity, StorageUnitName, storageHouse, ReferenceManager);

        // Assert
        Assert.NotNull(storageUnit);
        Assert.True(storageUnit.IsUsable);
        
        Assert.Equal(storageHouse, storageUnit.StorageHouse);
        Assert.Contains<StorageUnit>(storageUnit, storageHouse.StorageUnits);
    }

    [Fact]
    public void StorageUnit_TryCreatingStorageUnitAtStorageHouseAlreadyContainingEqualUnit()
    {
        // Arrange
        StorageHouse storageHouse = CompositionAssociationTestModelBuilder.GetStorageHouse();
        StorageUnit equalStorageUnit = CompositionAssociationTestModelBuilder.GetStorageUnitWithSpecificStorageHouse(storageHouse);

        // Act
        Action action = () => CompositionAssociationTestModelBuilder.GetStorageUnitWithSpecificStorageHouse(storageHouse);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(action);
        Assert.Equal(CommonMessages.CommonErrorMessages.GetInvalidStorageUnitStorageHouseHasDuplicateMessage(), exception.Message);
    }

    [Fact]
    public void StorageHouse_AddExistingStorageUnit_ReplacingReferenceToStorageHouse()
    {
        // Arrange
        StorageHouse storageHouse = CompositionAssociationTestModelBuilder.GetStorageHouse();
        StorageHouse secondStorageHouse = CompositionAssociationTestModelBuilder.GetSecondStorageHouse();
        StorageUnit storageUnit = CompositionAssociationTestModelBuilder.GetStorageUnitWithSpecificStorageHouse(storageHouse);

        // Act
        secondStorageHouse.AddExistingStorageUnit(storageUnit);

        // Assert
        Assert.True(storageUnit.IsUsable);

        Assert.NotEqual(storageHouse, storageUnit.StorageHouse);
        Assert.DoesNotContain<StorageUnit>(storageUnit, storageHouse.StorageUnits);

        Assert.Equal(secondStorageHouse, storageUnit.StorageHouse);
        Assert.Contains<StorageUnit>(storageUnit, secondStorageHouse.StorageUnits);
    }

    [Fact]
    public void StorageHouse_RemoveExistingUnit_SimpleUnitRemoval()
    {
        // Arrange
        StorageHouse storageHouse = CompositionAssociationTestModelBuilder.GetStorageHouse();
        StorageUnit storageUnit = CompositionAssociationTestModelBuilder.GetStorageUnitWithSpecificStorageHouse(storageHouse);

        // Act
        storageHouse.RemoveStorageUnit(storageUnit);

        // Assert
        Assert.False(storageUnit.IsUsable);

        Assert.NotEqual(storageHouse, storageUnit.StorageHouse);
        Assert.DoesNotContain<StorageUnit>(storageUnit, storageHouse.StorageUnits);
        Assert.Null(storageUnit.StorageHouse);
    }

    [Fact]
    public void StorageHouse_AddExistingStorageUnit_TryAddingPreviouslyRemovedUnit()
    {
        // Arrange
        StorageHouse storageHouse = CompositionAssociationTestModelBuilder.GetStorageHouse();
        StorageHouse secondStorageHouse = CompositionAssociationTestModelBuilder.GetSecondStorageHouse();

        StorageUnit storageUnit = CompositionAssociationTestModelBuilder.GetStorageUnitWithSpecificStorageHouse(storageHouse);

        // Act
        storageHouse.RemoveStorageUnit(storageUnit);
        Action action = () => secondStorageHouse.AddExistingStorageUnit(storageUnit);

        // Assert
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(action);

        Assert.Equal(CommonMessages.CommonErrorMessages.GetStorageUnitIsUnsusableMessage(), exception.Message);

        Assert.False(storageUnit.IsUsable);

        Assert.NotEqual(storageHouse, storageUnit.StorageHouse);
        Assert.DoesNotContain<StorageUnit>(storageUnit, storageHouse.StorageUnits);
        Assert.Null(storageUnit.StorageHouse);
    }
}
