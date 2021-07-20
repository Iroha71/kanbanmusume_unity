using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;
public class ApiConnector : MonoBehaviour
{
    private const string BASE_URL = "http://127.0.0.1:5500";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static async UniTask<string> Get(string endpoint)
    {
        UnityWebRequest request = UnityWebRequest.Get(BASE_URL + endpoint);
        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            return request.error;
        }

        return request.downloadHandler.text;
    }
}
