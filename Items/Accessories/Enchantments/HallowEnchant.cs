using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Accessories.Enchantments
{
    public class HallowEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Enchantment");
            Tooltip.SetDefault("'Hallowed be your sword and shield' \nYou are immune to knockback \nSummons a shield that can reflect projectiles into enchanted swords \nYou also summon enchanted swords to attack enemies");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 5;
            item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            EffectAdd(player, hideVisual, mod);
        }

        public static void EffectAdd(Player player, bool hideVisual, Mod mod)
        {
            player.noKnockback = true;
            if (Soulcheck.GetValue("Hallowed Shield"))
            {
                player.GetModPlayer<FargoPlayer>(mod).HallowEnchant = true;
                //shield and sword
                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.ownedProjectileCounts[mod.ProjectileType("HallowProj")] < 1)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, mod.ProjectileType("HallowProj"), 80/*dmg*/, 2f, Main.myPlayer);
                    }
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("FargowiltasSouls:AnyHallowHead");
            recipe.AddIngredient(ItemID.HallowedPlateMail);
            recipe.AddIngredient(ItemID.HallowedGreaves);
            recipe.AddIngredient(ItemID.Excalibur);
            recipe.AddIngredient(ItemID.CobaltShield);
            recipe.AddIngredient(ItemID.DaedalusStormbow);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
