using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public enum Actions { horizontal, vertical, fire1, submit, cancel, menu };
    public enum InputType { keyboard, joystick };

    public InputType inputType = InputType.keyboard;
    public int joyNum = 0;

    public Dictionary<Actions, string> input = new Dictionary<Actions, string>();

    // Start is called before the first frame update
    void Awake()
    {
        SetKeyboardControlled();
    }

    public void SetKeyboardControlled()
    {
        inputType = InputType.keyboard;
        UpdateInput("Key_");
    }

    public void SetJoystickController(int joyNum)
    {
        inputType = InputType.joystick;
        this.joyNum = joyNum;

        if (joyNum < 1 || joyNum > 4)
        {
            Debug.LogError("Joystick out of range");
        }

        string prefix = "J" + joyNum.ToString() + "_";

        UpdateInput(prefix);
    }

    private void UpdateInput(string prefix)
    {
        input[Actions.horizontal] = prefix + "Horizontal";
        input[Actions.vertical] = prefix + "Vertical";
        input[Actions.fire1] = prefix + "Fire1";
        input[Actions.cancel] = "Cancel";
        input[Actions.submit] = "Submit";
        input[Actions.menu] = "Menu";
    }

    public float GetY()
    {
        return Input.GetAxis(input[Actions.vertical]);
    }

    public float GetX()
    {
        return Input.GetAxis(input[Actions.horizontal]);
    }

    public bool InteractPressed()
    {
        return Input.GetButtonDown(input[Actions.fire1]); 
    }
}
