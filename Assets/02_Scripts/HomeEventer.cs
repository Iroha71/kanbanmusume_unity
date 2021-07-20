using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public class HomeEventer : MonoBehaviour
{
    [SerializeField] TextSetter girlNameText;
    [SerializeField] private Image mainCanvas;
    // Start is called before the first frame update
    async void Start()
    {
        Transform mainCanvasTransform = mainCanvas.transform;
        string girlsJson = await ApiConnector.Get("/girl");
        girlsJson = JsonHelper.FromJson(rootName: "girls", girlsJson);
        GirlList girls = JsonUtility.FromJson<GirlList>(girlsJson);
        foreach (Girl girl in girls.girls)
        {
            var text = Instantiate(this.girlNameText, mainCanvasTransform);
            text.SetText(girl.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
