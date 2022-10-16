using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace MoreGeneComplexity;

public class MoreGeneComplexity : Mod
{
    readonly MoreGeneComplexitySettings settings;
    
    public MoreGeneComplexity(ModContentPack content) : base(content)
    {
        settings = GetSettings<MoreGeneComplexitySettings>();

        var harmony = new Harmony("com.arquebus.rimworld.mod.moregenecomplexity");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
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
