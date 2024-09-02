using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Rare;

public class Skip3Rounds : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        var roundToSetTo = inGame.GetUnityToSimulation().GetCurrentRound() + 3;
        for(int i = inGame.GetUnityToSimulation().GetCurrentRound(); i < roundToSetTo; i++)
        {
            inGame.GetUnityToSimulation().SetRound(i);
        }
        inGame.GetUnityToSimulation().SetRound(roundToSetTo);
    }

    /// <inheritdoc />
    protected override int Weight => 100;
}