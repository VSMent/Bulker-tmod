using System;
using Bulker.Configs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.UI;

namespace Bulker.UI;

public class ShopMenuUIState : UIState {
  private UIPanel _shopPanel;
  private XButton[] _xButtons;
  private UIText _buttonText;
  private UIPanel _button;

  public override void OnInitialize() {
    base.OnInitialize();
    /* 33806
     * if (Main.mouseX > 73 && Main.mouseX < (int) (73.0 + 560.0 * (double) Main.inventoryScale) && Main.mouseY > this.invBottom && Main.mouseY < (int) ((double) this.invBottom + 224.0 * (double) Main.inventoryScale) && !PlayerInput.IgnoreMouseInterface)
          Main.player[Main.myPlayer].mouseInterface = true;
        for (int index5 = 0; index5 < 10; ++index5)
        {
          for (int index6 = 0; index6 < 4; ++index6)
          {
            int x = (int) (73.0 + (double) (index5 * 56) * (double) Main.inventoryScale);
            int y20 = (int) ((double) this.invBottom + (double) (index6 * 56) * (double) Main.inventoryScale);

    // Main.inventoryScale
    // Main.OpenShop

    // Main.inventoryScale;
    // Main.UIScale;
     */


    // Main.inventoryScale = 0.755f;
    _shopPanel = new UIPanel();
    _shopPanel.SetPadding(2);
    // _shopPanel.Width.Set(56, 0);
    _shopPanel.Width.Set(250, 0);
    _shopPanel.Height.Set(250, 0);
    // _shopPanel.Left.Set(73 - 56 * Main.inventoryScale, 0);
    _shopPanel.HAlign = 0.5f;
    _shopPanel.Top.Set(Main.instance.invBottom, 0);
    Append(_shopPanel);

    // UIText header = new UIText("My UI Header");
    // header.HAlign = 0.5f;
    // // header.Top.Set(15, 0);
    // _shopPanel.Append(header);

    // _button = new UIPanel();
    // _button.SetPadding(2);
    // // Vector2 size = ModContent.GetInstance<Config>().vector2Size;
    // _button.Width.Set(48, 0);
    // _button.Height.Set(20, 0);
    // // _button.Width.Set(size.X, 0);
    // // _button.Height.Set(size.Y, 0);
    // _button.HAlign = 0.5f;
    // _button.Top.Set(25, 0);
    // _button.OnLeftClick += OnButtonClick;
    // _shopPanel.Append(_button);
    //
    // _buttonText = new UIText("x1000", 0.8f);
    // _buttonText.HAlign = _buttonText.VAlign = 0.5f;
    // _button.Append(_buttonText);


    string[] modes = Enum.GetNames(typeof(BulkMode));
    _xButtons = new XButton[modes.Length];

    for (int i = 0; i < modes.Length; i++) {
      Enum.TryParse(modes[i], out BulkMode mode);
      _xButtons[i] = new XButton(y: /*Main.instance.invBottom +*/ 25 * i, mode: mode);

      _shopPanel.Append(_xButtons[i]);
    }
  }

  // public override void Update(GameTime gameTime) {
  //   base.Update(gameTime);
  //
  //   // if (_buttonText.IsMouseHovering) {
  //   //   Main.hoverItemName = "Click to see what happens";
  //   // }
  //   //
  //   // if (_button.IsMouseHovering) {
  //   //   Main.hoverItemName = "hovering a button";
  //
  //   // }
  // }
  public override void OnActivate() {
    base.OnActivate();
    Vector2 size = ModContent.GetInstance<Config>().vector2Size;
    _shopPanel.Width.Set(size.X, 0);
    _shopPanel.Height.Set(size.Y, 0);
  }

  public override void OnDeactivate() {
    base.OnDeactivate();
  }

  protected override void DrawSelf(SpriteBatch spriteBatch) {
    base.DrawSelf(spriteBatch);

    if (_shopPanel.ContainsPoint(Main.MouseScreen)) {
      Main.LocalPlayer.mouseInterface = true;
      PlayerInput.LockVanillaMouseScroll("Bulker/XButton");
      // Main.hoverItemName = "hovering a panel (draw self)";
    }
  }

  // private void OnButtonClick(UIMouseEvent evt, UIElement listeningElement) {
  //   Main.NewText("button was clicked");
  //   // _buttonText.SetText("I was clicked");
  //   // if(Random.Shared.Next(2)>0)
  //   // {
  //   //   Main.hoverItemName = "hovering";
  //   // }
  //   // _button.Width.Set(ModContent.GetInstance<Config>().vector2Size.X, 0);
  //   // _button.Height.Set(ModContent.GetInstance<Config>().vector2Size.Y, 0);
  // }
}