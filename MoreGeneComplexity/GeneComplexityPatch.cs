using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;
using static MoreGeneComplexity.MoreGeneComplexitySettings;

namespace MoreGeneComplexity;

public class Patches
{
    [HarmonyPatch(typeof(Building_GeneAssembler))]
    [HarmonyPatch("MaxComplexity")]
    public static class GeneComplexityPatch
    {
        static void Postfix(ref int __result)
        {
            __result = __result * MaxGeneComplexityMultiplier + MaxGeneComplexityOffset;
        }
    }

    [StaticConstructorOnStartup]
    [HarmonyPatch]
    public static class GeneTuningBioStatMinPatch
    {
        static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.Constructor(typeof(GeneTuning));
        }

        static void Postfix()
        {
            AccessTools.StaticFieldRefAccess<IntRange>(typeof(GeneTuning), "BiostatRange") = new IntRange(GeneTuningMin, 5);
        }
    }
}