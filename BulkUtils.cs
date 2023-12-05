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

  public static int GetBulkMultiplier() {
    BulkMode mode = GetCurrentBulkMode();
    int result = (int)mode;
    return result;
  }

#if DEBUG
  public static string GetPriceString(long price) {
    string result = "";
    for (int i = 1_000_000; i > 0; i /= 100) {
      char coinChar = i switch {
        1_000_000 => 'p',
        10_000 => 'g',
        100 => 's',
        _ => 'c'
      };
      result += $"{price / i}{coinChar} ";
      price -= (int)price / i * i;
    }

    return result;
  }
#endif
}