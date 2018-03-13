using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour {

    public float Time = 3f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, Time);
	}
	
}
