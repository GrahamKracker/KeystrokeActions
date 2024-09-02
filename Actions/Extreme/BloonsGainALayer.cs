using System.Collections.Generic;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace KeystrokeActions.Actions.Extreme;

public class BloonsGainALayer : KeystrokeAction
{
    private static readonly Dictionary<string, string> BloonProgression = new()
    {
        {"Red", "Blue"},
        {"Blue", "Green"},
        {"Green", "Yellow"},
        {"Yellow", "Pink"},
        {"Pink", "Black"},
        {"Black", "Zebra"},
        {"White", "Zebra"},
        {"Zebra", "Rainbow"},
        {"Rainbow", "Ceramic"},
        {"Lead", "Ceramic"},
        {"Purple", "Ceramic"},
        {"Ceramic", "Moab"},
        {"Moab", "Bfb"},
        {"Bfb", "Zomg"},
        {"Zomg", "Bad"},
        {"Ddt", "Bad"},
        {"Bad", "Bad"}
    };
    /// <inheritdoc />
    protected override void OnActivate(InGame inGame)
    {

        foreach (var roundModel in inGame.GetGameModel().roundSet.rounds)
        {
            if (roundModel?.groups is null)
                continue;
            foreach (var bloonGroupModel in roundModel.groups)
            {
                if(string.IsNullOrEmpty(bloonGroupModel.bloon))
                    continue;

                var oldbloon = inGame.GetGameModel().bloonsByName[bloonGroupModel.bloon];

                var newbloonid = BloonProgression[oldbloon.GetBaseID()];

                var newbloonModel = inGame.GetGameModel().bloonsByName[newbloonid];

                newbloonModel.FindChangedBloonId(b =>
                {
                    b.SetCamo(oldbloon.IsCamoBloon());
                    b.isGrow = oldbloon.IsRegrowBloon();
                    b.SetFortified(oldbloon.IsFortifiedBloon());

                }, out newbloonid);

                bloonGroupModel.bloon = newbloonid;
            }

            roundModel.emissions_ = null;
        }
    }

    /// <inheritdoc />
    protected override int Weight => 25;
}