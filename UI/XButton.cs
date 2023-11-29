using Bulker.Items;
using Bulker.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace Bulker.UI;

public class XButton : UIPanel {
  // private Vector2 _screenPosition;
  private UIText _buttonText;
  private Vector2 _position;
  private readonly BulkMode _mode;
  private Color defaultBorderColor;
  private Color defaultBGColor;
  public Color activeBorderColor;
  public Color activeBGColor;


  public XButton(float x = 32, float y = 256, float w = 50, float h = 20, BulkMode mode = BulkMode.x10) {
    _position = new Vector2(x, y);
    _mode = mode;

    defaultBGColor = BackgroundColor;
    defaultBorderColor = BorderColor;

    activeBGColor = new Color(Color.Yellow.R, Color.Yellow.G, Color.Yellow.B, .7f);
    activeBorderColor = Color.LightGreen;


    // SetPadding(2);
    // Width.Set(48, 0);
    // Height.Set(20, 0);
    // HAlign = 0.5f;
    // Top.Set(y, 0);
    // OnLeftClick += OnButtonClick;
    //
    // _buttonText = new UIText(_mode.ToString(), 0.8f);
    // _buttonText.HAlign = _buttonText.VAlign = 0.5f;
    // Append(_buttonText);
  }

  public override void OnInitialize() {
    SetPadding(2);
    Width.Set(48, 0);
    Height.Set(20, 0);
    HAlign = 0.5f;
    Top.Set(_position.Y, 0);
    OnLeftClick += OnButtonClick;

    _buttonText = new UIText(_mode.ToString(), 0.8f);
    _buttonText.HAlign = _buttonText.VAlign = 0.5f;
    Append(_buttonText);
  }

  // public override void Draw(SpriteBatch spriteBatch) {
  //   // if (Main.npcShop <= 0)
  //   //   return;
  //
  //   base.Draw(spriteBatch);
  // }

  protected override void DrawSelf(SpriteBatch spriteBatch) {
    if (ContainsPoint(Main.MouseScreen)) {
      Main.LocalPlayer.mouseInterface = true;
    }

    if (IsMouseHovering) {
      PlayerInput.LockVanillaMouseScroll("Bulker/XButton");
      Main.hoverItemName = $"Buy items with {_mode} multiplier";
    }

    BackgroundColor = Main.LocalPlayer.GetModPlayer<MyPlayer>().SelectedBulkMode == _mode
      ? activeBGColor
      : defaultBGColor;
    BorderColor = Main.LocalPlayer.GetModPlayer<MyPlayer>().SelectedBulkMode == _mode
      ? activeBorderColor
      : defaultBorderColor;

    base.DrawSelf(spriteBatch);
  }

  private void OnButtonClick(UIMouseEvent evt, UIElement listeningElement) {
    // Main.NewText($"Set bulk mode to {_mode}");
    Main.LocalPlayer.GetModPlayer<MyPlayer>().UpdateBulkMode(_mode);

    // TODO remove logic from UI
  }


  // public override void OnActivate() {
  //   base.OnActivate();
  //   Main.NewText("activate");
  // }

  // public override void OnDeactivate() {
  //   base.OnDeactivate();
  //   Main.NewText("de activate");
  // }

  // public override void Update(GameTime gameTime) {
    // base.Update(gameTime);
    // if (Main.LocalPlayer.GetModPlayer<MyPlayer>().SelectedBulkMode == BulkMode.x1000) {
    //   Recalculate();
    //   MinWidth = _buttonText.MinWidth;
    //   MinHeight = _buttonText.MinHeight;
    // }
    // _buttonText.SetText(gameTime.ElapsedGameTime.ToString());
  // }

  // public override void MouseOver(UIMouseEvent evt) {
  //   base.MouseOver(evt);
  //   Main.hoverItemName = $"Buy items with {_mode} multiplier";
  // }

  // public override void MouseOut(UIMouseEvent evt) {
  //   base.MouseOut(evt);
  //   Main.NewText($"Mouse left {_mode} button");
  // }
}