using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using KeystrokeActions;

namespace KeystrokeActions.Actions.Rare;

public class CameraZooms : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        inGame.sceneCamera.orthographicSize -= 0.1f;
    }

    /// <inheritdoc />
    protected override float Weight => 100;
}