using UnityEngine;
using InControl;
using System.Collections;

public class KeyboardMouseProfile : UnityInputDeviceProfile {

	public KeyboardMouseProfile()
    {
        Name = "Keyboard and Mouse";
        Meta = "Keyboard and mouse input handling";

        SupportedPlatforms = new[] 
        {
            "Windows",
            "Mac",
            "Linux"
        };

        Sensitivity = 1.0f;
        LowerDeadZone = 0.0f;
        UpperDeadZone = 1.0f;

        ButtonMappings = new[]
        {
            new InputControlMapping
            {
                Handle = "LeftMouse",
                Target = InputControlType.RightTrigger,
                Source = MouseButton0
            },
        };

        AnalogMappings = new[]
        {
            new InputControlMapping
            {
                Handle = "W",
                Target = InputControlType.LeftStickY,
                Source = KeyCodeAxis(KeyCode.S, KeyCode.W)
            },
            new InputControlMapping
            {
                Handle = "A",
                Target = InputControlType.LeftStickX,
                Source = KeyCodeAxis(KeyCode.A, KeyCode.D)
            },
        };

    }

}
