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
    void Start()
    {
        ApiConnector manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ApiConnector>();
        manager.OnLoadedUser.AddListener(SetUserInfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetUserInfo(User user)
    {
        userNickName.text = user.nickname;
        userCoin.text = user.coin.ToString();
        this.partnerName.text = user.partner.girl.name;
        this.exp.value = NormalizeValue4Slider(user.partner.exp, user.partner.require_exp);
        this.likeRate.value = NormalizeValue4Slider(user.partner.like_rate, 100);
        this.level.text = $"Lv.{ level }";
    }

    private float NormalizeValue4Slider(int curValue, int maxValue)
    {
        float tmp = (float)curValue / (float)maxValue * 100f;

        return tmp;
    }
}
