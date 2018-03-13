using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Entity))]

public class Player : MonoBehaviour {
    [SerializeField]
    float WalkingSpeed = 2f;

    [SerializeField]
    float RunningSpeed = 4f;

    Rigidbody2D Rigidbody;
    Crosshair Crosshair;
    public void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Crosshair = FindObjectOfType<Crosshair>();
    }
    // Use this for initialization
    void Start () {
        GetComponent<Entity>().OnKilled += () => Application.Quit();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateMovement();
        UpdateRotation();
	}

    void UpdateMovement()
    {
        var WalkingDirection = Vector3.zero;

        WalkingDirection += Vector3.up * Input.GetAxis("Vertical");
        WalkingDirection += Vector3.right * Input.GetAxis("Horizontal");

        // to make walking direction eqaul to 1; 
        WalkingDirection = WalkingDirection.normalized;

        WalkingDirection *= Input.GetKey(KeyCode.LeftShift) ? RunningSpeed : WalkingSpeed;

        Rigidbody.velocity = Vector3.Lerp(Rigidbody.velocity, WalkingDirection, Time.deltaTime * 4f);
    }

    void UpdateRotation()
    {
        // player looking at the crosshair
        var delta = Crosshair.transform.position - transform.position;

        var targetRotation = (Vector2)delta;
        // to make player look the way he is walking (direction of vector)
        transform.right = Vector3.Lerp(transform.right, targetRotation, Time.deltaTime * 10f);
    }
}
