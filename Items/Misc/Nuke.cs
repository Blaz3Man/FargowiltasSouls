using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Items.Misc
{
    public class Nuke : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galactic Reformer");
            Tooltip.SetDefault("Destroys an incredibly massive area\n" +
                                "Use at your own risk");
            DisplayName.AddTranslation(GameCulture.Chinese, "银河重构器");
            Tooltip.AddTranslation(GameCulture.Chinese, "破坏一片难以置信的巨大区域\n" +
                                                        "风险自负");
			DisplayName.AddTranslation(GameCulture.Russian, "Галактический реформатор");
			Tooltip.AddTranslation(GameCulture.Russian, "Разрушает невероятно большую область\n" +
														"Используйте на свой страх и риск"); 
        }

        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 32;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = 1;
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.value = Item.buyPrice(0, 0, 3);
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("NukeProj");
            item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Dynamite, 999);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}