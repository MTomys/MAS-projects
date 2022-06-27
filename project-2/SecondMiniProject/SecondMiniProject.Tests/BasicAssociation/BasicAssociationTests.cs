using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SecondMiniProject.Tests.BasicAssociation;
using SecondMiniProject.Associations.BasicAssociation;

namespace SecondMiniProject.Tests.BasicAssociation;

public class BasicAssociationTests
{
    [Fact]
    public void SoccerPlayer_JoinTeam_SimpleFreshJoinTeam()
    {
        // Arrange
        SoccerPlayer soccerPlayer = BasicAssociationTestModelBuilder.CreateSoccerPlayer();
        SoccerTeam soccerTeam = BasicAssociationTestModelBuilder.CreateSoccerTeam();

        // Act 
        soccerPlayer.JoinTeam(soccerTeam);

        // Assert
        Assert.Equal(soccerPlayer.SoccerTeam, soccerTeam);
        Assert.Contains<SoccerPlayer>(soccerPlayer, soccerTeam.SoccerPlayers);
    }

    [Fact]
    public void SoccerPlayer_JoinTeam_TryJoiningEqualTeamMultipleTimes()
    {
        // Arrange
        SoccerPlayer soccerPlayer = BasicAssociationTestModelBuilder.CreateSoccerPlayer();
        SoccerTeam soccerTeam = BasicAssociationTestModelBuilder.CreateSoccerTeam();

        // Act 
        soccerPlayer.JoinTeam(soccerTeam);
        soccerPlayer.JoinTeam(soccerTeam);

        // Assert
        Assert.Equal(soccerPlayer.SoccerTeam, soccerTeam);
        Assert.Contains<SoccerPlayer>(soccerPlayer, soccerTeam.SoccerPlayers);

        Assert.Equal(1, soccerTeam.SoccerPlayers.Count);
    }

    [Fact]
    public void SoccerPlayer_JoinTeam_TryJoiningMultipleTeams()
    {
        // Arrange
        SoccerPlayer soccerPlayer = BasicAssociationTestModelBuilder.CreateSoccerPlayer();
        SoccerTeam soccerTeam = BasicAssociationTestModelBuilder.CreateSoccerTeam();
        SoccerTeam secondSoccerTeam = BasicAssociationTestModelBuilder.CreateSecondSoccerTeam();

        // Act
        soccerPlayer.JoinTeam(soccerTeam);
        soccerPlayer.JoinTeam(secondSoccerTeam);

        // Assert
        Assert.NotEqual(soccerTeam, soccerPlayer.SoccerTeam);
        Assert.DoesNotContain<SoccerPlayer>(soccerPlayer, soccerTeam.SoccerPlayers);

        Assert.Equal(secondSoccerTeam, soccerPlayer.SoccerTeam);
        Assert.Contains<SoccerPlayer>(soccerPlayer, secondSoccerTeam.SoccerPlayers);

        Assert.Equal(0, soccerTeam.SoccerPlayers.Count);
        Assert.Equal(1, secondSoccerTeam.SoccerPlayers.Count);
    }

    [Fact]
    public void SoccerPlayer_JoinTeam_ReplaceCurrentTeam()
    {
        // Arrange
        SoccerPlayer soccerPlayer = BasicAssociationTestModelBuilder.CreateSoccerPlayer();
        SoccerTeam soccerTeam = BasicAssociationTestModelBuilder.CreateSoccerTeam();
        SoccerTeam secondSoccerTeam = BasicAssociationTestModelBuilder.CreateSecondSoccerTeam();

        // Act 
        soccerPlayer.JoinTeam(soccerTeam);
        soccerPlayer.JoinTeam(secondSoccerTeam);

        // Assert
        Assert.NotEqual(soccerPlayer.SoccerTeam, soccerTeam);
        Assert.DoesNotContain<SoccerPlayer>(soccerPlayer, soccerTeam.SoccerPlayers);

        Assert.Equal(soccerPlayer.SoccerTeam, secondSoccerTeam);
        Assert.Contains<SoccerPlayer>(soccerPlayer, secondSoccerTeam.SoccerPlayers);
    }

    [Fact]
    public void SoccerPlayer_DisbandTeam_SimpleDisband()
    {
        // Arrange
        SoccerPlayer soccerPlayer = BasicAssociationTestModelBuilder.CreateSoccerPlayer();
        SoccerTeam soccerTeam = BasicAssociationTestModelBuilder.CreateSoccerTeam();

        // Act 
        soccerPlayer.JoinTeam(soccerTeam);
        soccerPlayer.DisbandTeam();

        // Assert
        Assert.NotEqual(soccerPlayer.SoccerTeam, soccerTeam);
        Assert.DoesNotContain<SoccerPlayer>(soccerPlayer, soccerTeam.SoccerPlayers);
    }

