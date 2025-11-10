using HarmonyLib;
using Room_Food;
using UnityEngine;
using Verse;

namespace RoomFoodDistancePatch;

[StaticConstructorOnStartup]
[HarmonyPatch(typeof(Settings), nameof(Settings.DoWindowContents))]
internal static class Patch
{
    private const string ID = "junip0r.roomfooddistancepatch";

    static Patch()
    {
        new Harmony(ID).PatchAll();
    }

    private static bool Prefix(Settings __instance, Rect wrect)
    {
		var listing_Standard = new Listing_Standard();
		listing_Standard.Begin(wrect);
		__instance.maxDistanceToTable = (int)listing_Standard.SliderLabeled($"Distance to look for a table: {__instance.maxDistanceToTable}", __instance.maxDistanceToTable, 1f, 500f);
		listing_Standard.Gap();
		listing_Standard.End();
        return false;
    }
}