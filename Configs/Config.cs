using System.ComponentModel;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Config;

namespace Bulker.Configs;

public class Config : ModConfig {
  public override ConfigScope Mode => ConfigScope.ServerSide;

  // The things in brackets are known as "Attributes".

  [Header("Items")] // Headers are like titles in a config. You only need to declare a header on the item it should appear over, not every item in the category. 
  // [Label("$Some.Key")] // A label is the text displayed next to the option. This should usually be a short description of what it does. By default all ModConfig fields and properties have an automatic label translation key, but modders can specify a specific translation key.
  // [Tooltip("$Some.Key")] // A tooltip is a description showed when you hover your mouse over the option. It can be used as a more in-depth explanation of the option. Like with Label, a specific key can be provided.
  [DefaultValue(true)] // This sets the configs default value.
  [ReloadRequired] // Marking it with [ReloadRequired] makes tModLoader force a mod reload if the option is changed. It should be used for things like item toggles, which only take effect during mod loading
  public bool ExampleWingsToggle; // To see the implementation of this option, see ExampleWings.cs

  [ReloadRequired]
  public bool WeaponWithGrowingDamageToggle;


  [Range(0f, 200f)]
  [DefaultValue(typeof(Vector2), "200,200")]
  [Increment(1f)]
  public Vector2 vector2Size;
}