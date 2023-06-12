using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class TestLevel1 : MonoBehaviour
{
    public Slot[] slots;
    public Item hub;
    public Item pc1;
    public Item pc2;
    public Item pc3;
    public Item line1;
    public Item line2;
    public Item line3;

    public Text ipHubT;
    public Text ipPc1T;
    public Text ipPc2T;
    public Text ipPc3T;

    public GameObject successPanel;
    public GameObject errorPanel;

    public Text error;

    public bool Test()
    {
        foreach(var slot in slots)
        {
            if (slot.transform.childCount == 0)
            {
                return false;
            }
        }

        if (slots[0].transform.GetChild(0).IsChildOf(pc1.transform) || 
            slots[0].transform.GetChild(0).IsChildOf(pc2.transform) || 
            slots[0].transform.GetChild(0).IsChildOf(pc3.transform)) { } else { return false; }
        if (slots[6].transform.GetChild(0).IsChildOf(pc1.transform) || 
            slots[6].transform.GetChild(0).IsChildOf(pc2.transform) || 
            slots[6].transform.GetChild(0).IsChildOf(pc3.transform)) { } else { return false; }
        if (slots[4].transform.GetChild(0).IsChildOf(pc1.transform) || 
            slots[4].transform.GetChild(0).IsChildOf(pc2.transform) || 
            slots[4].transform.GetChild(0).IsChildOf(pc3.transform)) { } else { return false; }

        if (!slots[2].transform.GetChild(0).IsChildOf(hub.transform)) return false;

        if (!slots[1].transform.GetChild(0).IsChildOf(line3.transform)) return false;
        if (!slots[3].transform.GetChild(0).IsChildOf(line1.transform)) return false;
        if (!slots[5].transform.GetChild(0).IsChildOf(line2.transform)) return false;

        var ip = GetIP();
        string ipHub = ipHubT.text;
        string ipPc1 = ipHubT.text;
        string ipPc2 = ipHubT.text;
        string ipPc3 = ipHubT.text;

        ipHub.Trim();
        ipPc1.Trim();
        ipPc2.Trim();
        ipPc3.Trim();

        if (ip != ipPc1 || ip != ipHub || ip != ipPc2 || ip != ipPc3)
        {
            error.text = "неверно указан IP-адрес!";
            return false;
        }

        return true;
    }

    public void StartTest()
    {
        gameObject.SetActive(false);
        if (Test())
        {
            successPanel.SetActive(true);
        }
        else
        {
            errorPanel.SetActive(true);
        }
    }

    public void Update()
    {
        if (gameObject.activeSelf)
        {
            Invoke("StartTest",4f);
        }
    }

    private string GetIP()
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
}
