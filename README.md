# Pixygon — UI Tooltip

A lightweight hover-tooltip system for Unity UI.

## Overview

UI Tooltip shows a small floating panel with a header, subheader, and body when the pointer enters a UI element. It is built on Unity's event system (`IPointerEnterHandler` / `IPointerExitHandler`) and a single in-scene singleton, so any UI element can surface contextual help without per-widget wiring. It sits in the engine's UI layer as a drop-in utility — consumed by higher-level UI packages such as `pagedcontent`.

## Key types

| Type | What it is |
|---|---|
| **`TooltipSystem`** | Scene singleton that owns the active `Tooltip` and exposes static `Show` / `Hide`. Configures tablet mode and a position `multiplier`. |
| **`Tooltip`** | The tooltip view. Binds header/subheader/content text, hides empty fields, and widens its layout past a character-wrap limit. |
| **`TooltipTrigger`** | Drop on any UI element; calls `TooltipSystem.Show` on pointer enter and `Hide` on pointer exit. Holds `header` / `subheader` / `content` strings. |

## How games use it

1. Place the `Tooltip.prefab` (from `Assets/`) in your canvas and assign it to a `TooltipSystem` component in the scene.
2. Add a `TooltipTrigger` to any UI element and fill in its `header`, `subheader`, and `content` fields in the inspector.
3. Hover the element — the tooltip shows on enter and hides on exit, automatically.

```csharp
// Set tooltip text at runtime
var trigger = button.GetComponent<TooltipTrigger>();
trigger.SetTooltip(h: "Equip", s: "Mythic Blade", c: "+12 ATK, +3 SPD");

// Or drive the tooltip directly, no trigger required
TooltipSystem.Show(transform.position, "Out of mana", "Cast Failed");
TooltipSystem.Hide();
```

## Dependencies

None. Requires TextMeshPro, which ships with Unity.

## Install

```json
"com.pixygon.uitooltip": "https://github.com/Pixygon/com.pixygon.uitooltip.git"
```
