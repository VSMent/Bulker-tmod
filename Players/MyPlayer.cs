using Bulker.Systems;
using Bulker.UI;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bulker.Players;

public class MyPlayer : ModPlayer {
  public BulkMode SelectedBulkMode = BulkMode.x1;

  public override bool CanBuyItem(NPC vendor, Item[] shopInventory, Item item) {
    Main.LocalPlayer.GetItemExpectedPrice(item, out _, out long buyPrice);
    long bulkPrice = BulkUtils.GetBulkMultiplier() * buyPrice;
    bool canBuy = Main.LocalPlayer.CanAfford(bulkPrice);
#if DEBUG
    Main.NewText(canBuy
      ? $"Can buy with {BulkUtils.GetPriceString(bulkPrice)}"
      : $"Can't buy, need {BulkUtils.GetPriceString(bulkPrice)}");
#endif
    return canBuy;
  }

  public override void PostBuyItem(NPC vendor, Item[] shopInventory, Item item) {
    Main.LocalPlayer.GetItemExpectedPrice(item, out _, out long buyPrice);
    long debtAfterPurchase = (BulkUtils.GetBulkMultiplier() - 1) * buyPrice;
    Main.LocalPlayer.PayCurrency(debtAfterPurchase);
#if DEBUG
    Main.NewText($"Deducted {BulkUtils.GetPriceString(debtAfterPurchase)}");
#endif
  }

  public void UpdateBulkMode(BulkMode newMode) {
    SelectedBulkMode = newMode;
#if DEBUG
    Main.NewText($"Mode was set to {newMode}");
#endif
  }

  public override void ProcessTriggers(TriggersSet triggersSet) {
    if (KeybindSystem.ShowMenuKeybind.JustPressed) {
      ModContent.GetInstance<UISystem>().ToggleUI();
    }
  }
}