using UnityEngine;

public class GrabReleaseLogic : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OnGrab()
    {
        Vector3 currentWorldScale = transform.lossyScale;
        transform.SetParent(null, true);
        transform.localScale = currentWorldScale;

        if (_rb != null)
        {
            _rb.isKinematic = false;
            _rb.useGravity = true;
        }
    }

    public void OnRelease()
    {
        if (_rb != null)
        {
            _rb.isKinematic = false;
            _rb.useGravity = true;
        }
    }
}