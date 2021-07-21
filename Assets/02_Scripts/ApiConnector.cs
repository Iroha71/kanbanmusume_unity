using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;
using UnityEngine.Events;
public class ApiConnector : MonoBehaviour
{
    public UnityEvent<User> OnLoadedUser = new UnityEvent<User>();
    private const string BASE_URL = "http://127.0.0.1:5500";
    private static string userAuthToken = "";
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(SendRequest), 0.1f);
    }

    private async void SendRequest()
    {
        string resJson = await Get("/user/");
        print(resJson);
        User user = JsonUtility.FromJson<User>(resJson);
        OnLoadedUser.Invoke(user);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string ReadAuthToken()
    {
        if (userAuthToken.Equals(""))
        {
            string json = Resources.Load<TextAsset>("save").ToString();
            SaveData savedata = JsonUtility.FromJson<SaveData>(json);
            userAuthToken = savedata.token;
        }

        return userAuthToken;
    }
    public async UniTask<string> Get(string endpoint)
    {
        UnityWebRequest request = UnityWebRequest.Get(BASE_URL + endpoint);
        print(BASE_URL + endpoint);
        request.SetRequestHeader("Authorization", $"Bearer { ReadAuthToken() }");
        await request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            print(request.error);
            return request.error;
        }

        return request.downloadHandler.text;
    }
}
