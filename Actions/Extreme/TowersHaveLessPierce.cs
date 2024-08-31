using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Extreme;

public class TowersHaveLessPierce : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        foreach (var towerModel in inGame.GetGameModel().towers)
        {
            foreach (var projectileModel in towerModel.GetDescendants<ProjectileModel>().ToList())
            {
                projectileModel.pierce *= .9f;
            }
        }

        foreach (var tower in inGame.GetUnityToSimulation().GetAllTowers().ToList())
        {
            var towerModel = tower.tower.rootModel.Cast<TowerModel>().Duplicate();
            foreach (var projectileModel in towerModel.GetDescendants<ProjectileModel>().ToList())
            {
                projectileModel.pierce *= .9f;
            }

            tower.tower.UpdateRootModel(towerModel);
        }
    }

    /// <inheritdoc />
    protected override float Weight => 25;
}