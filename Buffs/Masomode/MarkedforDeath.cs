using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace FargowiltasSouls.Buffs.Masomode
{
	public class MarkedforDeath : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Marked for Death");
			Description.SetDefault("Just don't get hit");
			Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            canBeCleared = true;
            DisplayName.AddTranslation(GameCulture.Chinese, "死亡标记");
            Description.AddTranslation(GameCulture.Chinese, "别被打到");
			DisplayName.AddTranslation(GameCulture.Russian, "Метка смерти");
            Description.AddTranslation(GameCulture.Russian, "Просто не получайте урон");
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<FargoPlayer>().DeathMarked = true;
        }
    }
}
