using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class MeteorEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Enchantment");

            string tooltip = 
@"'Cosmic power builds your magical prowess'
A meteor shower initiates every few seconds while attacking";
            string tooltip_ch =
@"'宇宙之力构建你的超凡魔法'
攻击时,每隔几秒爆发一次流星雨";

            if(thorium != null)
            {
                tooltip += "\nSummons a pet Bio-Feeder";
                tooltip_ch += "\n召唤一个奇怪的外星生物";
            }

            Tooltip.SetDefault(tooltip);
            DisplayName.AddTranslation(GameCulture.Chinese, "陨星魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, tooltip_ch);
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 5;
            item.value = 100000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoPlayer modPlayer = player.GetModPlayer<FargoPlayer>();
            modPlayer.MeteorEffect(50);

            if (Fargowiltas.Instance.ThoriumLoaded) Thorium(player, hideVisual);
        }

        private void Thorium(Player player, bool hideVisual)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            thoriumPlayer.bioPet = true;
            player.GetModPlayer<FargoPlayer>().AddPet("Bio-Feeder Pet", hideVisual, thorium.BuffType("BioFeederBuff"), thorium.ProjectileType("BioFeederPet"));
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteorHelmet);
            recipe.AddIngredient(ItemID.MeteorSuit);
            recipe.AddIngredient(ItemID.MeteorLeggings);
            recipe.AddIngredient(ItemID.SpaceGun);
            recipe.AddIngredient(ItemID.StarCannon);

            if(Fargowiltas.Instance.ThoriumLoaded)
            {
                recipe.AddIngredient(thorium.ItemType("StarTrail"));
                recipe.AddIngredient(thorium.ItemType("CometCrossfire"));
                recipe.AddIngredient(ItemID.MeteorStaff);
                recipe.AddIngredient(ItemID.PlaceAbovetheClouds);
                recipe.AddIngredient(thorium.ItemType("BioPod"));
            }
            else
            {
                recipe.AddIngredient(ItemID.MeteorStaff);
                recipe.AddIngredient(ItemID.PlaceAbovetheClouds);
            }
            
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
