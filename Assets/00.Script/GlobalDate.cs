using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GlobalDate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Text>().text=DateTime.Now.ToString("yyyy-MM-dd");

    }
}

