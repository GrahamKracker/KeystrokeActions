using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Rare;

public class StartNextRound : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        inGame.GetSimulation().map.spawner.StartRound();
    }

    /// <inheritdoc />
    protected override int Weight => 100;
}