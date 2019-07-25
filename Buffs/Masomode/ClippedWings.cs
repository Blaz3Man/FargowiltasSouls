using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Buffs.Masomode
{
    public class ClippedWings : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Clipped Wings");
            Description.SetDefault("You cannot fly or use rocket boots");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            canBeCleared = true;
            DisplayName.AddTranslation(GameCulture.Chinese, "剪除羽翼");
            Description.AddTranslation(GameCulture.Chinese, "无法飞翔或使用火箭靴");
			DisplayName.AddTranslation(GameCulture.Russian, "Срезанные крылья");
            Description.AddTranslation(GameCulture.Russian, "Вы не можете летать и использовать ракетные ботинки");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.wingTime = 0;
            player.wingTimeMax = 0;
            player.rocketTime = 0;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.position -= npc.velocity / 2;
            if (npc.velocity.Y < 0)
                npc.velocity.Y = 0;
        }
    }
}