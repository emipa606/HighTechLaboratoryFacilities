# GitHub Copilot Instructions for High Tech Laboratory Facilities (Continued) Mod

## Mod Overview and Purpose

The High Tech Laboratory Facilities (Continued) mod for RimWorld is an update to the original Pravus mod. The mod provides new and redesigned laboratory facilities with a more high-tech look. It includes custom graphics for research benches, comms consoles, and other research-related assets. The mod also adds tailor-made lab coats that slightly enhance research skills and a late-game research project that unlocks plans for an advanced powered combat exoskeleton.

## Key Features and Systems

- **Custom Graphics:** New and redesigned laboratory facilities with a high-tech appearance.
- **Lab Coats:** Tailor-made lab coats that enhance research skills.
- **Advanced Exoskeleton:** Late-game research project that unlocks plans for an advanced powered combat exoskeleton.
- **Apparel Visibility Option:** Option to hide apparel added by the mod.
- **Russian Translation:** Added translation, thanks to Dmitry6.

## Coding Patterns and Conventions

- **Mod Structure:** The mod follows a typical RimWorld mod structure with C# source files and XML definition files.
- **Harmony Patching:** Utilizes Harmony for patching existing RimWorld code.
- **Settings Management:** Manages mod settings through the settings menu and XML configuration files.
- **Localization:** Supports multiple languages, including Russian.

## XML Integration

The mod integrates with RimWorld's XML system to define new and modified assets. The XML files are located in the `Defs` directory and include definitions for:

- **ResearchProjectDefs:** Defines new research projects.
- **ThingDefs:** Defines new and modified items, including apparel and lab equipment.

## Harmony Patching

The mod uses Harmony to patch existing RimWorld code to add new functionality. Key patches include:

- **Research Bench Links:** Patches the research system to allow Hi-Tech Research Benches to link with other research items for a +10% research speed boost.
- **Apparel Visibility:** Patches the game to hide apparel added by the mod when the option is enabled.

## Suggestions for Copilot

- **XML Definitions:** Provide examples of XML definitions for new research projects and items.
- **Harmony Patches:** Provide examples of Harmony patches for modifying existing RimWorld behavior.
- **Settings Management:** Provide examples of how to manage mod settings through the settings menu and XML configuration files.
- **Localization:** Provide examples of how to add translations for multiple languages.

## Example Usage

To get started with the mod, you can use Copilot to generate XML definitions for new research projects or Harmony patches for modifying existing RimWorld behavior. For example, to create a new research project, you can use Copilot to generate an example XML definition for a research project.

xml
<ResearchProjectDef>
    <defName>AdvancedExoskeleton</defName>
    <label>Advanced Powered Combat Exoskeleton</label>
    <description>Unlock plans for an advanced powered combat exoskeleton.</description>
    <prerequisites>
        <li>HiTechResearchBench</li>
    </prerequisites>
    <root>true</root>
    <techLevel>TechLevel.Industrial</techLevel>
</ResearchProjectDef>


To create a Harmony patch for modifying existing RimWorld behavior, you can use Copilot to generate an example patch.

csharp
using HarmonyLib;
using RimWorld;

public class ExoskeletonPatch
{
    [HarmonyPatch(typeof(ResearchProjectDef), "GetPrerequisites")]
    public static class GetPrerequisites_Patch
    {
        public static void Postfix(ref List<ResearchProjectDef> __result)
        {
            if (__result.Contains(ResearchProjectDefOf.HiTechResearchBench))
            {
                __result.Add(ResearchProjectDefOf.AdvancedExoskeleton);
            }
        }
    }
}


By following these coding patterns and conventions, you can effectively use Copilot to generate code for your RimWorld mod.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

