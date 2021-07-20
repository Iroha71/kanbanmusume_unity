using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;

public class ApiConnectTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Test();

    }

    async void Test()
    {
        string girls = await GetTask();
        string convert = JsonHelper.FromJson(rootName: "girls", girls);
    }

    private async UniTask<string> GetTask()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://127.0.0.1:5500/girl/");
        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
            return request.error;
        }
        return request.downloadHandler.text;
    }
}
