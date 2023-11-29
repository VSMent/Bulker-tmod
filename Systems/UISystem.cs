using System.Collections.Generic;
using Bulker.UI;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace Bulker;

public class UISystem : ModSystem {
  internal ShopMenuUIState ShopMenuUiState;
  private UserInterface _interface;
  private GameTime _lastUpdateUiGameTime;

  public override void Load() {
    if (!Main.dedServ) {
      ShopMenuUiState = new ShopMenuUIState();
      ShopMenuUiState.Activate();

      _interface = new UserInterface();
      ShowShopMenuUI();
    }
  }

  public override void Unload() {
    ShopMenuUiState = null;
  }

  public override void UpdateUI(GameTime gameTime) {
    _lastUpdateUiGameTime = gameTime;
    if (_interface?.CurrentState != null) {
      _interface.Update(gameTime);
    }

    // if (Main.npcShop > 0)
    //   ShowShopMenuUI();
    // else
    //   HideShopMenuUI();
  }

  public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
    int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
    if (mouseTextIndex != -1) {
      layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
        "Bulker: Shop menu buttons",
        delegate {
          if (_lastUpdateUiGameTime != null && _interface?.CurrentState != null) {
            _interface.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
          }

          return true;
        },
        InterfaceScaleType.UI)
      );
    }
  }

  internal void ShowShopMenuUI() {
    _interface?.SetState(ShopMenuUiState);
  }

  internal void HideShopMenuUI() {
    _interface?.SetState(null);
  }

  internal void ToggleUI() {
    if (_interface.CurrentState != null) {
      HideShopMenuUI();
    } else {
      ShowShopMenuUI();
    }
  }
}