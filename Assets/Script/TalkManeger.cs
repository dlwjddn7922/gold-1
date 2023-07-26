using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManeger : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> npcData;
    [SerializeField] Sprite[] npcSp;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        npcData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?:0", "�� ȣ���� ���� �Ƹ�����?:1", "��� �� ȣ������ ������ ����� ������ �ִٰ���.:2" });
        talkData.Add(2000, new string[] { "�ȳ�?:0", "�̰��� ó�� �Ա���?:1", "�� �̸��� Luna��:2" });
        talkData.Add(100, new string[] { "����� �������ڴ�."});
        talkData.Add(200, new string[] { "������ ����ߴ� ������ �ִ� å���̴�." });
        talkData.Add(300, new string[] { "����� ���̴�." });
        npcData.Add(1000 + 0, npcSp[0]);
        npcData.Add(1000 + 1, npcSp[1]);
        npcData.Add(1000 + 2, npcSp[2]);
        npcData.Add(1000 + 3, npcSp[3]);
        npcData.Add(2000 + 0, npcSp[4]);
        npcData.Add(2000 + 1, npcSp[5]);
        npcData.Add(2000 + 2, npcSp[6]);
        npcData.Add(2000 + 3, npcSp[7]);

    }
    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
    public Sprite GetSprite(int id, int npcIndex)
    {
        return npcData[id + npcIndex];
    }
}
