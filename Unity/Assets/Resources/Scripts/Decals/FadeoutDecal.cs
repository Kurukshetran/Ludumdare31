using UnityEngine;using System.Collections;public class FadeoutDecal : MonoBehaviour {    private enum DecalState    {        Visible,        Fading,        Noof    }    /// <summary>    /// The number of seconds a decal should be full visible    /// </summary>    public float LifeSpan = 5.0f;    /// <summary>    /// The number of seconds it takes for a decal to fully fade out    /// </summary>    public float FadeLength = 2.0f;

    /// <summary>
    /// The amount of gray scale color variance to apply
    /// </summary>
    public float ColorVariance = 0.0f;    /// <summary>    /// The time at which the decal was created    /// </summary>    private float m_spawnTime = 0.0f;    /// <summary>    /// The time at which the decal started to fade    /// </summary>    private float m_fadeTime = 0.0f;    /// <summary>    /// The current state of the decal    /// </summary>    private DecalState m_state = DecalState.Visible;    /// <summary>    /// The decals sprite renderer    /// </summary>    private SpriteRenderer m_decal = null;

    /// <summary>
    /// The initial color of the decal
    /// </summary>
    private Color m_initialColor = Color.white;

    /// <summary>
    /// The faded color of the decal
    /// </summary>
    private Color m_fadedColor = Color.white;	// Use this for initialization	void Start ()     {        m_spawnTime = Time.time;        m_decal = this.GetComponent<SpriteRenderer>();

        var grayScale = (1.0f - this.ColorVariance) + Random.Range(0.0f, this.ColorVariance);
        m_initialColor = new Color(grayScale, grayScale, grayScale);
        m_fadedColor = new Color(grayScale, grayScale, grayScale, 0.0f);
        m_decal.color = m_initialColor;	}		// Update is called once per frame	void FixedUpdate ()     {	    switch (m_state)        {            case DecalState.Visible:            {                if (Time.time - m_spawnTime >= this.LifeSpan)                {                    m_state = DecalState.Fading;                    m_fadeTime = Time.time;                }                break;            }            case DecalState.Fading:            {                var time = Time.time - m_fadeTime;                var progress = time / this.FadeLength;
                var fadeColor = Color.Lerp(m_initialColor, m_fadedColor, progress);                m_decal.color = fadeColor;                if (progress > 1.0f)                {                    GameObject.Destroy(this.gameObject);                }                break;            }        }	}}