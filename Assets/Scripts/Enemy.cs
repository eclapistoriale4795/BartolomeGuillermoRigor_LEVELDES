using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Zombie enemy; //Scriptable Object to call
    public GameObject target; //Reference the player position
    public Player player; //Reference the player scriptable object
    public TriggerArea tArea;
    public Animator anime;
    public float cdn;
    public float atk;
    public int myHP;
    public NavMeshAgent ai;
    public bool ok;
    public SphereCollider meleerange;
    public CapsuleCollider hitbox;
    // Start is called before the first frame update
    void Start()
    {
        enemy.agent = GetComponent<NavMeshAgent>();
        Zombie stats = Instantiate(enemy);
        stats.hp = enemy.hp;
        stats.alive = enemy.alive;
        stats.agent = enemy.agent;
        myHP = stats.hp;
        ok = stats.alive;
        ai = stats.agent;
        atk = cdn;
        anime.SetBool("Active", false);
        target = GameObject.FindGameObjectWithTag("Player");
        meleerange = GetComponent<SphereCollider>();
        hitbox = GetComponent<CapsuleCollider>();
        enemy.agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ok)
        {
            meleerange.enabled = true;
            if (tArea.entry)
            {
                anime.SetBool("Active", true);
                ai.isStopped = false;
                ai.SetDestination(target.transform.position);
            }
            else
            {
                ai.isStopped = true;
            }
            if (atk >= 0) { atk -= Time.deltaTime; } else { if (atk < 0) { atk = 0; } }
        }
        else
        {
            ai.isStopped = true;
            ai.ResetPath();
            meleerange.enabled = false;
            hitbox.enabled = false;
            anime.Play("zombie_defeat");
            Invoke("Die", 2.15f);
        }
        
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anime.SetBool("Attack", true);
            StartCoroutine("Impact");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            myHP -= 1;
            if( myHP < 0)
            {
                ok = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anime.SetBool("Attack", true);
            StartCoroutine("Impact");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anime.SetBool("Attack", false);
        }
        
    }

    IEnumerator Impact()
    {
        yield return new WaitForSeconds(0.5f);
        if (atk == 0)
        {
            atk = cdn; //Reset Attack Cooldown Timer
            player.tempHP -= 5;
        }
        
    }
}
