using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class HeaderFetcher : MonoBehaviour
{
    [SerializeField] private Text userNickName;
    [SerializeField] private Text userCoin;
    // Start is called before the first frame update
    async void Start()
    {
        // todo: 並列で通信するためにAPI処理は一か所にまとめる
        string resJson = await ApiConnector.Get("/user/");
        User user = JsonUtility.FromJson<User>(resJson);
        SetUserInfo(user.nickname, user.partner.girl.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetUserInfo(string nickname, string partnerName)
    {
        userNickName.text = nickname;
        userCoin.text = partnerName;
    }
}
