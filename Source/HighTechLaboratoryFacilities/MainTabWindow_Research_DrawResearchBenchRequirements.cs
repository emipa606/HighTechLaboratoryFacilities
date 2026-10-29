using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace HighTechLaboratoryFacilities;

[HarmonyPatch]
public static class MainTabWindow_Research_DrawResearchBenchRequirements
{
    public static IEnumerable<MethodBase> TargetMethods()
    {
        var parentType = typeof(MainTabWindow_Research);
        var nestedTypes =
            parentType.GetNestedTypes(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

        foreach (var nested in nestedTypes)
        {
            if (!nested.Name.Contains("DisplayClass"))
            {
                continue;
            }

            var methods = nested.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var method in methods.Where(m =>
                         m.Name.Contains("DrawResearchBenchRequirements") && m.Name.Contains("b__")))
            {
                yield return method;
            }
        }
    }

    public static void Postfix(Building x, ref bool __result)
    {
        if (__result)
        {
            return;
        }

        var researchExtension = x.def.GetModExtension<DefModExt_HighTechResearchBench>();
        if (researchExtension == null)
        {
            return;
        }

        if (researchExtension.IsHighTechResearchBench)
        {
            __result = true;
        }
    }
}