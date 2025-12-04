using System;
using UnityEngine;

public class BasketLogic : MonoBehaviour
{
    public static event Action OnGoodThrow;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Moai")
        {
            OnGoodThrow?.Invoke();
            other.gameObject.transform.localScale *= 0.5f;
        }
    }
}
