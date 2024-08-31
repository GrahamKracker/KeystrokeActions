using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Normal;

public class DoNothing : KeystrokeAction
{
    /// <param name="inGame"></param>
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
    }

    /// <inheritdoc />
    protected override float Weight => 400;
}