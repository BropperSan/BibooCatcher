using Meta.WitAi;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _score;
    private int _currCombo;
    private int _maxCombo;
    private Queue<GameObject> _moaiQueue = new Queue<GameObject>();
    [SerializeField] private GameObject _canvas;
    [SerializeField] private TMP_Text _sc;
    [SerializeField] private TMP_Text _mc;

    private void OnEnable()
    {
        _canvas.SetActive(false);
        _score = 0;
        _currCombo = 0;
        _maxCombo = 0;
        GrabReleaseLogic.OnGoodThrow += AddScore;
        GrabReleaseLogic.OnBadThrow += StopCombo;
        GameTimer.OnTimerEnd += ShowScore;
    }

    private void OnDisable()
    {
        GameObject basket = GameObject.FindGameObjectWithTag("MainBasket");
        if (basket != null)
        {
            basket.DestroySafely();
        }
        _moaiQueue.Clear();
        GrabReleaseLogic.OnGoodThrow -= AddScore;
        GrabReleaseLogic.OnBadThrow -= StopCombo;
        GameTimer.OnTimerEnd -= ShowScore;
    }

    private void AddScore(GameObject moai)
    {
        _moaiQueue.Enqueue(moai);
        _score++;
        _currCombo++;
    }
    private void StopCombo(GameObject moai)
    {
        if (_currCombo > _maxCombo)
        {
            _maxCombo = _currCombo;
            _currCombo = 0;
        }
    }

    private void ShowScore()
    {
        foreach(GameObject moai in _moaiQueue)
        {
            moai.DestroySafely();
        }
        _canvas.SetActive(true);
        _sc.text = "Score: " + _score.ToString();
        _mc.text = "Max Combo: " + _maxCombo.ToString();
    }
}
