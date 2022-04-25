# SimpleToast Guide #

## Usage ##
1. Drag **SimpleToastUI** prefab to persistent scene, it will be singleton.
2. In script, call `SimpleToast.Show("Hello World!")` to show new toast.
3. If you want customize color, call `SimpleToast.Show("Hello World!", Color.red)`.

## Custom Config ##
This plugin is ultimate simple/pure/primitive that you can directly change the **SimpleToastUI** prefab in the scene to make it suitable for your project.

* Default alignment is add new toast on screen top, if you want to add from bottom, select the `Container` gameobject under `SimpleToastUI` prefab. In `VerticalLayoutGroup`, change `child alignment` to lower and untoggle `reverse alignment`.

* To make it simplest, you can remove the `Text(UGUI)` or `Text(TMP)` gameobject that you don't use, ensure the only text gameobject active self.