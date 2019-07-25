using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Buffs.Masomode
{
    public class Antisocial : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Antisocial");
            Description.SetDefault("You have no friends");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            canBeCleared = true;
            DisplayName.AddTranslation(GameCulture.Chinese, "反社交");
            Description.AddTranslation(GameCulture.Chinese, "你没有朋友");
			DisplayName.AddTranslation(GameCulture.Russian, "Асоциальный");
            Description.AddTranslation(GameCulture.Russian, "У тебя нет друзей (лох)");

        }

        public override void Update(Player player, ref int buffIndex)
        {
            //disables minions, disables pets, -50% minion dmg
            player.GetModPlayer<FargoPlayer>(mod).Asocial = true;
        }
    }
}