using Meta.WitAi;
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
        GrabReleaseLogic.OnGoodThrow += SpawnMoai;
        GrabReleaseLogic.OnBadThrow += SpawnMoai;
        SpawnMoai(moai);
    }

    private void OnDisable()
    {
        GrabReleaseLogic.OnGoodThrow -= SpawnMoai;
        GrabReleaseLogic.OnBadThrow -= SpawnMoai;
    }

    public void SpawnMoai(GameObject i)
    {
        if (GameObject.FindGameObjectWithTag("MoaiOnSpawn") == null)
        {
            GameObject _currMoai = Instantiate(moai, Vector3.zero, new Quaternion(0, 0, 0, 0), gameObject.transform);
            _currMoai.transform.localPosition = new Vector3(0, -0.099f, 0.208f);
        }
    }

    public void DeleteMoai()
    {
        GameObject moaiOnSpawn = GameObject.FindGameObjectWithTag("MoaiOnSpawn");
        if (moaiOnSpawn != null)
        {
            moaiOnSpawn.DestroySafely();
        }
    }
}
