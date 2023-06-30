using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GemCollect : MonoBehaviour
{
    [SerializeField] private UnityEvent _isCollected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
        {
            _isCollected.Invoke();

            Destroy(this.gameObject);
        }
    }
}
