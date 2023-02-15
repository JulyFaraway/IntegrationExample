using Naninovel;
using Naninovel.Commands;
using UnityCommon;
using UnityEngine;

using Map;

[CommandAlias("showmap")]
public class OverlayDreamMap : Command
{
    public StringParameter ScriptName;
    public StringParameter Label;

    public string mapManagerName = "MapManager";
    public GameObject mapManagerObject;

    MapManager manager;

    public override async UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        // 1. Disable character control.
        var controller = Object.FindObjectOfType<CharacterController3D>();
        controller.IsInputBlocked = true;

        // 1. Disable Naninovel input.
        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = false;

        // 2. Stop script player.
        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.Stop();

        // 3. Hide text printer.
        var hidePrinter = new HidePrinter();
        hidePrinter.ExecuteAsync(asyncToken).Forget();

        // Slay The Spire Mapを表示
        mapManagerObject = GameObject.Find(mapManagerName);
        manager = mapManagerObject.GetComponent<MapManager>();
        manager.ActivateMap();
    }
}
