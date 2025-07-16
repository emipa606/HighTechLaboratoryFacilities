# GitHub Copilot Instructions for RimWorld Modding Project

## Mod Overview and Purpose

**HighTechLaboratoryFacilities** is a RimWorld mod that aims to enhance the research capabilities and facilities within the game. The mod introduces new high-tech research benches and laboratory facilities that players can build to significantly boost their research efficiency and expand their options within the research tree. The mod enhances gameplay by adding depth and variety to the tech progression, making research more engaging and strategically rewarding.

## Key Features and Systems

1. **High-Tech Research Benches**: Adds advanced research benches that provide greater research speed and unique bonuses compared to the vanilla game benches.
   
2. **Laboratory Facilities**: Introduces new building facilities that, when placed near research benches, improve research capabilities or provide unique bonuses.

3. **Advanced Mod Settings**: The mod includes customizable settings allowing players to tweak research speeds and bonus effects according to their gameplay preferences.

4. **Research Compatibility**: Ensures that all research projects can be conducted using the new facilities, integrating seamlessly with existing and modded research projects.

## Coding Patterns and Conventions

- **Class and Method Organization**: The project is organized with classes segregated by their functionality. Mod extension classes are named with the `DefModExt` prefix to indicate their role in extending definitions, while core mod functionality is housed in classes with a `Mod` suffix.

- **Internal Access Modifiers**: Classes and methods that are not exposed outside the assembly are marked `internal`, following the principle of encapsulation and minimizing the public API surface.

- **Static Utility Classes**: Utility functions, particularly those that interact with game mechanics (such as research checking), are placed in static classes and methods, ensuring ease of access without needing instantiation.

## XML Integration

XML files define the high-tech benches and facilities, specifying their resource costs, research speed modifiers, and special attributes. XML integration includes:
- **Defining New Buildings**: New building definitions to ensure they appear correctly within the game, with proper attributes like research speed multipliers.
- **Research Integration**: XML tags in `ResearchProjectDefs` to check if projects are compatible with high-tech facilities.
- **Localization Support**: XML files for translations and mod settings descriptions to ensure accessibility to a broader audience.

## Harmony Patching

- **Purpose**: Harmony is used to patch into RimWorld's core methods to modify or enhance functionality without altering the original game code directly.
  
- **Patching Strategy**: 
  - Patching is primarily used to adjust how research functionality interacts with the new facilities. 
  - Harmony patches might be added to methods related to research speed calculation or facility interaction checks.

- **Implementation**: Utilize `[HarmonyPatch]` annotations to specify targets and pre/postfix methods for augmenting existing game functions.

## Suggestions for Copilot

1. **Suggesting New Features**: Copilot can be prompted to suggest new features or improvements, such as unique research projects only available through high-tech benches or thematic enhancements like facility-specific events.

2. **Code Refactoring**: Use Copilot to suggest optimizations or refactoring opportunities by analyzing repetitive code patterns or enhancing code efficiency.

3. **Harmony Patch Assistance**: When implementing patches, Copilot can offer syntax suggestions and help identify suitable methods to patch, ensuring minimal conflict with other mods.

4. **XML File Editing**: Copilot can assist in generating or updating XML data by predicting tags and structure necessary for integrating new content seamlessly.

5. **Debugging and Error Checking**: Leverage Copilot's syntax checking to quickly identify potential code issues or XML misconfigurations, aiding in rapid debugging and iteration.

By following these instructions and utilizing GitHub Copilot effectively, mod developers can enhance their productivity and improve the quality of their modding projects for RimWorld.
