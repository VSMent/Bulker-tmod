using Bulker.Players;
using Bulker.UI;
using Terraria;

namespace Bulker;

public class BulkUtils {
  public static BulkMode GetCurrentBulkMode() {
    return Main.LocalPlayer.GetModPlayer<MyPlayer>().SelectedBulkMode;
  }

  public static int GetNewStackValue(Item item) {
    BulkMode mode = GetCurrentBulkMode();
    int result = 1;
    if (mode == BulkMode.xStack) {
      result = item.maxStack;
    } else if (item.maxStack == 1) {
      result = 1; // Drop or add items to inventory
    } else {
      result = (int)mode;
    }

    return result;
  }
}