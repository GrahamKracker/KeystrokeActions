using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Normal;

public class PlaneAndHeliMoveSlower : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        foreach (var airUnitModel in inGame.GetGameModel().GetDescendants<PathMovementModel>().ToList())
        {
            airUnitModel.speed *= .9f;
        }

        foreach (var airUnitModel in inGame.GetGameModel().GetDescendants<HeliMovementModel>().ToList())
        {
            airUnitModel.maxSpeed *= .9f;
        }

        foreach (var tower in inGame.GetUnityToSimulation().GetAllTowers().ToList())
        {
            var towerModel = tower.tower.rootModel.Cast<TowerModel>().Duplicate();
            foreach (var airUnitModel in towerModel.GetDescendants<PathMovementModel>().ToList())
            {
                airUnitModel.speed *= .9f;
            }

            foreach (var airUnitModel in towerModel.GetDescendants<HeliMovementModel>().ToList())
            {
                airUnitModel.maxSpeed *= .9f;
            }

            tower.tower.UpdateRootModel(towerModel);
        }
    }

    /// <inheritdoc />
    protected override float Weight => 400;
}