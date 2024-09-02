using System;
using System.Collections.Generic;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Random = UnityEngine.Random;

namespace KeystrokeActions;

[HarmonyPatch]
public abstract class KeystrokeAction : NamedModContent
{
    private static int TotalWeight { get; set; }

    public static System.Random Random { get; } = new();

    private static readonly Dictionary<Tuple<int, int>, KeystrokeAction> Weights = new();

    /// <inheritdoc />
    public override void Register()
    {
        Weights.Add(new Tuple<int, int>(TotalWeight, TotalWeight + Weight), this);
        TotalWeight += Weight;
    }

    public virtual string PopupName => DisplayName;

    protected abstract void OnActivate(InGame inGame);

    protected abstract int Weight { get; }

    public static void ActivateKeystrokeAction()
    {
        var num = Random.Next(0, TotalWeight);
        KeystrokeAction action = Weights.First(x=> num > x.Key.Item1 && num < x.Key.Item2).Value;
        action.OnActivate(InGame.instance);
        MelonLogger.Msg("activating keystroke: " + action.DisplayName);
    }
}