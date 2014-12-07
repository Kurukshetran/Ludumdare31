using UnityEngine;
using System.Collections;

public class DamageOnEnter : MonoBehaviour 
{
    /// <summary>
    /// The amount of damage to cause every tick
    /// </summary>
    public float DamagePerTick = 1.0f;

    /// <summary>
    /// 
    /// </summary>
    public float TickRate = 1.0f;

    /// <summary>
    /// 
    /// </summary>
    private float m_lastDamageTime = 0.0f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            return;
        }

        if (Time.time - m_lastDamageTime >= this.TickRate)
        {
            m_lastDamageTime = Time.time;
            var character = other.GetComponent<ICharacter>();
            character.Damage(this.DamagePerTick);
        }
    }
}
