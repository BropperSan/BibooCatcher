using UnityEngine;

public class HeadFollower : MonoBehaviour
{
    public Transform head;

    public Vector3 startOffset = new Vector3(-0.4f, -0.2f, 0.0f);

    private Vector3 _fixedWorldOffset;
    private Quaternion _initialRotation;

    void Start()
    {
        if (head == null) head = Camera.main.transform;

        Vector3 flatForward = head.forward;
        flatForward.y = 0;
        flatForward.Normalize();

        Quaternion startOrientation = Quaternion.LookRotation(flatForward);

        _fixedWorldOffset = startOrientation * startOffset;

        _initialRotation = transform.rotation;

        transform.position = head.position + _fixedWorldOffset;
    }

    void LateUpdate()
    {
        if (head == null) return;

        transform.position = head.position + _fixedWorldOffset;

        transform.rotation = _initialRotation;
    }
}

