using FargowiltasSouls.NPCs;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSouls.Buffs.Souls
{
    public class Shock : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shock");
            Main.buffNoSave[Type] = true;
            DisplayName.AddTranslation(GameCulture.Chinese, "电击");
			DisplayName.AddTranslation(GameCulture.Russian, "Шок");
        }

        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "FargowiltasSouls/Buffs/PlaceholderDebuff";
            return true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<FargoGlobalNPC>(mod).Shock = true;
        }
    }
}