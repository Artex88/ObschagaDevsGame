using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class TestLevel6 : MonoBehaviour
{
    public Slot[] slots;
    public Item pc1;
    public Item pc2;
    public Item pc3;
    public Item pc4;

    public Item line1;
    public Item line2;
    public Item line3;
    public Item line4;
    public Item line5;
    public Item line6;

    public Item swith1;
    public Item swith2;
    public Item router;

    public Text ipMyPcT;
    public Text ipPc2T;
    public Text ipPc3T;
    public Text ipPc4T;

    public GameObject successPanel;
    public GameObject errorPanel;

    public Text error;

    public bool Test()
    {
        foreach (var slot in slots)
        {
            if (slot.transform.childCount == 0)
            {
                return false;
            }
        }

        if (slots[0].transform.GetChild(0).IsChildOf(pc1.transform) ||
            slots[0].transform.GetChild(0).IsChildOf(pc2.transform) ||
            slots[0].transform.GetChild(0).IsChildOf(pc3.transform) ||
            slots[0].transform.GetChild(0).IsChildOf(pc4.transform)) { }
        else { return false; }

        if (slots[1].transform.GetChild(0).IsChildOf(pc1.transform) ||
            slots[1].transform.GetChild(0).IsChildOf(pc2.transform) ||
            slots[1].transform.GetChild(0).IsChildOf(pc3.transform) ||
            slots[1].transform.GetChild(0).IsChildOf(pc4.transform)) { }
        else { return false; }

        if (slots[2].transform.GetChild(0).IsChildOf(pc1.transform) ||
            slots[2].transform.GetChild(0).IsChildOf(pc2.transform) ||
            slots[2].transform.GetChild(0).IsChildOf(pc3.transform) ||
            slots[2].transform.GetChild(0).IsChildOf(pc4.transform)) { }
        else { return false; }

        if (slots[3].transform.GetChild(0).IsChildOf(pc1.transform) ||
            slots[3].transform.GetChild(0).IsChildOf(pc2.transform) ||
            slots[3].transform.GetChild(0).IsChildOf(pc3.transform) ||
            slots[3].transform.GetChild(0).IsChildOf(pc4.transform)) { }
        else { return false; }

        if (slots[4].transform.GetChild(0).IsChildOf(swith1.transform) || slots[4].transform.GetChild(0).IsChildOf(swith2.transform)) { }
        else { return false; }

        if (slots[5].transform.GetChild(0).IsChildOf(swith1.transform) || slots[5].transform.GetChild(0).IsChildOf(swith2.transform)) { }
        else { return false; }

        if (!slots[6].transform.GetChild(0).IsChildOf(router.transform))
        {
            return false;
        }

        if (slots[7].transform.GetChild(0).IsChildOf(line1.transform) || slots[7].transform.GetChild(0).IsChildOf(line2.transform)) { }
        else { return false; }

        if (slots[8].transform.GetChild(0).IsChildOf(line1.transform) || slots[8].transform.GetChild(0).IsChildOf(line2.transform)) { }
        else { return false; }

        if (slots[9].transform.GetChild(0).IsChildOf(line4.transform) || slots[9].transform.GetChild(0).IsChildOf(line5.transform)) { }
        else { return false; }

        if (slots[10].transform.GetChild(0).IsChildOf(line4.transform) || slots[10].transform.GetChild(0).IsChildOf(line5.transform)) { }
        else { return false; }

        if (slots[11].transform.GetChild(0).IsChildOf(line3.transform) || slots[11].transform.GetChild(0).IsChildOf(line6.transform)) { }
        else { return false; }

        if (slots[12].transform.GetChild(0).IsChildOf(line3.transform) || slots[12].transform.GetChild(0).IsChildOf(line6.transform)) { }
        else { return false; }

        var ip = GetIP().Split('.');
        string[] ipPc1 = ipMyPcT.text.Trim().Split('.');
        string[] ipPc2 = ipPc2T.text.Trim().Split('.');
        string[] ipPc3 = ipPc3T.text.Trim().Split('.');
        string[] ipPc4 = ipPc4T.text.Trim().Split('.');



        if (ip[0] != ipPc1[0] || ip[1] != ipPc1[1] || ip[2] != ipPc1[2] || ip[3] != ipPc1[3] ||
            ip[0] != ipPc2[0] || ip[1] != ipPc2[1] || ip[2] != ipPc2[2] || ip[3] == ipPc2[3] || int.Parse(ipPc2[3]) > 255 || int.Parse(ipPc2[3]) < 0 ||
            ip[0] != ipPc3[0] || ip[1] != ipPc3[1] || ip[2] != ipPc3[2] || ip[3] == ipPc3[3] || int.Parse(ipPc3[3]) > 255 || int.Parse(ipPc3[3]) < 0 ||
            ip[0] != ipPc4[0] || ip[1] != ipPc4[1] || ip[2] != ipPc4[2] || ip[3] == ipPc4[3] || int.Parse(ipPc4[3]) > 255 || int.Parse(ipPc4[3]) < 0 ||
            ipPc1[3] == ipPc2[3] || ipPc1[3] == ipPc3[3] || ipPc3[3] == ipPc2[3] || ipPc4[3] == ipPc1[3] || ipPc4[3] == ipPc2[3] || ipPc4[3] == ipPc3[3])
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

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            Invoke("StartTest", 4f);
        }
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
}
