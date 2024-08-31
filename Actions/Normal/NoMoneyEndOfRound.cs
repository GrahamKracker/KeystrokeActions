using Il2CppAssets.Scripts.Simulation.SimulationBehaviors;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Normal;

public class NoMoneyEndOfRound : KeystrokeAction
{
    private static bool NoMoney { get; set; } = false;

    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {
        NoMoney = true;
    }

    /// <inheritdoc />
    protected override float Weight => 400;

    [HarmonyPatch(typeof(BonusCashPerRound), nameof(BonusCashPerRound.OnRoundEnd))]
    [HarmonyPrefix]
    private static bool BonusCashOnRound_OnRoundEnd()
    {
        if (NoMoney)
        {
            NoMoney = false;
            return false;
        }

        return true;
    }
}