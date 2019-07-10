using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddItem : MonoBehaviour {

    public GameObject m_Item;
    public GameObject m_Content;
    public Vector3 m_Pos;
	// Use this for initialization
	void Start () {
       
        Vector3 Pos=new Vector3(-210, 30, 0);//-367   143     157     -113             
        for(int i=1; i < 23; i++)
        {
            m_Content=Instantiate(m_Item,Pos,Quaternion.identity);
            m_Content.transform.SetParent(this.transform);
            m_Content.GetComponentInChildren<Text>().text="Main_0"+i.ToString();
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
