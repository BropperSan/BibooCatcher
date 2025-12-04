using UnityEngine;

public class MoaiSmall : MonoBehaviour
{
    private void OnEnable()
    {
        BasketLogic.OnGoodThrow += Small;
    }

    private void OnDisable()
    {
        BasketLogic.OnGoodThrow -= Small;
    }

    private void Small()
    {
        this.transform.localScale = transform.localScale * 0.5f;
    }
}
