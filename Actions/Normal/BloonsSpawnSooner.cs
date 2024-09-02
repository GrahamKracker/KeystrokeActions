using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Normal;

public class BloonsSpawnSooner : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        if(inGame.GetGameModel().roundSet?.rounds == null)
            return;
        foreach (var roundModel in inGame.GetGameModel().roundSet.rounds)
        {
            if (roundModel?.groups == null)
                continue;
            foreach (var bloonGroupModel in roundModel.groups)
            {
                if (bloonGroupModel == null)
                    continue;
                bloonGroupModel.start *= .9f;
            }
            roundModel.emissions_ = null;
        }

    }

    /// <inheritdoc />
    protected override int Weight => 400;

    
}