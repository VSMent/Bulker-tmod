using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bulker.Items {
public class bulk_sword : ModItem {
  // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.Bulker.hjson file.

  public override void SetDefaults() {
    Item.damage = 50000;
    Item.DamageType = DamageClass.Melee;
    Item.width = 40;
    Item.height = 40;
    Item.useTime = 20;
    Item.useAnimation = 20;
    Item.useStyle = ItemUseStyleID.GolfPlay;
    Item.knockBack = 6;
    Item.value = 10000;
    Item.rare = ItemRarityID.Master;
    Item.UseSound = SoundID.Item1;
    Item.autoReuse = true;
    Item.shoot = ProjectileID.ShadowFlame;
  }

  public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
    int type,
    int damage, float knockback) {
    Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
    float ceilingLimit = target.Y;
    if (ceilingLimit > player.Center.Y - 200f) {
      ceilingLimit = player.Center.Y - 200f;
    }

    CombatText.NewText(player.getRect(), Color.Wheat, $"firing at: {target}.");
#if DEBUG
    Dust.QuickDust(target, Color.Red);
    // Dust.QuickDust(player.BottomRight, Color.Blue);

    Main.NewText($"pos {position}, velocity {velocity}");
    Main.NewText($"screenPos {Main.screenPosition}");
    Main.NewText($"mousePos {{{Main.mouseX}, {Main.mouseY}}}");
    Main.NewText($"targetY {target.Y}");
    Main.NewText($"ceilingLimit {ceilingLimit}");
    Main.NewText($"playerCenter {player.Center}");
    Main.NewText($"direction {player.direction}");
    Main.NewText("");
#endif

    // Loop these functions 3 times.
    short[] projectileIds = { ProjectileID.Anchor, ProjectileID.Ale, ProjectileID.Blizzard };
    Vector2[] velocities = { new(1, 1), new(1, 0), new(1, -1) };
    for (int i = 0; i < 3; i++) {
      position = player.Center - new Vector2(100 * (i + 1) * -player.direction, 400f);
      position.Y -= 50 * i;
#if DEBUG
      Dust.QuickDust(position, Color.PeachPuff);
#endif
      Vector2 heading = target - position;

#if DEBUG
      Main.NewText($"Pr{i}: pos {position}, heading {heading}");
#endif
      if (heading.Y < 0f) {
        heading.Y *= -1f;
      }

      if (heading.Y < 20f) {
        heading.Y = 20f;
      }

      heading.Normalize();
      heading *= 2;
      // heading.Y += Main.rand.Next(-40, 41) * 0.2f;
#if DEBUG
      Main.NewText($"Pr{i}: new heading {heading}");
#endif
      Projectile.NewProjectile(source, position, heading, projectileIds[i], damage * 2, knockback, player.whoAmI,
        0f,
        ceilingLimit);
    }

    return false;
  }

  public override void AddRecipes() {
    Recipe recipe = CreateRecipe();
    recipe.AddIngredient(ItemID.DirtBlock, 10);
    recipe.AddTile(TileID.WorkBenches);
    recipe.Register();
  }
}
}