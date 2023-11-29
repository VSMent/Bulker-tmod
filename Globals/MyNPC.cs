using Bulker.Players;
using Terraria;
using Terraria.ModLoader;

namespace Bulker.Globals;

public class MyNPC : GlobalNPC {
  public override void ModifyShop(NPCShop shop) {
    base.ModifyShop(shop);
  }

  public override void ModifyActiveShop(NPC npc, string shopName, Item[] items) {
    base.ModifyActiveShop(npc, shopName, items);
    for (int i = 0; i < items.Length; i++) {
      Item item = items[i];
      if (item != null)
        item.stack = BulkUtils.GetNewStackValue(item);
    }
  }
}