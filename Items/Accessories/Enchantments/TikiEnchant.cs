﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class TikiEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tiki Enchantment");
            Tooltip.SetDefault(
@"'Aku Aku!'
Attacks will inflict Infested on enemies
Infested deals increasing damage over time
Summons a pet Tiki Spirit");
            DisplayName.AddTranslation(GameCulture.Chinese, "提基魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'Aku Aku!'
攻击造成感染效果
随着时间的推移,感染造成越来越多的伤害
召唤提基之灵");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 7;
            item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<FargoPlayer>(mod).TikiEffect(hideVisual);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TikiMask);
            recipe.AddIngredient(ItemID.TikiShirt);
            recipe.AddIngredient(ItemID.TikiPants);
            recipe.AddIngredient(ItemID.PygmyNecklace);
            recipe.AddIngredient(ItemID.PygmyStaff);
            recipe.AddIngredient(ItemID.Blowgun);
            
            if(Fargowiltas.Instance.ThoriumLoaded)
            {      
                recipe.AddIngredient(thorium.ItemType("HexWand"));
                recipe.AddIngredient(thorium.ItemType("TheIncubator"));
                recipe.AddIngredient(ItemID.GoldFrog);
            }
            
            recipe.AddIngredient(ItemID.TikiTotem);
            
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
