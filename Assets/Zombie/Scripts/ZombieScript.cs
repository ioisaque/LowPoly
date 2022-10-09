using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieScript : MonoBehaviour
{
    private bool isAlive;
    private Animator mAnim;
    private GameObject player;
    private Vector3 playerPOS;

    public int Hit;
    public float health, maxHealth;

    public float attackDist, heightOfY;

    // Start is ca lled before the first frame update
    void Start()
    {
        isAlive = true;

        this.mAnim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        player = FindClosestPlayer();

        if (isAlive)
        {
            playerPOS = new Vector3(this.player.transform.position.x, heightOfY, this.player.transform.position.z);

            if (health <= 0)
            {
                Hit = 0;
                isAlive = false;
                GameRules.BodyCount++;
                this.mAnim.SetTrigger("death");
                StartCoroutine(RemoveCorpse());
            }
            else
            {
                health -= Hit;
                Hit = 0;

                transform.LookAt(playerPOS);

                if (getDistanceFromPlayer() < (attackDist+0.1))
                    this.mAnim.SetTrigger("idle");
                else if (getDistanceFromPlayer() < attackDist)
                    this.mAnim.SetTrigger("attack");
                else
                    this.mAnim.SetTrigger("walk");
            }
        }
    }

    private float getDistanceFromPlayer()
    {
        Vector3 pPOS = this.player.transform.position;
        Vector3 zPOS = this.transform.position;

        return Vector2.Distance(pPOS, zPOS);
    }

    public GameObject FindClosestPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    //Time before destroy the object
    private IEnumerator RemoveCorpse()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
