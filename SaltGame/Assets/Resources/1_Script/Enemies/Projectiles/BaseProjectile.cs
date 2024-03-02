using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    [SerializeField] float speed;

    public void MoveFoward()
    {
        transform.Translate(transform.forward * speed);
    }
}
