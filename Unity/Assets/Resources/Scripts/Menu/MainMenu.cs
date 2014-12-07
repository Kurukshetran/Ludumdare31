using UnityEngine;
using System.Collections;
using System.Linq;

public class MainMenu : MonoBehaviour 
{
    public const string VAR_HIGHSOCRE = "Highscore";

    /// <summary>
    /// All labels used to display the highscore
    /// </summary>
    public UnityEngine.UI.Text[] m_highscoreLabels = null;

	// Use this for initialization
	void Start ()
    {
        // Load highscore
        var highscore = PlayerPrefs.GetInt(VAR_HIGHSOCRE, 0);

        foreach (var label in m_highscoreLabels)
        {
            label.text = string.Format("HighScore {0}", highscore.ToString("D7"));
        }
	}
}
