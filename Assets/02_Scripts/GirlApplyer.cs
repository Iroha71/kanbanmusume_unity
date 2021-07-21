using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlApplyer : MonoBehaviour
{
    [Header("�p�[�g�i�[�̃��[�h�����邩")]
    [SerializeField] private bool isNeedPartner = false;
    // Start is called before the first frame update
    void Start()
    {
        ApiConnector apiConnector = GameObject.FindGameObjectWithTag("Manager").GetComponent<ApiConnector>();
        apiConnector.OnLoadedUser.AddListener(LoadPartnerModel);
    }

    private void LoadPartnerModel(User user)
    {
        if (!isNeedPartner)
            return;

        List<string> partnerCode = new List<string>();
        partnerCode.Add(user.partner.girl.code);
        ApplyGirl(partnerCode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ApplyGirl(List<string> girlCodes)
    {
        // �Q�[���I�u�W�F�N�g�ł͂Ȃ��X�N���v�g���琶������
        foreach (string girlcode in girlCodes)
        {
            GameObject girl = Resources.Load<GameObject>(girlcode);
            GameObject _girl = Instantiate(girl);
            _girl.transform.position = Vector3.zero;
        }
    }
}
