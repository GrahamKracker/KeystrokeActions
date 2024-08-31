using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Extreme;

public class LessMoneyForever : KeystrokeAction
{
    private static float MoneyMult = 1f;
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        MoneyMult *= .9f;
    }

    /// <inheritdoc />
    protected override float Weight => 25;

    [HarmonyPatch(typeof(Simulation), nameof(Simulation.AddCash))]
    [HarmonyPrefix]
    private static void Simulation_AddCash(ref double c)
    {
        c *= MoneyMult;
    }
}