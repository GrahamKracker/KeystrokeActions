using System;
using System.Collections.Generic;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Random = UnityEngine.Random;

namespace KeystrokeActions;

[HarmonyPatch]
public abstract class KeystrokeAction : NamedModContent
{
    private static float TotalWeight { get; set; }

    private static readonly Dictionary<Tuple<float, float>, KeystrokeAction> Weights = new();

    /// <inheritdoc />
    public override void Register()
    {
        Weights.Add(new Tuple<float, float>(TotalWeight, TotalWeight + Weight), this);
        TotalWeight += Weight;
    }

    public virtual string PopupName => DisplayName;

    protected abstract void OnActivate(InGame inGame);

    protected abstract float Weight { get; }

    public static void ActivateKeystrokeAction()
    {

        var num = Random.RandomRange(0, TotalWeight);
        KeystrokeAction action = Weights.First(x=> num > x.Key.Item1 && num < x.Key.Item2).Value;
        action.OnActivate(InGame.instance);
        MelonLogger.Msg("activating keystroke: " + action.DisplayName);
        //show text effect TODO
    }
}