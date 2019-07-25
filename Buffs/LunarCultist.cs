using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Buffs
{
    public class LunarCultist : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lunar Cultist");
            Description.SetDefault("The Lunar Cultist will protect you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
            DisplayName.AddTranslation(GameCulture.Chinese, "拜月教徒");
            Description.AddTranslation(GameCulture.Chinese, "拜月教徒将会保护你");
			DisplayName.AddTranslation(GameCulture.Russian, "Лунный Культист");
            Description.AddTranslation(GameCulture.Russian, "Лунный Культист будет защищать вас");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<FargoPlayer>().LunarCultist = true;

            if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[mod.ProjectileType("LunarCultist")] < 1)
                Projectile.NewProjectile(player.Center, Vector2.Zero, mod.ProjectileType("LunarCultist"), 0, 2f, player.whoAmI, -1f);
        }
    }
}