using HarmonyLib;
using RimWorld;
using static MoreGeneComplexity.MoreGeneComplexitySettings;

namespace MoreGeneComplexity;


[HarmonyPatch(typeof(Building_GeneAssembler))]
[HarmonyPatch("MaxComplexity")]
public static class GeneComplexityPatch
{
    static void Postfix(ref int __result)
    {
        __result = __result * MaxGeneComplexityMultiplier + MaxGeneComplexityOffset;
    }
}