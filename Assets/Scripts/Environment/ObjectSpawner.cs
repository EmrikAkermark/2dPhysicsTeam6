using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
	public GameObject[] SpawnableObjects;
	public float TimeBetweenSpawns = 3f;

	public bool CanSpawnFromStart = true;

	private bool canSpawn;

	private float timer;
    
	public void ActivateSpawning()
	{
		timer = 0f;
		canSpawn = true;
	}

	public void DeactivateSpawning()
	{
		canSpawn = false;
	}


    // Update is called once per frame
    void Update()
    {
		if (!canSpawn)
			return;

		timer += Time.deltaTime;
		if (timer >= TimeBetweenSpawns)
		{
			Instantiate(SpawnableObjects[Random.Range(0, SpawnableObjects.Length - 1)], transform.position, transform.rotation);
			timer = 0f;
		}
    }
}
