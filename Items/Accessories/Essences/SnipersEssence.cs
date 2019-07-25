using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Items.Accessories.Essences
{
    public class SnipersEssence : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sniper's Essence");
            Tooltip.SetDefault(
@"'This is only the beginning..'
18% increased ranged damage
5% increased ranged critical chance
5% increased firing speed");
            DisplayName.AddTranslation(GameCulture.Chinese, "狙击手精华");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'这才刚刚开始..'
增加18%远程伤害
增加5%远程暴击率
增加5%开火速度");
            DisplayName.AddTranslation(GameCulture.Russian, "Эссенция снайпера");
            Tooltip.AddTranslation(GameCulture.Russian, 
@"'Это только начало...'
+18% к дальнему урону
+5% к шансу дальнего крита
+5% к скорости дальнего боя");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 150000;
            item.rare = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.rangedDamage += .18f;
            player.rangedCrit += 5;
            player.GetModPlayer<FargoPlayer>(mod).RangedEssence = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            if (Fargowiltas.Instance.ThoriumLoaded)
            {
                //just thorium
                recipe.AddIngredient(ItemID.RangerEmblem);
                recipe.AddIngredient(ItemID.PainterPaintballGun);
                //recipe.AddIngredient(ItemID.SnowballCannon);
                recipe.AddIngredient(ItemID.RedRyder);
                recipe.AddIngredient(ItemID.Harpoon);
                recipe.AddIngredient(ItemID.Musket);
                recipe.AddIngredient(thorium.ItemType("GuanoGunner"));
                recipe.AddIngredient(thorium.ItemType("SharkStorm"));
                recipe.AddIngredient(ItemID.BeesKnees);
                recipe.AddIngredient(thorium.ItemType("EnergyStormBolter"));
                recipe.AddIngredient(thorium.ItemType("HeroTripleBow"));
                recipe.AddIngredient(thorium.ItemType("HitScanner"));
                recipe.AddIngredient(thorium.ItemType("RangedThorHammer"));
                recipe.AddIngredient(ItemID.HellwingBow);
            }
            else
            {
                //no others
                recipe.AddIngredient(ItemID.RangerEmblem);
                recipe.AddIngredient(ItemID.PainterPaintballGun);
                //recipe.AddIngredient(ItemID.SnowballCannon); add a thing
                recipe.AddIngredient(ItemID.RedRyder);
                recipe.AddIngredient(ItemID.Harpoon);
                recipe.AddIngredient(ItemID.Musket);
                recipe.AddIngredient(ItemID.Boomstick);
                recipe.AddIngredient(ItemID.BeesKnees);
                recipe.AddIngredient(ItemID.HellwingBow);
            }

            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
