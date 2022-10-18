using Mlie;
using UnityEngine;
using Verse;

namespace HighTechLaboratoryFacilities;

[StaticConstructorOnStartup]
internal class HighTechLaboratoryFacilitiesMod : Mod
{
    public static HighTechLaboratoryFacilitiesMod instance;
    private static string currentVersion;

    private HighTechLaboratoryFacilitiesModSettings settings;

    public HighTechLaboratoryFacilitiesMod(ModContentPack content) : base(content)
    {
        instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(
                ModLister.GetActiveModWithIdentifier("Mlie.HighTechLaboratoryFacilities"));
    }

    internal HighTechLaboratoryFacilitiesModSettings Settings
    {
        get
        {
            if (settings == null)
            {
                settings = GetSettings<HighTechLaboratoryFacilitiesModSettings>();
            }

            return settings;
        }
        set => settings = value;
    }

    public override string SettingsCategory()
    {
        return "High Tech Laboratory Facilities";
    }

    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.CheckboxLabeled("HTLF.HideApparel".Translate(), ref Settings.HideApparel,
            "HTLF.HideSpecial".Translate());
        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("HTLF.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }

    public override void WriteSettings()
    {
        base.WriteSettings();
        HighTechLaboratoryFacilities.SetApparelVisibility();
    }
}