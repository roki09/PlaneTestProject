using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAirplane : MonoBehaviour
{
    public int health
    {
        get
        {
            return this.health;
        }
        private set
            => SwitchHpState();
    }

    [SerializeField] private GameObject[] born;

    public void TakingDamage(int damage)
    {
        this.health -= damage;
    }

    private void SwitchHpState()
    {
        if (this.health == 3)
        {
            foreach (var item in born)
            {
                item.gameObject.SetActive(false);
            }

        }
        if (this.health == 2)
        {
            born[0].gameObject.SetActive(true);
        }
        if (this.health == 1)
        {
            born[1].gameObject.SetActive(true);
        }
    }
}
