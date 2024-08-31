using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Extreme;

public class AllMoabsAreFortified : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        foreach (var roundModel in inGame.GetGameModel().roundSet.rounds)
        {
            foreach (var bloonGroupModel in roundModel.groups)
            {
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
    protected override float Weight => 25;
}