using UnityEngine;
using System.Collections;

public class ButtonToScene : MonoBehaviour 
{
    /// <summary>
    /// The scene to navigate too
    /// </summary>
    public string NavigateToScene = null;

    public void OnPress()
    {
        Application.LoadLevel(this.NavigateToScene);
    }
}
