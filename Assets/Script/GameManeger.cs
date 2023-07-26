using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManeger : MonoBehaviour
{
    [SerializeField] TalkManeger talkManeger;
    [SerializeField] GameObject talkPanel;
    [SerializeField] TMP_Text talkText;
    [SerializeField] GameObject scanObj;
    [SerializeField] Image npcImage;
    public int talkIndex;
    public bool isAction;
    public void Action(GameObject scanObject)
    {
        scanObj = scanObject;
        ObjData objData = scanObj.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);
    }
    public void Talk(int id, bool isNpc)
    {
        string talkData = talkManeger.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }
        if(isNpc)
        {
            talkText.text = talkData.Split(':')[0];
            npcImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;
            npcImage.color = new Color(1, 1, 1, 0);
        }
        isAction = true;
        talkIndex++;
    }
}
