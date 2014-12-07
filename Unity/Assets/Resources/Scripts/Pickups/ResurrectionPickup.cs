using UnityEngine;
using System.Collections;
using System.Linq;

public class ResurrectionPickup : IPickup
{
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    // Called when something enters the pickups trigger box
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player" || m_pickedup)
        {
            return;
        }

        for (int playerIndex = 0; playerIndex < (int)PlayerIdentity.Noof; ++playerIndex)
        {
            var player = other.transform.parent.FindChild( ((PlayerIdentity)playerIndex).ToString() );
            if (player.gameObject.activeSelf == false)
            {
                player.gameObject.SetActive(true);
            }

            var character = player.GetComponent<ICharacter>();
            character.ResetHealth();
        }

        base.OnTriggerEnter2D(other);
    }
}
