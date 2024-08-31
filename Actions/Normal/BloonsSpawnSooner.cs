using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Normal;

public class BloonsSpawnSooner : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        foreach (var roundModel in inGame.GetGameModel().roundSet.rounds)
        {
            foreach (var bloonGroupModel in roundModel.groups)
            {
                bloonGroupModel.start *= .9f;
            }
            roundModel.emissions_ = null;
        }

    }

    /// <inheritdoc />
    protected override float Weight => 400;

    
}