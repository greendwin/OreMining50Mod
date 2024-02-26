using System;
using Assets.Scripts.Objects.Items;
using HarmonyLib;
using StationeersMods.Interface;


namespace OreMining50Mod
{
    [HarmonyPatch(typeof(Tool), nameof(Tool.OnMinedOre))]
    class ToolOnMinedOrePatch
    {
        public static void Prefix(Ore oreMined)
        {
            if (oreMined.Quantity < 50)
            {
                oreMined.Quantity = 50;
            }
        }
    }

    class OreMining50Mod : ModBehaviour
    {
        public override void OnLoaded(ContentHandler contentHandler)
        {
            Harmony harmony = new Harmony("OreMining50Mod");
            harmony.PatchAll();

            Console.WriteLine("[OreMining50Mod] Loaded!");
        }
    }
}