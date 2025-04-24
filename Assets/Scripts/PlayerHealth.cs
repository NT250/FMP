using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    public HeartUI heartUI;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        heartUI.SetMaxHearts(maxHealth);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyMelee enemy = collision.GetComponent<EnemyMelee>();
        Bullet bullet = collision.GetComponent<Bullet>();
        if (enemy)
        {
            TakeDamage(enemy.damage);
        }
        if (bullet)
        {
            TakeDamage(bullet.damage);
        }
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        heartUI.UpdateHearts(currentHealth);

        if(currentHealth <= 0)
        {

        }
    }
}
