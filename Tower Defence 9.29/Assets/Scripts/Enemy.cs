﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10;
    public float hp = 150;//enemy damage
    private float totalHp;
    private Slider hpSlider;
    private Transform[] positions;
    private int index = 0;

    void Start()
    {
        totalHp = hp;
        positions = Waypoints.positions;
        hpSlider = GetComponentInChildren<Slider>();
    }

    void Update()
    {
        Move();
    }


    void Move()
    {
        if (index > positions.Length - 1) return;
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(positions[index].position, transform.position) < 0.8f)
        {
            index++;
        }
        if(index>positions.Length-1)
        {
            ReachDestination();
        }
    }

    void ReachDestination()//Link with improve founction 01(EnemySpawner) - When Enemy arrive at end point
    {
        GameObject.Destroy(this.gameObject);
    }

    void OnDestroy()//Link with improve founction 01(EnemySpawner) - When Enemy been destory
    {
        EnemySpawner.CountEnemyAlive--;
    }

    public void TakeDamage(float damage)//This is take damage, just “int damage” in the bullet script
    {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = (float)hp / totalHp;
        if (hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject.Destroy(this.gameObject);
    }
}