    [Fact]
    public void SoccerTeam_AddPlayer_SimpleAddPlayer()
    {
        // Arrange
        SoccerPlayer soccerPlayer = BasicAssociationTestModelBuilder.CreateSoccerPlayer();
        SoccerTeam soccerTeam = BasicAssociationTestModelBuilder.CreateSoccerTeam();

        // Act 
        soccerTeam.AddPlayer(soccerPlayer);

        // Assert
        Assert.Equal(soccerPlayer.SoccerTeam, soccerTeam);
        Assert.Contains<SoccerPlayer>(soccerPlayer, soccerTeam.SoccerPlayers);
    }

    [Fact]
    public void SoccerTeam_AddPlayer_TryAddingMultipleEqualPlayers()
    {

        // Arrange
        SoccerPlayer soccerPlayer = BasicAssociationTestModelBuilder.CreateSoccerPlayer();
        SoccerTeam soccerTeam = BasicAssociationTestModelBuilder.CreateSoccerTeam();

        // Act 
        soccerTeam.AddPlayer(soccerPlayer);
        soccerTeam.AddPlayer(soccerPlayer);

        // Assert
        Assert.Equal(soccerPlayer.SoccerTeam, soccerTeam);
        Assert.Contains<SoccerPlayer>(soccerPlayer, soccerTeam.SoccerPlayers);

        Assert.Equal(1, soccerTeam.SoccerPlayers.Count);

    }
    
    [Fact]
    public void SoccerTeam_AddPlayer_AddTwoPlayers()
    {
        // Arrange
        SoccerPlayer soccerPlayer = BasicAssociationTestModelBuilder.CreateSoccerPlayer();
        SoccerPlayer secondSoccerPlayer = BasicAssociationTestModelBuilder.CreateSecondSoccerPlayer();
        SoccerTeam soccerTeam = BasicAssociationTestModelBuilder.CreateSoccerTeam();

        // Act 
        soccerTeam.AddPlayer(soccerPlayer);
        soccerTeam.AddPlayer(secondSoccerPlayer);

        // Assert
        Assert.Equal(soccerPlayer.SoccerTeam, soccerTeam);
        Assert.Contains<SoccerPlayer>(soccerPlayer, soccerTeam.SoccerPlayers);

        Assert.Equal(secondSoccerPlayer.SoccerTeam, soccerTeam);
        Assert.Contains<SoccerPlayer>(secondSoccerPlayer, soccerTeam.SoccerPlayers);
    }

    [Fact]
    public void SoccerTeam_RemovePlayer_RemoveOnePlayer()
    {
        // Arrange
        SoccerPlayer soccerPlayer = BasicAssociationTestModelBuilder.CreateSoccerPlayer();
        SoccerTeam soccerTeam = BasicAssociationTestModelBuilder.CreateSoccerTeam();

        // Act 
        soccerTeam.AddPlayer(soccerPlayer);
        soccerTeam.RemovePlayer(soccerPlayer);

        // Assert
        Assert.NotEqual(soccerPlayer.SoccerTeam, soccerTeam);
        Assert.DoesNotContain<SoccerPlayer>(soccerPlayer, soccerTeam.SoccerPlayers);
    }

    [Fact]
    public void SoccerTeam_RemovePlayer_RemoveBothPlayers()
    {
        // Arrange
        SoccerPlayer soccerPlayer = BasicAssociationTestModelBuilder.CreateSoccerPlayer();
        SoccerPlayer secondSoccerPlayer = BasicAssociationTestModelBuilder.CreateSecondSoccerPlayer();
        SoccerTeam soccerTeam = BasicAssociationTestModelBuilder.CreateSoccerTeam();

        // Act 
        soccerTeam.AddPlayer(soccerPlayer);
        soccerTeam.AddPlayer(secondSoccerPlayer);
        soccerTeam.RemovePlayer(soccerPlayer);
        soccerTeam.RemovePlayer(secondSoccerPlayer);

        // Assert
        Assert.NotEqual(soccerPlayer.SoccerTeam, soccerTeam);
        Assert.DoesNotContain<SoccerPlayer>(soccerPlayer, soccerTeam.SoccerPlayers);

        Assert.NotEqual(secondSoccerPlayer.SoccerTeam, soccerTeam);
        Assert.DoesNotContain<SoccerPlayer>(secondSoccerPlayer, soccerTeam.SoccerPlayers);
    }
}
