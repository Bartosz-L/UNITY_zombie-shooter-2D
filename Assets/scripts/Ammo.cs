using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Activator))]
public class Ammo : MonoBehaviour {

    public int Amount = 10;

	// Use this for initialization
	void Start () {
        var activator = GetComponent<Activator>();
        activator.OnActivated += () =>
        {
            // pickup an ammo by player, and destroy gameobj
            var player = FindObjectOfType<PlayerShooting>();
            player.CollectAmmo(Amount);
            Destroy(gameObject);
        };
	}

}
