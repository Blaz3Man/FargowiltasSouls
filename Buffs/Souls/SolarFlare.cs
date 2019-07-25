﻿using FargowiltasSouls.NPCs;
using FargowiltasSouls.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Buffs.Souls
{
    public class SolarFlare : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Solar Flare");
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
            Main.debuff[Type] = true;
            DisplayName.AddTranslation(GameCulture.Chinese, "太阳耀斑");
			DisplayName.AddTranslation(GameCulture.Russian, "Солнечная вспышка");
        }

        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "FargowiltasSouls/Buffs/PlaceholderDebuff";
            return true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<FargoGlobalNPC>().SolarFlare = true;

            if (npc.buffTime[buffIndex] < 3)
            {
                int p = Projectile.NewProjectile(npc.Center, Vector2.Zero, mod.ProjectileType("Explosion"), 1000, 0f, Main.myPlayer);

                Main.projectile[p].GetGlobalProjectile<FargoGlobalProjectile>().CanSplit = false;
            }
        }

        public override bool ReApply(NPC npc, int time, int buffIndex)
        {
            return true;
        }
    }
}