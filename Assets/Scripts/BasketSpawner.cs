using Meta.XR.MRUtilityKit;
using UnityEngine;

public class BasketSpawner : MonoBehaviour
{
    private MRUKRoom _currentRoom;
    GameObject basket;
    float basketRadius;
    LabelFilter filter = new LabelFilter(MRUKAnchor.SceneLabels.FLOOR);

    private void Awake()
    {
        basket = Resources.Load<GameObject>("Basket/Basket");
        basketRadius = basket.GetComponentInChildren<SphereCollider>().radius;
    }

    void Start()
    {
        if (MRUK.Instance != null)
        {
            MRUK.Instance.RegisterSceneLoadedCallback(OnSceneLoaded);
        }
    }
    void OnSceneLoaded()
    {
        _currentRoom = MRUK.Instance.GetCurrentRoom();
        if (_currentRoom == null)
        {
            Debug.LogError("Комната не найдена!");
            return;
        }

        if (_currentRoom.FloorAnchor == null)
        {
            Debug.LogError("В комнате не определён ПОЛ! Пересканируй помещение.");
            return;
        }
        SpawnBasket();
    }

    void SpawnBasket()
    {
        Transform head = Camera.main.transform;
        Vector3 forwardDirection = head.forward;
        forwardDirection.y = 0;
        forwardDirection.Normalize();
        Vector3 targetPos = head.position + (forwardDirection * 1f);

        Vector3 finalPosition;
        MRUKAnchor floorAnchor;
        float distance = _currentRoom.TryGetClosestSurfacePosition(targetPos, out finalPosition, out floorAnchor, filter);
        if (floorAnchor != null)
        {
            Instantiate(basket, finalPosition + new Vector3(0, 0.31f, 0), Quaternion.LookRotation(forwardDirection));
        }
    }
}
