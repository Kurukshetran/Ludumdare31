using UnityEngine;
using System.Collections;

public class StandardBullet : IBullet
{
	// Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.transform.position = this.transform.position + m_fireDirection;
    }

    // Called when the player enters a collision
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        m_fireDirection = Vector3.zero;
        this.gameObject.SetActive(false);
    }
}
