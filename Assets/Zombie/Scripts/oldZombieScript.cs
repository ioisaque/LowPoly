using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oldZombieScript : MonoBehaviour
{
    private bool isAlive;
    private Animator mAnim;
    private GameObject player;
    private Vector3 playerPOS;


    public Slider slider;
    public int Hit;
    public GameObject healthBarUI;
    public float health, maxHealth;

    public float attackDist, heightOfY;

    // Start is ca lled before the first frame update
    void Start()
    {
        isAlive = true;
        slider.value = CalculateHealth();

        this.player = GameObject.FindGameObjectWithTag("Player");
        this.mAnim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            playerPOS = new Vector3(this.player.transform.position.x, heightOfY, this.player.transform.position.z);

            if (health <= 0)
            {
                Hit = 0;
                isAlive = false;
                GameRules.BodyCount++;
                healthBarUI.SetActive(false);
                this.mAnim.SetTrigger("death");
                StartCoroutine(RemoveCorpse());
            }
            else
            {
                health -= Hit;
                Hit = 0;
                slider.value = CalculateHealth();

                transform.LookAt(playerPOS);

                if (getDistanceFromPlayer() > attackDist)
                    this.mAnim.SetTrigger("walk");
                else
                    this.mAnim.SetTrigger("attack");
            }
        }
    }

    private float CalculateHealth()
    {
        return health / maxHealth;
    }

    private float getDistanceFromPlayer()
    {
        Vector3 pPOS = this.player.transform.position;
        Vector3 zPOS = this.transform.position;

        return Vector2.Distance(pPOS, zPOS);
    }

    //Time before destroy the object
    private IEnumerator RemoveCorpse()
    {
        yield return new WaitForSeconds(5);

        Destroy(gameObject);
    }
}
