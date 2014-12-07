using UnityEngine;using System.Collections;public abstract class IPickup : MonoBehaviour{
    /// <summary>
    /// The sound played on pickup
    /// </summary>
    public AudioClip PickupSound = null;

    /// <summary>
    /// The audio source for this pickup
    /// </summary>
    protected AudioSource m_audioSource = null;

    /// <summary>
    /// Has the pickup been picked up?
    /// </summary>
    protected bool m_pickedup = false;	// Use this for initialization    protected virtual void Start()     {
        m_audioSource = this.GetComponent<AudioSource>();        if (m_audioSource == null)
        {
            Debug.LogError(string.Format("The pickup {0} does no have an audio source component.", this.name));
        }	}		// Update is called once per frame	protected virtual void Update ()     {	    if (m_pickedup && !m_audioSource.isPlaying)
        {
            GameObject.Destroy(this.gameObject);
        }	}    protected virtual void OnTriggerEnter2D(Collider2D other)    {
        if (m_pickedup == false)
        {
            m_audioSource.clip = this.PickupSound;
            m_audioSource.Play();
            m_pickedup = true;
            this.GetComponent<SpriteRenderer>().enabled = false;
        }    }}