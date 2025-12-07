using Meta.XR.MRUtilityKit;
using UnityEngine;
using System.Collections;

public class RoomAutoTagger : MonoBehaviour
{
    private string eTag = "Environment";

    void Start()
    {
        if (MRUK.Instance != null)
        {
            MRUK.Instance.RegisterSceneLoadedCallback(OnSceneLoaded);
        }
    }

    void OnSceneLoaded()
    {
        StartCoroutine(TagEverythingRoutine());
    }

    IEnumerator TagEverythingRoutine()
    {
        yield return null;
        yield return null;

        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        if (room == null) yield break;


        foreach (var anchor in room.Anchors)
        {
            if (anchor.gameObject == null) continue;

            anchor.gameObject.tag = eTag;

            SetTagRecursively(anchor.transform, eTag);
        }
    }

    void SetTagRecursively(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            child.gameObject.tag = tag;

            if (child.childCount > 0)
            {
                SetTagRecursively(child, tag);
            }
        }
    }
}