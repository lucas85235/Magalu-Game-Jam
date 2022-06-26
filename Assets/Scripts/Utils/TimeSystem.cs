using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stopwatchText;

    [SerializeField] private float _initialTime = 20;
    [SerializeField] private float _extraTime = 5;

    [Space]
    [Header("Events")]
    public UnityEvent OnEndTime;
    public UnityEvent OnEndTotalTime;

    private float _countTime = 0;
    private float _countExtraTime = 0;
    private bool _endCount = false;
    private bool _endHappened = false;
    private bool _isStarted = false;

    public void Start()
    {
        _countTime = _initialTime;
        _countExtraTime = _extraTime;
        _isStarted = true;
    }

    private void Update()
    {
        if (!_isStarted) return;

        if (!_endCount && _countTime <= 0)
        {
            _endCount = true;
            stopwatchText.text = "0:00";
            OnEndTime.Invoke();
        }
        else if (!_endCount)
        {
            _countTime -= Time.deltaTime;
            stopwatchText.text = SecondsToMinutes(_countTime);
        }
        
        if (_endCount && !_endHappened)
        {
            if (_countExtraTime <= 0)
            {
                _isStarted = false;
                _endHappened = true;
                OnEndTotalTime.Invoke();

                Debug.Log("OnEndTime");
            }
            else _countExtraTime -= Time.deltaTime;
        }
    }

    private string SecondsToMinutes(float timer)
    {
        string minutes = Mathf.Floor(timer / 60).ToString("0");
        string seconds = (timer % 60).ToString("00");

        return string.Format("{0}:{1}", minutes, seconds);
    }
}
