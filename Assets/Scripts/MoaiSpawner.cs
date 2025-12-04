using Unity.XR.CoreUtils;
using UnityEngine;

public class MoaiSpawner : MonoBehaviour
{
    GameObject moai;
    private void Awake()
    {
        moai = Resources.Load<GameObject>("Moai/Moai");
    }

    private void OnEnable()
    {
        BasketLogic.OnGoodThrow += SpawnMoai;
    }

    private void OnDisable()
    {
        BasketLogic.OnGoodThrow -= SpawnMoai;
    }


    void Start()
    {
        SpawnMoai();
    }

    public void SpawnMoai()
    {
        Debug.Log("MOAI SPAWN");
        GameObject _currMoai = Instantiate(moai, Vector3.zero, new Quaternion(0, 0, 0, 0), gameObject.transform);
        _currMoai.transform.localPosition = new Vector3(0, -0.099f, 0.208f);
    }
}
