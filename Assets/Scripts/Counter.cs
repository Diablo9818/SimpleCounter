using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private int _countPerTime;

    private int _totalCount = 0;
    private bool _isCounting;
    private Coroutine _countingCoroutine;
    private WaitForSeconds _countingWaitForSeconds = new WaitForSeconds(0.5f);

    public event UnityAction<int> TotalCountChanged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isCounting)
            {
                _isCounting = true;
                _countingCoroutine = StartCoroutine(Counting());
            }
            else
            {
                _isCounting = false;
                StopCoroutine(_countingCoroutine);
            }
        }
    }

    private IEnumerator Counting()
    {
        while (_isCounting)
        {
            yield return _countingWaitForSeconds;
            _totalCount++;
            TotalCountChanged?.Invoke(_totalCount);
        }
    }
}
