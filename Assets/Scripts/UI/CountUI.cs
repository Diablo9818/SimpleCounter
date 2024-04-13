using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountUI : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        _text.text = "Counter: 0";
    }

    private void OnEnable()
    {
        _counter.OnTotalCountChanged += UpdateCounterText;
    }

    private void OnDisable()
    {
        _counter.OnTotalCountChanged += UpdateCounterText;
    }

    void UpdateCounterText(int count)
    {
        _text.text = "Counter: " + count.ToString();
    }
}
