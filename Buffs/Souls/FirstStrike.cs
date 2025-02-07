﻿using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Buffs.Souls
{
    public class FirstStrike : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("First Strike");
            Description.SetDefault("Your next attack will be enhanced");
            Main.buffNoSave[Type] = true;
            DisplayName.AddTranslation(GameCulture.Chinese, "先发制人");
            Description.AddTranslation(GameCulture.Chinese, "你的下一次攻击将会得到增强");
			DisplayName.AddTranslation(GameCulture.Russian, "Первый удар");
            Description.AddTranslation(GameCulture.Russian, "Ваша следующая атака будет усилена");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex]++;
            player.GetModPlayer<FargoPlayer>(mod).FirstStrike = true;
        }
    }
}