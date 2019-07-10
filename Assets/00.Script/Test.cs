using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
public class Test : MonoBehaviour
{

    private void Start()
    {

        // Get a list of serial port names.
        string[] ports = SerialPort.GetPortNames();

        Console.WriteLine("The following serial ports were found:");

        // Display each port name to the console.
        foreach (string port in ports)
        {
            Debug.Log(port);
        }
    }
  


}
