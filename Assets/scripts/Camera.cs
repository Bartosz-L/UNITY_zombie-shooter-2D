using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    Rigidbody2D Player;
    UnityEngine.Camera MainCamera;

	// Use this for initialization
	void Start () {
        Player = FindObjectOfType<Player>().GetComponent<Rigidbody2D>();
        MainCamera = GetComponent<UnityEngine.Camera>();
	}
	
	void FixedUpdate () {

        UpdatePosition();
        UpdateFOV();
    }

    void UpdatePosition()
    {
        var targetPosition = (Vector3)Player.position + (Vector3)Player.velocity * 0.5f + Vector3.back * 10f;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 4f);
    }

    void UpdateFOV()
    {
        var speed = Player.velocity.magnitude;

        var targetViewSize = 3f + speed / 2f;

        MainCamera.orthographicSize = Mathf.Lerp(
            MainCamera.orthographicSize,
            targetViewSize,
            Time.deltaTime);
    }
}
