using System;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Rare;

public class MoreBloonsEachRound : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        foreach (var roundModel in inGame.GetGameModel().roundSet.rounds)
        {
            foreach (var bloonGroupModel in roundModel.groups)
            {
                bloonGroupModel.count = (int) Math.Ceiling(bloonGroupModel.count * 1.1f);
            }

            roundModel.emissions_ = null;
        }
    }

    /// <inheritdoc />
    protected override int Weight => 100;
}