using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Extreme;

public class TowersDealLessDamage : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        foreach (var towerModel in inGame.GetGameModel().towers)
        {
            foreach (var damageModel in towerModel.GetDescendants<DamageModel>().ToList())
            {
                damageModel.damage *= .9f;
            }
        }

        foreach (var tower in inGame.GetUnityToSimulation().GetAllTowers().ToList())
        {
            var towerModel = tower.tower.rootModel.Cast<TowerModel>().Duplicate();
            foreach (var damageModel in towerModel.GetDescendants<DamageModel>().ToList())
            {
                damageModel.damage *= .9f;
            }

            tower.tower.UpdateRootModel(towerModel);
        }
    }

    /// <inheritdoc />
    protected override int Weight => 25;
}