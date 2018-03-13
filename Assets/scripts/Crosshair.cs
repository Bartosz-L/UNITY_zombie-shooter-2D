using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
    UnityEngine.Camera Camera;

	// Use this for initialization
	void Start () {
        Camera = FindObjectOfType<UnityEngine.Camera>();


	}
	
	// Update is called once per frame
	void Update () {
        // get mouse position on screen
        var mousePosition = Input.mousePosition;
        // convert screen position to world position
        var worldPosition = Camera.ScreenToWorldPoint(mousePosition);
        
        transform.position = (Vector2)worldPosition;

	}
}
