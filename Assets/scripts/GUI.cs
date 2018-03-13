using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour {

    [SerializeField]
    Text BulletsCounter;

    [SerializeField]
    Text HealthCounter;

    // Use this for initialization
    void Awake () {

        FindObjectOfType<Player>().GetComponent<Entity>().OnHealthChanged += health =>
        {
            HealthCounter.text = health.ToString("N0");
        };

        FindObjectOfType<PlayerShooting>().OnBulletsChanged += bullets =>
        {
            BulletsCounter.text = bullets.ToString();
        };
	}
}
