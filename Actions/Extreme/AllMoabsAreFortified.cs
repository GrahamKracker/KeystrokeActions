using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Extreme;

public class AllMoabsAreFortified : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        if(inGame.GetGameModel().roundSet?.rounds == null)
        {
            return;
        }

        foreach (var roundModel in inGame.GetGameModel().roundSet.rounds)
        {
            if (roundModel?.groups == null)
                continue;
            foreach (var bloonGroupModel in roundModel.groups)
            {
                if (bloonGroupModel == null)
                {
                    continue;
                }
                var bloon = inGame.GetGameModel().bloonsByName[bloonGroupModel.bloon];
                if (bloon.isMoab && bloon.FindChangedBloonId(b=>b.isFortified = true, out var fortifiedBloonId))
                {
                    bloonGroupModel.bloon = fortifiedBloonId;
                }
            }

            roundModel.emissions_ = null;
        }
    }

    /// <inheritdoc />
    protected override int Weight => 25;
}