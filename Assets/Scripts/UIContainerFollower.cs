using UnityEngine;

public class UIContainerFollower : MonoBehaviour
{
    public Transform head;

    [Header("Настройки позиции")]
    public float distance = 1.2f;
    public float heightOffset = -0.15f;
    public float smoothTime = 0.3f;

    [Header("Настройки поворота")]
    public bool lockXRotation = true;
    public bool flipRotation = false;

    private Vector3 _velocity;

    void Start()
    {
        if (head == null) head = Camera.main.transform;
    }

    void LateUpdate()
    {
        if (head == null) return;

        Vector3 targetDirection = head.forward;
        targetDirection.y = 0;
        targetDirection.Normalize();

        if (targetDirection == Vector3.zero) targetDirection = head.parent.forward;

        Vector3 targetPos = head.position + (targetDirection * distance);

        targetPos.y = head.position.y + heightOffset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, smoothTime);

        Vector3 directionToLook = transform.position - head.position;

        if (flipRotation) directionToLook = -directionToLook;

        if (lockXRotation) directionToLook.y = 0;

        if (directionToLook != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(directionToLook);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 5f);
        }
    }
}