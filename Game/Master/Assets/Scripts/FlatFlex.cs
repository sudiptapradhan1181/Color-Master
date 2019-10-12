using UnityEngine;
using System.Collections;
//using System.IO.Ports;
using System;
//using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class FlatFlex : MonoBehaviour
{
    public static string IP = "10.0.62.29:8001";
    public Stream ReceiveStream;
    public StreamReader reader;
    public HttpWebResponse result;
    public String sAddress;
    public HttpWebRequest req;

    public void Flat()
    {
        Jump.messTrans = "A";
    }

    public void Flex()
    {
        Jump.messTrans = "B";
    }



}
