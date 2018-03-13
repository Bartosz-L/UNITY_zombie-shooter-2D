using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    [SerializeField]
    GameObject BulletPrefab;

    [SerializeField]
    float BulletSpeed = 10f;

    [SerializeField]
    Vector2 ShootPoint;

    private int bullets;
    public int Bullets
    {
        get
        {
            return bullets;
        }
        private set
        {
            bullets = value;

            if(OnBulletsChanged != null)
            {
                OnBulletsChanged.Invoke(bullets);
            }
        }
    }

    public event Action<int> OnBulletsChanged;
    
    // Use this for initialization
    void Start () {
        Bullets = 5;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
	}

    void ShootBullet()
    {
        if (Bullets == 0) return;

        // decrese number of bullets
        Bullets--;

        var bullet = Instantiate(BulletPrefab);
        // shoot bullet from gun, not from player
        bullet.transform.position = transform.position + transform.rotation * (Vector3)ShootPoint;
        // shoot bullet the direction player currenty looks
        bullet.transform.rotation = transform.rotation;
        // move the bullet
        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = transform.right * BulletSpeed;

    }

    public void CollectAmmo(int amount)
    {
        if (amount < 0)
            amount = 0;
        Bullets += amount;
    }
}
