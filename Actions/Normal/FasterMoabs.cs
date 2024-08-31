﻿using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Normal;

public class FasterMoabs : KeystrokeAction
{
    /// <param name="inGame"></param>
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        foreach (var bloon in inGame.GetGameModel().bloons.Where(bloon => bloon.isMoab))
        {
            bloon.speed *= 1.1f;
        }
    }

    /// <inheritdoc />
    protected override float Weight => 400;
}