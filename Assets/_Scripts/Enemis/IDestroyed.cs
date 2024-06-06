using Gameplay;
using Gameplay.Projectaile;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IDestroyed
{
    void GetDamage(MainAirplaneProjectaile projectaile);

    void ThrowStats();

    void DestroyEnemis();
    void DestroyWitoutStats();
}
