using UnityEngine;using System.Collections;public class StandardBullet : IBullet{
    /// <summary>
    /// The amount of damage the bullet will do
    /// </summary>
    public float BulletDamage = 1.0f;	// Use this for initialization    protected override void Start()    {        base.Start();    }    protected override void FixedUpdate()    {        base.FixedUpdate();        this.transform.position = this.transform.position + m_fireDirection;    }    // Called when the player enters a collision    protected override void OnCollisionEnter2D(Collision2D collision)    {        m_fireDirection = Vector3.zero;        this.gameObject.SetActive(false);    }

    /// <summary>
    /// Called when a bullet hits a character
    /// </summary>
    /// <param name="character"></param>
    public override void OnHit(ICharacter character)
    {
        m_fireDirection = Vector3.zero;
        this.gameObject.SetActive(false);

        character.Damage(this.BulletDamage);
    }}