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

    public event UnityAction<int> OnTotalCountChanged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isCounting)
            {
                _isCounting = true;
                _countingCoroutine = StartCoroutine(CountCorutine());
            }
            else
            {
                _isCounting = false;
                StopCoroutine(_countingCoroutine);
            }
        }
    }

    private IEnumerator CountCorutine()
    {
        while (_isCounting)
        {
            yield return new WaitForSeconds(0.5f);
            _totalCount++;
            OnTotalCountChanged?.Invoke(_totalCount);
        }
    }
}
