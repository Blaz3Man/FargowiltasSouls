using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Buffs.Masomode
{
    public class Unstable : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Unstable");
            Description.SetDefault("You don't quite fit into reality");
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
            Main.debuff[Type] = true;
            DisplayName.AddTranslation(GameCulture.Chinese, "不稳定");
            Description.AddTranslation(GameCulture.Chinese, "现实似乎在排斥你");
			DisplayName.AddTranslation(GameCulture.Russian, "Нестабильность");
            Description.AddTranslation(GameCulture.Russian, "Вы не очень вписываетесь в реальность");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<FargoPlayer>().Unstable = true;
        }
    }
}