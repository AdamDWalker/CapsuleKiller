using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public Image healthBar;
    private static float health;
    private static float healthPercent;
	// Use this for initialization
	void Start ()
    {
        health = 3;
        healthPercent = 1;
        healthBar = GetComponent<Image>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        healthBar.transform.localScale = new Vector3(healthPercent, 1, 1);
        Debug.Log("Health is: " + healthPercent);
	}

    public static void getHealth(float healthVal)
    {
        health = healthVal;
        healthPercent = health / 3;
    }
}
