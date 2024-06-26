using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage;

    private Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if(!target) return;
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if(other.collider.CompareTag("Enemy"))
        {
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);
        Destroy(gameObject);
        }

        if(other.collider.CompareTag("LevelCollider"))
        {
            Destroy(gameObject);
        }
    }
}
