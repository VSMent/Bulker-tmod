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
    // } else if (item.maxStack == 1) {
      // result = 10; // Drop or add items to inventory
    } else {
      result = (int)mode;
    }

    return result;
  }

  public static int GetBulkMultiplier() {
    BulkMode mode = GetCurrentBulkMode();
    int result = (int)mode;
    return result;
  }

#if DEBUG
  public static string GetPriceString(long price) {
    string result = "";
    result += $"{price / Item.platinum}p ";
    price -= (price / Item.platinum) * Item.platinum;
    result += $"{price / Item.gold}g ";
    price -= (price / Item.gold) * Item.gold;
    result += $"{price / Item.silver}s ";
    price -= (price / Item.silver) * Item.silver;
    result += $"{price / Item.copper}c";
    return result;
  }
#endif
}