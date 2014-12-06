using UnityEngine;using System.Collections;public abstract class ICharacter : MonoBehaviour {    /// <summary>    /// The starting health of the character    /// </summary>    public int Health = 20;    /// <summary>    /// The base speed multiplier of the character    /// </summary>    public float Speed = 1.0f;

    /// <summary>
    /// The rigid body of the character
    /// </summary>
    protected Rigidbody2D m_body = null;	// Use this for initialization    protected virtual void Start()     {
        m_body = this.GetComponent<Rigidbody2D>();        if (m_body == null)
        {
            Debug.LogError(string.Format("The character {0} does not have a rigid body 2d component.", this.name));
            this.gameObject.SetActive(false);
        }	}		// Update is called once per frame	protected virtual void Update ()     {	}    // Fixed updates is called once per physics update    protected virtual void FixedUpdate()    {    }    // Called when the player enters a collision    protected virtual void OnCollisionEnter2D(Collision2D collision)    {    }}