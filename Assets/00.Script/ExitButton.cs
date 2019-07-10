using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExitButton : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Button>().onClick.AddListener(ExitProgram);
    }
  
    void ExitProgram()
    {
        Application.Quit();
    }
}
