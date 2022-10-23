using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace MoreGeneComplexity;

[StaticConstructorOnStartup]
public class MoreGeneComplexityPatches
{
    static MoreGeneComplexityPatches()
    {
        var harmony = new Harmony("com.arquebus.rimworld.mod.moregenecomplexity");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}

public class MoreGeneComplexity : Mod
{
    readonly MoreGeneComplexitySettings settings;

    public MoreGeneComplexity(ModContentPack content) : base(content)
    {
        settings = GetSettings<MoreGeneComplexitySettings>();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        settings.DoSettingsWindowContents(inRect);
        base.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "MGC_SettingsTitle".Translate();
    }
}