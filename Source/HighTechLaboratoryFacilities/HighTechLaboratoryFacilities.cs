using System.Linq;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace HighTechLaboratoryFacilities;

[StaticConstructorOnStartup]
internal static class HighTechLaboratoryFacilities
{
    static HighTechLaboratoryFacilities()
    {
        new Harmony("Mlie.HighTechLaboratoryFacilities").PatchAll(Assembly.GetExecutingAssembly());
        SetApparelVisibility();
    }

    internal static void SetApparelVisibility()
    {
        HighTechLaboratoryFacilitiesMod.Instance.Settings ??= new HighTechLaboratoryFacilitiesModSettings
        {
            HideApparel = false
        };

        var hidden = HighTechLaboratoryFacilitiesMod.Instance.Settings.HideApparel;

        var recipeList = DefDatabase<RecipeDef>.AllDefs.ToList();
        foreach (var recipe in recipeList)
        {
            if (recipe.defName != "Make_LabCoat" && recipe.defName != "Make_Apparel_CyberSuit" &&
                recipe.defName != "Make_Apparel_Leviathan" && recipe.defName != "Make_Apparel_LeviathanH")
            {
                continue;
            }

            if (hidden)
            {
                recipe.factionPrerequisiteTags = ["Not_available_for_you"];
            }
            else
            {
                recipe.factionPrerequisiteTags?.Clear();
            }
        }

        var researchList = DefDatabase<ResearchProjectDef>.AllDefs.ToList();
        foreach (var research in researchList)
        {
            if (research.defName != "TranscendentTech")
            {
                continue;
            }

            research.requiredResearchBuilding =
                hidden ? DefDatabase<ThingDef>.GetNamedSilentFail("UnobtainableResearchBench") : null;
        }

        var list = DefDatabase<ThingDef>.AllDefs.ToList();
        foreach (var thing in list)
        {
            if (thing.defName != "LabCoat")
            {
                continue;
            }

            if (hidden)
            {
                thing.generateCommonality = 0;
            }
            else
            {
                thing.generateCommonality = 0.01f;
            }
        }
    }
}