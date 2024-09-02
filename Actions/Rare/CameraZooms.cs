using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using KeystrokeActions;

namespace KeystrokeActions.Actions.Rare;

public class CameraZooms : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        const float zoomAmount = 1f;
        inGame.sceneCamera.orthographicSize -= zoomAmount;
        Game.instance.cameraLookup.SelectedTowerOuline.orthographicSize -= zoomAmount;
    }

    /// <inheritdoc />
    protected override int Weight => 100;
}