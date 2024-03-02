using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int currencyValue;
    [SerializeField] bool floating;
    Transform playerTransform;

    public void SetPlayerPosition(Transform _playerTransform)
    {
        playerTransform = _playerTransform;
    }


    public void MoveFoward()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if (floating)
        {
            transform.Translate(transform.up / 100 * Mathf.Sin(Time.time * speed * 2));
        }
    }

    public abstract void SpecialMove();

    public abstract void OnDie();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerScrpt player))
        {
            this.Die();
            player.TakeAHit();
        }
    }

    public void KillEnemy()
    {
        Wallet.AddValue(currencyValue);
        Die();
    }

    public void Die()
    {
        OnDie();
        NumOfEnemiesAlive.Subtract();
        Destroy(this.gameObject);
    }

    public float DistanceFromPlayer()
    {
        return Vector3.Distance(transform.position, playerTransform.position);
    }
}
