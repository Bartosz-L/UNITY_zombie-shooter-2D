using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletDamage : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var entity = collision.gameObject.GetComponent<Entity>();

        if (entity != null)
        {
            entity.Health -= 1f;
        }

        Destroy(gameObject);
    }

}
