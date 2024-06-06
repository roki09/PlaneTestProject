using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAirplane : MonoBehaviour
{
    [SerializeField] private GameObject[] born;
    [SerializeField] private int Health;
    private ArchTester tester;

    private void OnEnable()
    {
        tester = FindAnyObjectByType<ArchTester>();
    }
    public int health
    {
        get
        {
            return Health;
        }
        private set
        {
            Health = value;
            SwitchHpState();
            
        }
    }

    public void TakingDamage(int damage)
    {
        this.health -= damage;
    }

    private void SwitchHpState()
    {
        Debug.Log("HP was switsched");
        if (this.Health == 3)
        {
            foreach (var item in born)
            {
                item.gameObject.SetActive(false);
            }
        }
        else if (this.Health == 2)
        {
            born[0].gameObject.SetActive(true);
        }
        else if (this.Health == 1)
        {
            born[1].gameObject.SetActive(true);
        }
        else if(this.Health == 0)
        {
            tester.EndGame();
            Destroy(this.gameObject);
        }
    }
}
