using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Test : MonoBehaviour
{
    async void Start()
    {
        await RunCoroutineAsync();
        Debug.Log("Корутина завершена, продолжаем async");
    }

    public async Task RunCoroutineAsync()
    {
        var tcs = new TaskCompletionSource<bool>();
        StartCoroutine(CoroutineWrapper(tcs));
        await tcs.Task;
    }

    private IEnumerator CoroutineWrapper(TaskCompletionSource<bool> tcs)
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
        tcs.SetResult(true);
    }

}
