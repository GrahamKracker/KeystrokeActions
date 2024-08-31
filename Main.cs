using System.Collections.Generic;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using KeystrokeActions;
using KeystrokeActions.Actions.Normal;
using UnityEngine;

[assembly: MelonInfo(typeof(KeystrokeActions.Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace KeystrokeActions;

[HarmonyPatch]
public class Main : BloonsTD6Mod
{
    internal static MelonLogger.Instance Logger;

    public override void OnInitialize()
    {
        Logger = LoggerInstance;
    }

    /// <inheritdoc />
    public override void OnMainMenu()
    {
        MonkeysGrow.TowerScale = 1f;
    }

    [HarmonyPatch(typeof(InputManager), nameof(InputManager.CreateTowerGraphicsAsync))]
    [HarmonyPostfix]
    public static void CreateTowerGraphicsAsyncPostfix(Il2CppSystem.Collections.Generic.List<UnityDisplayNode> placementGraphics)
    {
        foreach (var graphic in placementGraphics)
        {
            if (graphic.gameObject.GetComponent<TowerScaler>() == null)
                graphic.gameObject.AddComponent<TowerScaler>();
        }
    }

    /// <inheritdoc />
    public override void OnTowerModelChanged(Tower tower, Model newModel)
    {
        TaskScheduler.ScheduleTask(() =>
        {
            if (tower.display.node.graphic.gameObject.GetComponent<TowerScaler>() == null)
                tower.display.node.graphic.gameObject.AddComponent<TowerScaler>();
        }, () => tower.display.node != null && tower.display.node.graphic != null) ;
    }

    /// <inheritdoc />
    public override void OnUpdate()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && InGame.instance != null && InGame.instance.IsInGame())
        {
            KeystrokeAction.ActivateKeystrokeAction();
        }
    }
}