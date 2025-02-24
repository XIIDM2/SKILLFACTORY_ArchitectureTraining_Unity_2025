using CodeBase.GamePlay.Enemies;
using CodeBase.GamePlay.Hero;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDeath : MonoBehaviour
{
    private HeroHealth health;
    void Start()
    {
        health = GetComponent<HeroHealth>();

        health.Death += OnDeathEvent;
    }

    private void OnDestroy()
    {
        health.Death -= OnDeathEvent;
    }

    private void OnDeathEvent()
    {
        Destroy(gameObject);
    }
}
