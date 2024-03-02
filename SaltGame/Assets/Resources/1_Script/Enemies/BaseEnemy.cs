using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool floating;
    [SerializeField] Rigidbody rb;
    Vector3 playerPosition;


    public void MoveFoward()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime * 35;

        if (floating)
        {
            transform.Translate(transform.up / 100 * Mathf.Sin(Time.time * speed * 2));
        }
    }

    public abstract void SpecialMove();

    public abstract void OnDie();

    public void Die()
    {
        OnDie();
        Destroy(this.gameObject);
    }

    public float DistanceFromPlayer()
    {
        return Vector3.Distance(transform.position, playerPosition);
    }
}
