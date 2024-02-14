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
    foreach (var item in items) {
      if (item == null) continue;
      item.stack = BulkUtils.GetNewStackValue(item);
      item.TryGetGlobalItem(out MyItem myItem);
      if (myItem != null) {
        myItem.IsBuying = true;
      }
    }
  }
}