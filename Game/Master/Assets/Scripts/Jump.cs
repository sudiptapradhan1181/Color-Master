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


public class Jump : MonoBehaviour
{

    public static int[] angles;
    public static string messRecv = "", messTrans = "";
    public static bool stpServer = false;

    public Thread mThread;
    public TcpListener server, server1;
    public TcpClient client, client1;
    public NetworkStream stream, stream1;



    // Start is called before the first frame update
    void Start()
    {

        angles = new int[10];
        for (int i = 0; i < 10; i++) angles[i] = 0;

        ThreadStart ts = new ThreadStart(Update1);
        mThread = new Thread(ts);
        mThread.Start();
        //TransformFunction.data[0] = 15;
        //data[0] = 10.0f;
        // Debug.Log(data[0]);
    }



    // Update is called once per frame
    void Update()
    {
        /*if (j == 0.0f)
        {
            
            if (i <= 5.0f)
            {
                transform.Rotate(0.0f, 0.0f, -1.0f);
                i += 0.1f;
                if (i == 5.1f)
                {
                    j = 1.0f;
                }
                 
            }
            
        }
        
        else if (j == 1.0f)
        {
            if (k <= 5.0f)
            {
                transform.Rotate(0.0f, 0.0f, 1.0f);
                k += 0.1f;
                if (k == 5.1f)
                {
                    j = 0.0f; 
                }

            }*/
    }

    void Update1()
    {

        server = null;
        try
        {
            // Set the TcpListener on port 13000.
            Int32 port = 3333;
            Int32 port1 = 4444;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // TcpListener server = new TcpListener(port);
            server = new TcpListener(IPAddress.Any, port);
            server1 = new TcpListener(IPAddress.Any, port1);
            // Start listening for client requests.
            server.Start();
            server1.Start();

            // Buffer for reading data
            Byte[] bytes = new Byte[256];
            String data = null;
            String tmpData = null;
            int S = 0, T = 0;
            // Enter the listening loop.
            while (true)
            {
                Thread.Sleep(10);

                Debug.Log("Waiting for a connection... ");
                //server.Start();
                //server1.Start();
                // Perform a blocking call to accept requests.
                // You could also user server.AcceptSocket() here.
                client = server.AcceptTcpClient();
                if (client != null)
                {

                    Debug.Log("Connected!");

                    //isConnection=true;
                    //client.Close();
                    //break;

                }

                client1 = server1.AcceptTcpClient();
                if (client1 != null)
                {

                    Debug.Log("Connected!");

                    //isConnection=true;
                    //client.Close();
                    //break;

                }
                data = null;

                // Get a stream object for reading and writing
                stream = client.GetStream();
                stream1 = client1.GetStream();
                StreamWriter swriter = new StreamWriter(stream);
                int i;
                //swriter.WriteLine("Hi");
                //
                //Debug.Log("Outside");
                //messTrans = "A";
                // Loop to receive all the data sent by the client.
                while (true)
                {
                    if (stpServer == true)
                    {
                        server.Stop();
                        server1.Stop();
                        break;
                    }
                    Debug.Log(messTrans.Length);
                    if (messTrans.Length > 0)
                    {
                        Debug.Log(messTrans);
                        byte[] dt = Encoding.ASCII.GetBytes(messTrans);
                        stream1.Write(dt, 0, dt.Length);
                        messTrans = "";

                    }
                    if ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        //msg1 = System.Text.Encoding.ASCII.GetBytes(prevdata);

                        // Send back a response.
                        //stream.Write(msg1, 0, msg1.Length);
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        //Debug.Log("Received:" + data + "data");
                        if (data != null)
                        {
                            for (int j = data.Length - 1; j > 0; j--)
                            {
                                if (data[j] == 'T') T = j;
                                if (data[j] == 'S') { S = j; break; }
                            }
                            if (T > S) tmpData = data.Substring(S + 1, T - S - 1);
                            string[] tok = tmpData.Split(',');
                            for (int ik = 0; ik < tok.Length; ik++)
                            {
                                int.TryParse(tok[ik], out angles[ik]);
                            }
                            //Debug.Log("Trimmed:" + tmpData + "data");
                            //Debug.Log(angles[2]);
                            stream.Flush();
                            Thread.Sleep(100);
                        }


                        /*
                                           // Splitting the string on ","
                                             string[] result = Regex.Split(data, ",");

                                            //Storing the values in a list "lis" containing 
                                            for (int i1 = 0; i1 < result.Length; i1++)
                                            {

                                                string s = "";
                                                for (int j = 0; j < result[i1].Length; j++)
                                                {
                                                    if (result[i1][j] == '.')
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        s += result[i1][j];
                                                    }
                                                }

                                                lis.Add(s);
                                                angles = Convert.ToInt32(s);
                                                Debug.Log(i + "=> " + lis[i]);
                                                Debug.Log(i + "=>" + angles);

                                            }*/
                        //Debug.Log("Sent:"+ data);
                        // Process the data sent by the client.
                        bool isTrue = false;
                    }
                }
            }
        }
        catch (SocketException e)
        {
            Debug.Log("SocketException:" + e);
        }
        finally
        {
            // Stop listening for new clients.
            server.Stop();
            server1.Stop();

        }
    }




}