using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    /// <summary>
    /// The number of seconds to wait before spawning the next wave of monsters
    /// </summary>
    public float RoundCooldownLength = 5.0f;

    /// <summary>
    /// The parent transform to all spawned characters
    /// </summary>
    public Transform CharacterContainer = null;

    /// <summary>
    /// The skellybob prefab
    /// </summary>
    public ICharacter SkellyBob = null;

    /// <summary>
    /// All spawn points in the current room
    /// </summary>
    private List<Vector3> m_spawnPoints = null;

    /// <summary>
    /// All spawn points in the current room
    /// </summary>
    private List<GameObject> m_spawnedMonsters = new List<GameObject>();

    /// <summary>
    /// The time at which the last round ended
    /// </summary>
    private float m_roundEndTime = -1.0f;

    /// <summary>
    /// The current round
    /// </summary>
    private int m_currentRound = 0;

	// Use this for initialization
	void Start () 
    {
        m_spawnPoints = Transform.FindObjectsOfType<SpawnPoint>().Select(x => new Vector3(x.transform.position.x, x.transform.position.y, 0.0f)).ToList();
        if (m_spawnPoints.Count == 0)
        {
            Debug.LogError("The current scene has 0 spawn points defined");
        }

        m_roundEndTime = Time.time;
	}

	void FixedUpdate () 
    {
	    if (m_roundEndTime != -1.0f)
        {
            if (Time.time - m_roundEndTime >= this.RoundCooldownLength)
            {
                m_roundEndTime = -1.0f;
                SpawnWave();
            }
            return;
        }

        foreach (var monster in m_spawnedMonsters)
        {
            var character = monster.GetComponent<ICharacter>();
            if (character.Health > 0.0f)
            {
                return;
            }
        }

        m_roundEndTime = Time.time;
	}

    private void SpawnWave()
    {
        foreach (var monster in m_spawnedMonsters)
        {
            GameObject.Destroy(monster);
        }
        m_spawnedMonsters.Clear();

        Debug.Log("Spawning new wave...");
        m_currentRound++;

        int waveSize = Random.Range(4, 5 + m_currentRound);

        for (int monsterIndex = 0; monsterIndex < waveSize; ++monsterIndex)
        {
            var spawnPoint = m_spawnPoints[Random.Range(0, m_spawnPoints.Count)];
            var newMonster = (GameObject)GameObject.Instantiate(SkellyBob.gameObject);
            
            newMonster.transform.position = spawnPoint;
            newMonster.transform.rotation = Quaternion.identity;
            newMonster.transform.localScale = Vector3.one;

            newMonster.transform.parent = this.CharacterContainer;

            newMonster.SetActive(true);

            m_spawnedMonsters.Add(newMonster);
        }

    }
}
