using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackButton : MonoBehaviour
{
    public FormScript m_FormScript;
    public Button m_Button;
   
    
    // Start is called before the first frame update
    void Start()
    {
        m_FormScript = FormScript.GetInstance();
        m_Button = this.gameObject.GetComponent<Button>();
  
    }

    // Update is called once per frame
    void Update()
    {
        m_Button.onClick.AddListener(BackFun);
    }

    void BackFun()
    {
        if (m_FormScript.m_DataView.activeSelf == true)
        {
            Debug.Log(m_FormScript.m_DataView.activeSelf);
            m_FormScript.m_DataView.SetActive(false);
            m_FormScript.m_MainMenuForm.SetActive(true);
        }
        if (m_FormScript.m_DataForm.activeSelf == true)
        {
            Debug.Log(m_FormScript.m_DataForm.activeSelf);
            m_FormScript.m_DataForm.SetActive(false);
            m_FormScript.m_DataView.SetActive(true); 
        }
    }
}
