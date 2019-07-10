using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemScript : MonoBehaviour {
    public Text m_Text;
    public string buf;
    public Text m_ViewListText;
    public Button m_Button;
 
    public FormScript m_FormScript;
	// Use this for initialization

	void Start () {
        m_FormScript = FormScript.GetInstance();
        m_Text = this.transform.GetComponentInChildren<Text>();
        buf = m_Text.text;
        m_ViewListText = GameObject.Find("ListName").GetComponent<Text>();
        m_Button = this.gameObject.GetComponent<Button>();
        
    }
	
	// Update is called once per frame
    void Update () {
        m_Button.onClick.AddListener(SetItem);
    }
     void SetItem()
    {
        m_ViewListText.text= m_Text.text;
        m_FormScript.m_MainMenuForm.SetActive(false);
        m_FormScript.m_DataView.SetActive(true);
        

    }
    
}
