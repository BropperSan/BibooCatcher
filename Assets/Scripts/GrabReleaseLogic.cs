using Oculus.Interaction;
using UnityEngine;
using System;

public class GrabReleaseLogic : MonoBehaviour
{
    private Rigidbody _rb;
    public float delay = 1.0f;

    private bool _isDying = false;
    private bool _isHeld = false;

    public static event Action<GameObject> OnGoodThrow;
    public static event Action<GameObject> OnBadThrow;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    public void OnGrab()
    {
        _isHeld = true;
        _isDying = false;

        gameObject.tag = "Moai";


        Vector3 currentWorldScale = transform.lossyScale;
        transform.SetParent(null, true);
        transform.localScale = currentWorldScale;

        if (_rb != null)
        {
            _rb.isKinematic = true;
            _rb.useGravity = false;
        }
    }

    // Вызывается при отпускании
    public void OnRelease()
    {
        _isHeld = false;

        if (_rb != null)
        {
            _rb.isKinematic = false;
            _rb.useGravity = true;

            _rb.WakeUp();
        }

        if (gameObject.TryGetComponent(out Grabbable grabbable))
        {
            grabbable.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isDying) return;


        if (_isHeld) return;

        if (collision.gameObject.CompareTag("Hand") || collision.gameObject.CompareTag("Basket"))
        {
            return;
        }

        if (collision.gameObject.CompareTag("Environment"))
        {
            _isDying = true;
            Destroy(gameObject, delay);
            OnBadThrow?.Invoke(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            gameObject.tag = "MoaiInBasket";
            OnGoodThrow?.Invoke(gameObject);
            gameObject.transform.localScale *= 0.5f;
            _isDying = true;
        }
    }
}