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
        talkData.Add(1000, new string[] { "안녕?:0", "이 호수는 정말 아름답지?:1", "사실 이 호수에는 무언가의 비밀이 숨겨져 있다고해.:2" });
        talkData.Add(2000, new string[] { "안녕?:0", "이곳에 처음 왔구나?:1", "내 이름은 Luna야:2" });
        talkData.Add(100, new string[] { "평범한 나무상자다."});
        talkData.Add(200, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });
        talkData.Add(300, new string[] { "평범한 돌이다." });
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
