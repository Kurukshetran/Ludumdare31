using UnityEngine;using System.Collections;public class MeleeCharacter : ICharacter{    /// <summary>    /// The distance a player needs to be for the character to agro against them    /// </summary>    public float AgroRange = 10.0f;

    /// <summary>
    /// The distance a player needs to be for the character to attack them
    /// </summary>
    public float AttackRange = 2.0f;

    /// <summary>
    /// The amount of damage done per hit
    /// </summary>
    public float DamagePerHit = 1.0f;	// Use this for initialization	protected override void Start ()     {        base.Start();	}		// Update is called once per frame    protected override void Update()    {        base.Update();	}    // Fixed updates is called once per physics update    protected override void FixedUpdate()    {        base.FixedUpdate();

        var isAgroed = false;
        var isAttacking = false;

        GameObject closestPlayer = null;
        float distanceToClosestPlayer = float.MaxValue;        var players = GameObject.FindGameObjectsWithTag("Player");        foreach (var player in players)        {
            var toPlayerVector = player.transform.position - this.transform.position;
            var distance = toPlayerVector.magnitude;            if (distance <= distanceToClosestPlayer)
            {
                closestPlayer = player;
                distanceToClosestPlayer = distance;
            }
        }

        if (distanceToClosestPlayer <= this.AttackRange)
        {
            isAttacking = true;
            var character = closestPlayer.GetComponent<ICharacter>();
            character.Damage(this.DamagePerHit);
        }
        else if (distanceToClosestPlayer <= this.AgroRange)
        {
            var toPlayerVector = closestPlayer.transform.position - this.transform.position;
            var movement = toPlayerVector.normalized;
            this.transform.position = this.transform.position + (movement * this.Speed);
            isAgroed = true;
        }        var animController = GetAnimationController();
        if (isAttacking)
        {
            animController.PlayAttackAnimation();
            if (!m_audioSource.isPlaying)
            {
                m_audioSource.clip = this.AttackAudio;
                m_audioSource.Play();
            }
        }        else if (isAgroed)        {            animController.PlayWalkAnimation();        }        else        {            animController.PlayIdleAnimation();        }            }    /// <summary>    ///     /// </summary>    /// <returns></returns>    private ControllableCharacterAnimationController GetAnimationController()    {        return m_animationController as ControllableCharacterAnimationController;    }}