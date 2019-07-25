using FargowiltasSouls.Projectiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Items.Weapons
{
    public class TophatSquirrel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Top Hat Squirrel");
            Tooltip.SetDefault("'Who knew this squirrel had phenomenal cosmic power?'");
            DisplayName.AddTranslation(GameCulture.Chinese, "高顶礼帽松鼠");
            Tooltip.AddTranslation(GameCulture.Chinese, "'谁能知道,这只松鼠竟然有着非凡的宇宙力量呢?'");
			DisplayName.AddTranslation(GameCulture.Russian, "Белка в шляпе");
            Tooltip.AddTranslation(GameCulture.Russian, "'Но кто знал, что эта белка содержит в себе феноменальную космическую мощь?");
        }

        public override void SetDefaults()
        {
            item.damage = 50;

            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.rare = 1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.consumable = true;

            item.thrown = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 3f; //Ranges from 1 to 9.

            item.autoReuse = true;

            item.shoot = mod.ProjectileType("Squirrel1");
            item.shootSpeed = 8f;
        }

        public override bool UseItem(Player player)
        {
            Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType<Squirrel1>(), 0, 0,
                Main.myPlayer);
            return true;
        }
    }
}