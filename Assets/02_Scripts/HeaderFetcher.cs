using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class HeaderFetcher : MonoBehaviour
{
    [SerializeField] private Text userNickName;
    [SerializeField] private Text userCoin;
    [SerializeField] private Text partnerName;
    [SerializeField] private Slider exp;
    [SerializeField] private Slider likeRate;
    [SerializeField] private Text level;
    // Start is called before the first frame update
    async void Start()
    {
        // todo: 並列で通信するためにAPI処理は一か所にまとめる
        string resJson = await ApiConnector.Get("/user/");
        User user = JsonUtility.FromJson<User>(resJson);
        SetUserInfo(user.nickname, 
            user.coin, 
            user.partner.girl.name, 
            user.partner.exp, 
            user.partner.require_exp, 
            user.partner.like_rate,
            user.partner.level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetUserInfo(string nickname, int coin, string partnerName, int exp, int requireExp, int likeRate, int level)
    {
        userNickName.text = nickname;
        userCoin.text = coin.ToString();
        this.partnerName.text = partnerName;
        this.exp.value = NormalizeValue4Slider(exp, requireExp);
        this.likeRate.value = NormalizeValue4Slider(likeRate, 100);
        this.level.text = $"Lv.{ level }";
    }

    private float NormalizeValue4Slider(int curValue, int maxValue)
    {
        float tmp = (float)curValue / (float)maxValue * 100f;

        return tmp;
    }
}
