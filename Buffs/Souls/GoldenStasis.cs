﻿using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Buffs.Souls
{
    public class GoldenStasis : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Golden Stasis");
            Description.SetDefault("You are immune to all damage, but cannot move");
            Main.buffNoSave[Type] = true;
            canBeCleared = true;
            DisplayName.AddTranslation(GameCulture.Chinese, "不动金身");
            Description.AddTranslation(GameCulture.Chinese, "免疫所有伤害,但无法移动");
			DisplayName.AddTranslation(GameCulture.Russian, "Золотой стазис");
            Description.AddTranslation(GameCulture.Russian, "Вы невосприимчивы к любому урону, но не можете двигаться");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<FargoPlayer>(mod).GoldShell = true;
        }
    }
}