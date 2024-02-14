using System;
using Bulker.Players;
using Bulker.UI;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.UI;

namespace Bulker.Globals;

public class MyItem : GlobalItem {
  public override bool InstancePerEntity => true;
  public bool IsBuying = false;

  public override void OnStack(Item destination, Item source, int numToTransfer) {
    if (source.isAShopItem) {
      int customNumToTransfer = BulkUtils.GetNewStackValue(destination);
      destination.stack += Math.Max(customNumToTransfer - numToTransfer, 1);
      IsBuying = false;
    }

    // base.OnStack(destination, source, numToTransfer);
  }

  public override bool CanStack(Item destination, Item source) {
    return base.CanStack(destination, source);
  }

  // Note that alternatively, you can use the ModPlayer.PostBuyItem hook to achieve the same functionality!
  public override void OnCreated(Item item, ItemCreationContext context) {
    if (context is not BuyItemCreationContext buyContext) {
      return;
    }

    item.TryGetGlobalItem(out MyItem myItem);
    if (myItem is { IsBuying: true }) {
      item.stack = BulkUtils.GetNewStackValue(item);
      if (item.maxStack == 1) {
        item.stack = 1;
        IEntitySource source = Main.LocalPlayer.GetSource_FromThis();
        for (int i = 0; i < BulkUtils.GetBulkMultiplier() - 1; i++) {
          Main.LocalPlayer.QuickSpawnItem(source, item, 1);
        }
      }
    }
#if DEBUG
    Main.NewText($"Item {item.Name} was bought");
#endif
    // For fun, we'll give the buying player a 50% chance to die whenever they buy this item from an NPC.
    if (!Main.rand.NextBool()) {
      return;
    }

    // This is only ever called on the local client, so the local player will do.
    // Player player = Main.LocalPlayer;
    // player.KillMe(PlayerDeathReason.ByCustomReason(DeathMessage.Format(player.name)), 9999, 0);
  }
}