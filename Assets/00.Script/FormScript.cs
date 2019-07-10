using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FormScript : MonoBehaviour {
    private static FormScript instance;
    public InputField m_ID;
    public InputField m_PW;
    private Button m_Botton;
    public GameObject m_LoginForm;
    public GameObject m_MainMenuForm;
    public GameObject m_DataForm;
    public GameObject m_ListItem;
    public GameObject m_DataView;
    public GameObject m_BackGroundDeco;
    public bool IsLogin;
    public bool IsConnect;
    // Use this for initialization

    public static FormScript GetInstance()
    {
        if (!instance)
        {
            instance = GameObject.FindObjectOfType(typeof(FormScript)) as FormScript;
            if (!instance)
                Debug.LogError("There needs to be one active MyClass script on a GameObject in your scene.");
        }

        return instance;
    }

 
    private void Start()
    {
        IsLogin = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (m_LoginForm.activeSelf == true)
        {
            m_ID = GameObject.Find("IdField").GetComponent<InputField>();
            m_PW = GameObject.Find("PwField").GetComponent<InputField>();
            m_LoginForm = GameObject.Find("LoginForm");
        }
    }
   
    public void CheckLogin()
    {
        if (m_ID.text == "admin" && m_PW.text=="admin")
        {
            ChangeForm();
            IsLogin = true;
        }
    }
    public void ChangeForm()
    {
        m_LoginForm.SetActive(false);
        m_MainMenuForm.SetActive(true);
        m_ListItem.SetActive(true);
        m_BackGroundDeco.SetActive(true);
    }
    public void LogOut()
    {
        m_LoginForm.SetActive(true);
        m_ID.text = "";
        m_PW.text = "";
        m_MainMenuForm.SetActive(false);
        m_DataForm.SetActive(false);
       
        m_ListItem.SetActive(false);
        m_DataView.SetActive(false);
        //m_BackGroundDeco.SetActive(false);
        IsLogin = false;
        IsConnect = true;
    }
    
}
