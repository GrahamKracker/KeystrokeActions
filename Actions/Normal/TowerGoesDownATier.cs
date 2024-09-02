using System;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace KeystrokeActions.Actions.Normal;

public class TowerGoesDownATier : KeystrokeAction
{
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        var allTowers = inGame.GetUnityToSimulation().GetAllTowers().ToList();
        if (allTowers.Count == 0)
            return;
        var randomTower = allTowers[Random.Next(0, allTowers.Count)];
        if(randomTower is { tower.IsDestroyed: true, destroyed:true })
            OnActivate(inGame);

        var randomTowerModel = randomTower.tower.towerModel.Duplicate();

        var tiers = randomTowerModel.tiers;
        if (tiers.Any(tier => tier > 0))
        {
            var randomPath = Random.Next(0, tiers.Length);
            if (tiers[randomPath] == 0)
                OnActivate(inGame);
            tiers[randomPath]--;

            bool AreTiersEqual(Il2CppStructArray<int> a, Il2CppStructArray<int> b)
            {
                if (a.Length != b.Length)
                {
                    return false;
                }

                for (var i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            var newModel = inGame.GetGameModel().towers.FirstOrDefault(towerModel =>
                towerModel.baseId == randomTowerModel.baseId &&
                AreTiersEqual(towerModel.tiers, tiers));

            if (newModel == null)
            {
                return;
            }

            var newtower = inGame.GetTowerManager().CreateTower(newModel, randomTower.tower.Position,
                inGame.GetUnityToSimulation().MyPlayerNumber,
                randomTower.tower.AreaPlacedOn, randomTower.tower.parentTowerId, null, false, false,
                randomTower.tower.Rotation, false);
            newtower.AddPoppedCash(randomTower.tower.cashEarned);
            newtower.appliedCash = randomTower.tower.GetAppliedCash();
            newtower.damageDealt = randomTower.tower.damageDealt;
            newtower.worth = randomTower.tower.worth;
            newtower.shouldShowCashIconInstead = randomTower.tower.shouldShowCashIconInstead;
            newtower.owner = randomTower.tower.owner;
            newtower.cashEarned = randomTower.tower.cashEarned;

            inGame.GetTowerManager().DestroyTower(randomTower.tower, inGame.GetUnityToSimulation().MyPlayerNumber);

            newtower.UpdateThrowCache();
            newtower.UpdateBuffs();
            newtower.UpdateThrowLocation();
            newtower.UpdateTargetType();
            newtower.UpdateRoundMutators();
        }
        else
        {
            if(!allTowers.Exists(tower => tower.tower.towerModel.tiers.Any(tier => tier > 0)))
                return;
            OnActivate(inGame);
        }
    }

    /// <inheritdoc />
    protected override int Weight => 400;

    
}