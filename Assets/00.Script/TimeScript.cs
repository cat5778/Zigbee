using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.UI;
using System;
public class TimeScript : MonoBehaviour
{

    public Text DateText;
   

    // Update is called once per frame
    void Update()
    {
        DateText.text="현재시간 :"+DateTime.Now.ToString("HH.mm.ss");
    }


}
