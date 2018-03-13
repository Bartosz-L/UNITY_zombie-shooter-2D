using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLoot : MonoBehaviour {

    [SerializeField]
    GameObject Prefab;

    [SerializeField]
    int Min = 5;

    [SerializeField]
    int Max = 15;

    [SerializeField]
    float Probability = 0.25f;

	public void Generate ()
    {
        if (Random.value > Probability) return;

        var loot = Instantiate(Prefab);
        loot.transform.position = transform.position;

        loot.GetComponent<Ammo>().Amount = Random.Range(Min, Max);
	}
}
