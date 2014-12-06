using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;public abstract class ICharacter : MonoBehaviour {       /// <summary>    /// The starting health of the character    /// </summary>
    public float Health = 20;    /// <summary>    /// The base speed multiplier of the character    /// </summary>    public float Speed = 1.0f;
    
    /// <summary>
    /// 
    /// </summary>
    public IBullet BulletTemplate = null;

    /// <summary>
    /// The maximum number of bullets allowed to exist at once
    /// </summary>
    public int MaximumNumberOfBullets = 20;

    /// <summary>
    /// The rate at which bullets are fired
    /// </summary>
    public float BulletFireRate = 1.0f;

    /// <summary>
    /// The container for all spawned bullets
    /// </summary>
    public Transform BulletContainer = null;    /// <summary>    /// The animation controller for this character    /// </summary>    protected ICharacterAnimationController m_animationController = null;    /// <summary>    /// The rigid body of the character    /// </summary>    protected Rigidbody2D m_body = null;

    /// <summary>
    /// The bullet this character uses
    /// </summary>
    protected List<IBullet> m_bullets = new List<IBullet>();    /// <summary>
    /// 
    /// </summary>
    protected Dictionary<SpriteRenderer, int> m_initialSortingOrders = new Dictionary<SpriteRenderer, int>();	// Use this for initialization    protected virtual void Start()     {        m_body = this.GetComponent<Rigidbody2D>();        if (m_body == null)        {            Debug.LogError(string.Format("The character {0} does not have a rigid body 2d component.", this.name));            this.gameObject.SetActive(false);        }        m_animationController = this.GetComponent<ICharacterAnimationController>();        if (m_animationController == null)        {            Debug.LogError(string.Format("The character {0} does not have an animation controller component.", this.name));            this.gameObject.SetActive(false);        }

        // Create bullets        for (int bulletIndex = 0; bulletIndex < this.MaximumNumberOfBullets; ++bulletIndex)
        {
            var newBullet = (IBullet)GameObject.Instantiate(this.BulletTemplate);
            newBullet.Setup();
            newBullet.gameObject.SetActive(false);
            newBullet.transform.parent = this.BulletContainer;
            m_bullets.Add(newBullet);
        }        // Store renderer sorting orders        var renderers = this.GetComponentsInChildren<SpriteRenderer>();        foreach (var renderer in renderers)
        {
            m_initialSortingOrders.Add(renderer, renderer.sortingOrder);
        }	}		// Update is called once per frame	protected virtual void Update ()     {
        int orderOffset = (int)(this.transform.position.y * 100.0f);

        var renderers = this.GetComponentsInChildren<SpriteRenderer>();        foreach (var renderer in renderers)
        {
            renderer.sortingOrder = m_initialSortingOrders[renderer] - orderOffset;
        }	}    // Fixed updates is called once per physics update    protected virtual void FixedUpdate()    {    }    // Called when the player enters a collision    protected virtual void OnCollisionEnter2D(Collision2D collision)    {    }    // Fire a new bullet in a given direction    protected void FireBullet(Vector2 direction)    {
        var bullet = m_bullets.FirstOrDefault(x => x.gameObject.activeSelf == false);        if (bullet == null)
        {
            Debug.LogWarning(string.Format("No bullets are avalible for the character {0}.", this.gameObject.name));
            return;
        }

        bullet.Fire(this.transform.position, direction);    }    public virtual void Damage(float amount)
    {
        this.Health -= amount;
        if (this.Health <= 0.0f)
        {
            this.gameObject.SetActive(false);
        }
    }}