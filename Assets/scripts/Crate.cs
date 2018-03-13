using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Activator))]
[RequireComponent(typeof(GenerateLoot))]
public class Crate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Activator>().OnActivated += () =>
        {
            GetComponent<GenerateLoot>().Generate();
            Destroy(gameObject);
        };
	}
}
