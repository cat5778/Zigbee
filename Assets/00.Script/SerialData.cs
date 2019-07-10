using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.IO;


public class SerialData : MonoBehaviour
{
    //Variable
    #region
    public SerialPort stream;
    private Thread ReadThread;
    public string m_port;
    public Text m_Temperature;
    public Text m_Humidity;
    public Text m_Co2;
    public Text m_Water;
    public Text m_X;
    public Text m_Y;
    public Text m_Z;
    public Text m_Vibration;
    public bool IsData1;
    public bool Isdata2;
    public GameObject dataListPrefab;
    public GameObject m_DataListPrefab;
    public FormScript m_FormScript;
    public Text m_SerialText;
    System.Text.Encoding myEncoding;
    public FormScript m_FromScript;
    //
    public StreamWriter _TextFile;
    public FileStream fs;
    public FileInfo exp_Text;
    public string path;
    #endregion


    void Start()
    {
        path = Application.dataPath + "/SensorData.txt";
        if (!File.Exists(path))
        {
            File.CreateText(path);
            Debug.Log(path);
            // Create a file to write to
        }
   
        m_FormScript = FormScript.GetInstance();
        // Get a list of serial port names.
        string[] ports = SerialPort.GetPortNames();
        m_SerialText = GameObject.Find("SerialPortText").GetComponent<Text>();
        // Display each port name to the console.
        foreach (string port in ports)
        {
            Debug.Log(port);
            m_port = port;
        }
        Debug.Log("se" + m_port);
        m_FormScript.IsConnect = false;




    }

    string tmp = null;
    void Update()
    {
        try
        {
            //if (stream.IsOpen)
            //{
            //    tmp = stream.ReadLine();
            //    stream.ReadTimeout = 1000;
            //    myEncoding = System.Text.Encoding.GetEncoding("utf-8");
            //    byte[] buf = myEncoding.GetBytes(tmp);

            //    //Debug.Log(tmp);


            //    String[] result = tmp.Split(new string[] { "$1T", "H", "C", "W", "$2G", "V", "*" }, StringSplitOptions.RemoveEmptyEntries);
            //    for (int i = 0; i < result.Length; i++)
            //        Debug.Log(result[i]);
            //}
            if (m_FormScript.IsLogin == true && m_FormScript.IsConnect == false)
            {
                stream = new SerialPort(m_SerialText.text, 38400);
                stream.Open();
                m_FormScript.IsConnect = true;
            }
            if (m_FormScript.IsLogin == false && m_FormScript.m_LoginForm.activeSelf == false)
            {
                stream.Close();
            }
            if (m_FormScript.m_LoginForm.activeSelf == false && stream.IsOpen)
            {
                tmp = stream.ReadLine();
                stream.ReadTimeout = 10;
                myEncoding = System.Text.Encoding.GetEncoding("utf-8");
                byte[] buf = myEncoding.GetBytes(tmp);
                //Debug.Log(tmp);
                if (tmp.Substring(1, 1) == "1")
                {
                    IsData1 = true;
                    m_Temperature.text = tmp.Substring(3, 5);
                    m_Humidity.text = tmp.Substring(9, 4);
                    m_Co2.text = tmp.Substring(14, 4);
                    m_Water.text = tmp.Substring(16, 1);
                }
                if (tmp.Substring(1, 1) == "2")
                {
                    Isdata2 = true;
                    m_X.text = tmp.Substring(3, 4);
                    m_Y.text = tmp.Substring(7, 4);
                    m_Z.text = tmp.Substring(11, 4);
                    m_Vibration.text = tmp.Substring(16, 1);
                }
                Debug.Log("ID=" + tmp.Substring(1, 1));
                Debug.Log("온도=" + tmp.Substring(3, 5));
                Debug.Log("습도=" + tmp.Substring(9, 4));
                Debug.Log("Co2=" + tmp.Substring(14, 4));
                Debug.Log("수위=" + tmp.Substring(16, 1));
                Debug.Log("ID" + tmp.Substring(1, 1));
                Debug.Log("X=" + tmp.Substring(3, 4));
                Debug.Log("Y=" + tmp.Substring(7, 4));
                Debug.Log("Z=" + tmp.Substring(11, 4));
                Debug.Log("진동=" + tmp.Substring(16, 1));

                //String[] result = tmp.Split(new string[] { "$1T", "H", "C", "W", "$2G", "V", "*" }, StringSplitOptions.RemoveEmptyEntries);
                //for (int i = 0; i < result.Length; i++)
                //    Debug.Log(result[i]);
                //Data Check Append to DataForm;
                if (m_FormScript.m_DataForm.activeSelf == true)
                {
                    if (IsData1 == true && Isdata2 == true)
                    {
                        m_DataListPrefab = Instantiate(dataListPrefab, new Vector3(702, 317, 0), Quaternion.identity);
                        m_DataListPrefab.transform.parent = GameObject.Find("DataList").transform;
                        m_DataListPrefab.transform.GetChild(0).GetComponent<Text>().text = DateTime.Now.ToString("MM-dd");//날짜
                        m_DataListPrefab.transform.GetChild(1).GetComponent<Text>().text = m_Temperature.text;
                        m_DataListPrefab.transform.GetChild(2).GetComponent<Text>().text = m_Humidity.text;
                        m_DataListPrefab.transform.GetChild(3).GetComponent<Text>().text = m_Co2.text;
                        m_DataListPrefab.transform.GetChild(4).GetComponent<Text>().text = m_Water.text;
                        m_DataListPrefab.transform.GetChild(5).GetComponent<Text>().text = m_X.text;
                        m_DataListPrefab.transform.GetChild(6).GetComponent<Text>().text = m_Y.text;
                        m_DataListPrefab.transform.GetChild(7).GetComponent<Text>().text = m_Z.text;
                        m_DataListPrefab.transform.GetChild(8).GetComponent<Text>().text = m_Vibration.text;
                        //Input Sensor  data
                        string appendText ="시간=" + DateTime.Now+  "/온도=" + tmp.Substring(3, 5) + "/습도=" + tmp.Substring(9, 4) + "/Co2=" + tmp.Substring(14, 4) +
                            "수위=" + tmp.Substring(16, 1) + "/X=" + tmp.Substring(3, 4) + "/Y=" + tmp.Substring(7, 4) + "/Z=" + tmp.Substring(11, 4) + "/진동=" + tmp.Substring(16, 1) + Environment.NewLine;
                        File.AppendAllText(path, appendText);

                        IsData1 = false;
                        Isdata2 = false;
                    }


                }
            }


        
            }
            catch (TimeoutException e)
            {
                //Debug.Log(e);
            }
    }

    void OnApplicationQuit()
    {
        stream.Close();

    }

}



