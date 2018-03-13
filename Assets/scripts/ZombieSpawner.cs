using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    [SerializeField]
    GameObject ZombiePrefab;

    [SerializeField]
    float Duration = 5f;

    [SerializeField]
    float AreaRadius = 5f;

    void Start()
    {
        StartCoroutine(SpawnZombieCoroutine());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, AreaRadius);
    }

    IEnumerator SpawnZombieCoroutine()
    {
        while(true)
        {
            SpawnZombie();

            yield return new WaitForSeconds(Duration);
        }
    }

    private void SpawnZombie()
    {
        var zombie = Instantiate(ZombiePrefab);
        zombie.transform.position = transform.position + Random.insideUnitSphere * AreaRadius;
    }
}
