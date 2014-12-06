using UnityEngine;using System.Collections;public class DamageTrigger : MonoBehaviour{    /// <summary>    ///     /// </summary>    private ICharacter m_character = null;	// Use this for initialization	void Start ()     {        m_character = this.GetComponent<ICharacter>();        if (m_character == null)        {            m_character = this.GetComponentInParent<ICharacter>();            if (m_character == null)            {                Debug.LogError(string.Format("Failed to find an ICharacter component in {0} or any of its parents.", this.name));                this.gameObject.SetActive(false);            }        }	}

    void OnTriggerEnter2D(Collider2D other)
    {
        var bullet = other.GetComponent<IBullet>();
        if (bullet != null)
        {
            bullet.OnHit(m_character);
        }
    }}