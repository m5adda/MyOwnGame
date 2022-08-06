using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health = 100 ;
    private int MAX_HEALTH = 100;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Damage(10);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
    }

    public void SetHealth(int maxHealth , int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
     }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("impossible to put negative damage.That's called Healing");
        }
        this.health -= amount;
        StartCoroutine(VisualIndicator(Color.red));

        if(health <= 0)
        {
            Die();
        }
    }
    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("impossible to put negative Healing.You're killing yourself");
        }

        bool wouldbeovermaxhealth = health + amount > MAX_HEALTH;

        StartCoroutine(VisualIndicator(Color.green));

        if (wouldbeovermaxhealth)
        {
            this.health = MAX_HEALTH ;
        }
        else
        {
            this.health += amount;
        }   
    }
    private void Die()
    {
        Debug.Log("You died");
        Destroy(gameObject);
    }
}
