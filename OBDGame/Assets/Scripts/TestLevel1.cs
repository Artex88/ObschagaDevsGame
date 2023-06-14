using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class TestLevel1 : MonoBehaviour
{
    public Slot[] slots;
    public Item pc1;
    public Item pc2;
    public Item line1;

    public Text ipMyPcT;
    public Text ipPc2T;

    public GameObject successPanel;
    public GameObject errorPanel;

    public Text error;

    public bool Test1()
    {
        foreach (var slot in slots)
        {
            if (slot.transform.childCount == 0)
            {
                return false;
            }
        }

        if (slots[0].transform.GetChild(0).IsChildOf(pc1.transform) ||
            slots[0].transform.GetChild(0).IsChildOf(pc2.transform)) { }
        else { return false; }
        if (slots[2].transform.GetChild(0).IsChildOf(pc1.transform) ||
            slots[2].transform.GetChild(0).IsChildOf(pc2.transform) ) { }
        else { return false; }



        if (!slots[1].transform.GetChild(0).IsChildOf(line1.transform)) return false;

        var ip = GetIP().Split('.');
        string[] ipPc1 = ipMyPcT.text.Trim().Split('.');
        string[] ipPc2 = ipPc2T.text.Trim().Split('.');

        if (ip[0] != ipPc1[0] || ip[1] != ipPc1[1] || ip[2] != ipPc1[2] || ip[3] != ipPc1[3] ||
            ip[0] != ipPc2[0] || ip[1] != ipPc2[1] || ip[2] != ipPc2[2] || ip[3] == ipPc2[3] || int.Parse(ipPc2[3]) > 255 || int.Parse(ipPc2[3]) < 0 ||
            ipPc1[3] == ipPc2[3])
        {
            error.text = "неверно указан IP-адрес!";
            return false;
        }

        return true;
    }

    public string GetIP()
    {
        IPAddress ipAddress = null;
        IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

        for (int i = 0; i < localIPs.Length; i++)
        {
            if (localIPs[i].AddressFamily == AddressFamily.InterNetwork)
            {
                ipAddress = localIPs[i];
                break;
            }
        }
        return ipAddress.ToString();
    }

    public void StartTest1()
    {
        gameObject.SetActive(false);
        if (Test1())
        {
            successPanel.SetActive(true);
        }
        else
        {
            errorPanel.SetActive(true);
        }
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            Invoke("StartTest1", 4f);
        }
    }
}
