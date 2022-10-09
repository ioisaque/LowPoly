using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private bool isAlive;
    private Animator mAnim;

    public Slider slider;
    public int Hit;
    public float health, maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        slider.value = CalculateHealth();

        this.mAnim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         if (isAlive)
         {
            if (health <= 0)
            {
                Hit = 0;
                isAlive = false;
            }
            else
            {
                health -= Hit;
                Hit = 0;
                slider.value = CalculateHealth();
            }
        }else
            Destroy(gameObject);

        if (health > maxHealth)
            health = maxHealth;
    }

    private float CalculateHealth()
    {
        return health / maxHealth;
    }
}
