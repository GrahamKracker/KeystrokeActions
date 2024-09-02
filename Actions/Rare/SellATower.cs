using System;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Rare;

public class SellATower : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        var allTowers = inGame.GetUnityToSimulation().GetAllTowers().ToList();
        if (allTowers.Count == 0 || allTowers.TrueForAll(tower => tower.tower.IsDestroyed))
            return;
        var randomTower = allTowers[Random.Next(0, allTowers.Count)];
        if (randomTower.tower.IsDestroyed)
            OnActivate(inGame);
        inGame.GetUnityToSimulation().SellTower(randomTower.Id);
    }

    /// <inheritdoc />
    protected override int Weight => 100;
}