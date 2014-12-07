using UnityEngine;
using System.Collections;

public class PickupManager : MonoBehaviour 
{
    /// <summary>
    /// The health kit prefab
    /// </summary>
    public GameObject HealthKit = null;

    /// <summary>
    /// Singleton instance
    /// </summary>
    private static PickupManager s_instance = null;

    /// <summary>
    /// Public access to the pickup manager instance
    /// </summary>
    public static PickupManager Instance
    {
        get { return s_instance; }
    }

    void Awake()
    {
        if (s_instance != null)
        {
            Debug.LogError("MUltiple pickup managers exist!");
            return;
        }

        s_instance = this;
    }

    /// <summary>
    /// Add a health pickup if a random number is less than chance
    /// </summary>
    /// <param name="position"></param>
    /// <param name="chance"></param>
    public void MaybeAddHealthPickup(Vector3 position, float chance)
    {
        if (Random.Range(0.0f, 1.0f) > chance)
        {
            return;
        }

        var pickup = (GameObject)GameObject.Instantiate(this.HealthKit);
        pickup.transform.parent = this.transform;
        pickup.transform.position = position;
    }
}
