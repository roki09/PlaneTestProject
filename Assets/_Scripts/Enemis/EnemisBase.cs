using Architecture;
using Gameplay.Projectaile;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class EnemisBase : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int bounty;
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject deathAnimationObject;

    [SerializeField] protected EnemyStats enemyStats;

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void DestroyEnemis()
    {
        ThrowStats();
        gameObject.SetActive(false);
    }

    public void DestroyWitoutStats()
    {
        Destroy(this.gameObject);
    }

    public void GetDamage(MainAirplaneProjectaile projectaile)
    {
        this.health -= projectaile.GetDamageScore();
        projectaile.gameObject.SetActive(false);
        Debug.Log("Damage was taken");

        if (this.health <= 0)
        {
            deathAnimationObject.SetActive(true);
            StartCoroutine(DeadTimer());
        }
    }

    public void ThrowStats()
    {
        Stats.AddCoins(this, bounty);
        Stats.AddEnemyStats(this, enemyStats);
        Debug.Log("Stats was throwing");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Edge"))
        {
            DestroyWitoutStats();
            return;
        }
        else if (collision.TryGetComponent(out MainAirplane mainAirplane))
        {
            mainAirplane.TakingDamage(1);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator DeadTimer()
    {
        yield return new WaitForSeconds(1);
        DestroyEnemis();
    }
}
