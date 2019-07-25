using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Buffs.Masomode
{
    public class Hexed : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Hexed");
            Description.SetDefault("Your attacks heal enemies");
            Main.buffNoSave[Type] = true;
            canBeCleared = true;
            Main.debuff[Type] = true;
            DisplayName.AddTranslation(GameCulture.Chinese, "着魔");
            Description.AddTranslation(GameCulture.Chinese, "你的攻击会治愈敌人");
			DisplayName.AddTranslation(GameCulture.Russian, "Заколдованный");
            Description.AddTranslation(GameCulture.Russian, "Ваши атаки лечат врагов");
		
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<FargoPlayer>().Hexed = true;
        }
    }
}