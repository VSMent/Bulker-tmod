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
    return base.CanBuyItem(vendor, shopInventory, item);
  }

  public void UpdateBulkMode(BulkMode newMode) {
    SelectedBulkMode = newMode;
    Main.NewText($"Mode was set to {newMode}");
  }

  public override void ProcessTriggers(TriggersSet triggersSet) {
    if (KeybindSystem.ShowMenuKeybind.JustPressed) {
      ModContent.GetInstance<UISystem>().ToggleUI();
    }
  }
}