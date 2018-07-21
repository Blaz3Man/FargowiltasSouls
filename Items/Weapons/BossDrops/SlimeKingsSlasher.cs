using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSouls.Items.Weapons.BossDrops
{
	public class SlimeKingsSlasher : ModItem
	{
		private int _shoot = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime King's Slasher");
			Tooltip.SetDefault("'Torn from the insides of a defeated foe..'");
		}
		public override void SetDefaults()
		{
			item.damage = 16;
			item.melee=true;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1; 
			item.autoReuse = true; 
			item.shoot = mod.ProjectileType("SlimeBall");
			item.shootSpeed = 8f;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockback)
		{
			_shoot++;
			if (_shoot % 4 != 0) return false;
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockback, player.whoAmI);
			_shoot = 0;
			return false; 
        }



		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Slimed, 120);
		}
	}
}