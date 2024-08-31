using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Normal;

public class MonkeysGrow : KeystrokeAction
{
    public static float TowerScale = 1f;
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        const float scale = 1.025f;
        foreach (var towerModel in inGame.GetGameModel().towers)
        {
            towerModel.radius *= scale;
        }

        foreach (var tower in inGame.GetUnityToSimulation().GetAllTowers().ToList())
        {
            var towerModel = tower.tower.rootModel.Cast<TowerModel>().Duplicate();
            towerModel.radius *= scale;

            tower.tower.UpdateRootModel(towerModel);
        }

        TowerScale *= scale;
    }



    /// <inheritdoc />
    protected override float Weight => 400;
}