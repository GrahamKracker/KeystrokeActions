using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Normal;

public class TowerRangeDecreased : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        foreach (var towerModel in inGame.GetGameModel().towers)
        {
            towerModel.range *= .9f;
            foreach (var attackmodel in towerModel.GetBehaviors<AttackModel>())
            {
                attackmodel.range *= .9f;
            }
        }

        foreach (var tower in inGame.GetUnityToSimulation().GetAllTowers().ToList())
        {
            var towerModel = tower.tower.rootModel.Cast<TowerModel>().Duplicate();
            towerModel.range *= .9f;
            foreach (var attackmodel in towerModel.GetBehaviors<AttackModel>())
            {
                attackmodel.range *= .9f;
            }
            tower.tower.UpdateRootModel(towerModel);
        }
    }

    /// <inheritdoc />
    protected override float Weight => 400;
}