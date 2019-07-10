using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
public class DropDownScript : MonoBehaviour
{
    public Dropdown dropdown;
    public List<string> names;
    // Start is called before the first frame update
    void Start()
    {
        names = new List<string>();
        PopulateList();
    }

    void PopulateList()
    {
        // Get a list of serial port names.
        string[] ports = SerialPort.GetPortNames();
        Debug.Log("portlength"+ports.Length);
        // Display each port name to the console.
        for (int i = 0; ports.Length > i; i++)
        {
            names.Add(ports[i]);
        }
        
        //TODO: Read there values from tyhe web site do
        dropdown.AddOptions(names);
    }
}
