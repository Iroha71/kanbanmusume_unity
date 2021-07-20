using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHelper : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string FromJson(string rootName, string listJson)
    {
        string convertedJson = "{ " + "\"" + rootName + "\":" + listJson + "}"; 

        return convertedJson;
    }
}
