using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class BeeEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        public int timer;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bee Enchantment");

            string tooltip = 
@"'According to all known laws of aviation, there is no way a bee should be able to fly'
33% chance for any friendly bee to become a Mega Bee
Mega Bees ignore most enemy defense, immune frames, and last twice as long
";
            string tooltip_ch = 
@"'根据目前所知的所有航空原理,蜜蜂应该根本不可能会飞'
33%概率使友善的蜜蜂成为巨型蜜蜂
巨型蜜蜂忽略大多数敌人的防御,无敌帧,并持续两倍的时间
";
            if(thorium != null)
            {
                tooltip += "Effects of Bee Booties\n";
                tooltip_ch += "拥有蜜蜂靴的效果\n";
            }

            tooltip += "Summons a pet Baby Hornet";
            tooltip_ch += "召唤一只小黄蜂";

            Tooltip.SetDefault(tooltip);
            DisplayName.AddTranslation(GameCulture.Chinese, "蜜蜂魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, tooltip_ch);
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 3;
            item.value = 50000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<FargoPlayer>(mod).BeeEffect(hideVisual);
            
            if(Fargowiltas.Instance.ThoriumLoaded) Thorium(player, hideVisual);
        }

        private void Thorium(Player player, bool hideVisual)
        {
            //bee booties
            if (Soulcheck.GetValue("Bee Booties"))
            {
                thorium.GetItem("BeeBoots").UpdateAccessory(player, hideVisual);
                player.moveSpeed -= 0.15f;
                player.maxRunSpeed -= 1f;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BeeHeadgear);
            recipe.AddIngredient(ItemID.BeeBreastplate);
            recipe.AddIngredient(ItemID.BeeGreaves);
            recipe.AddIngredient(ItemID.HiveBackpack);
            
            if(Fargowiltas.Instance.ThoriumLoaded)
            {      
                recipe.AddIngredient(thorium.ItemType("BeeBoots"));
                recipe.AddIngredient(ItemID.BeeGun);
                recipe.AddIngredient(thorium.ItemType("HoneyRecorder"));
                recipe.AddIngredient(ItemID.WaspGun);
                recipe.AddIngredient(ItemID.NettleBurst);
            }
            else
            {
                recipe.AddIngredient(ItemID.BeeGun);
                recipe.AddIngredient(ItemID.WaspGun);
            }
            
            recipe.AddIngredient(ItemID.Nectar);
            
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
