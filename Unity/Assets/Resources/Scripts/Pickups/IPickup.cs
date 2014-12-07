﻿using UnityEngine;
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
    protected bool m_pickedup = false;
        m_audioSource = this.GetComponent<AudioSource>();
        {
            Debug.LogError(string.Format("The pickup {0} does no have an audio source component.", this.name));
        }
        {
            GameObject.Destroy(this.gameObject);
        }
        if (m_pickedup == false)
        {
            m_audioSource.clip = this.PickupSound;
            m_audioSource.Play();
            m_pickedup = true;
            this.GetComponent<SpriteRenderer>().enabled = false;
        }