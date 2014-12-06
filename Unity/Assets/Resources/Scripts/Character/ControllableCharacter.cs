using UnityEngine;using System.Collections;public class ControllableCharacter : ICharacter {
    /// <summary>
    /// The last known direction of the character
    /// </summary>
    private Vector2 m_direction = new Vector2(0, -1);	// Use this for initialization	protected override void Start ()     {        base.Start();	}    // Update is called once per frame    protected override void Update()    {        base.Update();    }		// Fixed updates is called once per physics update    protected override void FixedUpdate()    {        base.FixedUpdate();        var initialPosition = this.transform.position;        var movement = Vector3.zero;        const float movementAmount = 0.1f;        // Test input for movement        if (Input.GetKey(KeyCode.W)) // UP        {            movement.y += movementAmount;        }                if (Input.GetKey(KeyCode.S)) // Down        {            movement.y -= movementAmount;        }                if (Input.GetKey(KeyCode.A)) // Left        {            movement.x -= movementAmount;        }                if (Input.GetKey(KeyCode.D)) // Right        {            movement.x += movementAmount;        }        this.transform.position = initialPosition + (movement * GetSpeedScale());        var animController = GetAnimationController();        if (movement.sqrMagnitude != 0.0f)        {            animController.PlayWalkAnimation();
            m_direction = movement;        }        else        {            animController.PlayIdleAnimation();        }        // Test for shooting input        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.FireBullet(m_direction);
        }	}    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>    private float GetSpeedScale()    {        return this.Speed;    }    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>    private ControllableCharacterAnimationController GetAnimationController()    {        return m_animationController as ControllableCharacterAnimationController;    }    // Called when the player enters a collision    protected override void OnCollisionEnter2D(Collision2D collision)    {    }}