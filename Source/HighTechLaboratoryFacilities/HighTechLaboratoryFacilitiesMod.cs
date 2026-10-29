using Mlie;
using UnityEngine;
using Verse;

namespace HighTechLaboratoryFacilities;

[StaticConstructorOnStartup]
internal class HighTechLaboratoryFacilitiesMod : Mod
{
    public static HighTechLaboratoryFacilitiesMod Instance;
    private static string currentVersion;

    public HighTechLaboratoryFacilitiesMod(ModContentPack content) : base(content)
    {
        Instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    internal HighTechLaboratoryFacilitiesModSettings Settings
    {
        get
        {
            field ??= GetSettings<HighTechLaboratoryFacilitiesModSettings>();

            return field;
        }
        set;
    }

    public override string SettingsCategory()
    {
        return "High Tech Laboratory Facilities";
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        listingStandard.CheckboxLabeled("HTLF.HideApparel".Translate(), ref Settings.HideApparel,
            "HTLF.HideSpecial".Translate());
        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("HTLF.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        HighTechLaboratoryFacilities.SetApparelVisibility();
    }
}