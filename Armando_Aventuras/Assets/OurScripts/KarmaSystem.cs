using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarmaSystem : MonoBehaviour
{
    public GameObject[] NPCList;
    public List<int> KarmaValue = new List<int>();
    bool villain = false;

    private List<int> previousKarma = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        NPCList = GameObject.FindGameObjectsWithTag("NPC");
        SetStartingValues(NPCList);
        for (int i = 0; i < KarmaValue.Count; i++)
        {
            previousKarma.Add(KarmaValue[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (previousKarma != KarmaValue)
        {
            UpdateColors();
        }
    }

    void SetStartingValues(GameObject[] NPCList)
    {
        for (int i = 0; i < NPCList.Length; i++)
        {
            KarmaValue.Add(Random.Range(0, 11));
            Renderer r = NPCList[i].GetComponent<Renderer>();
            if (KarmaValue[i] == 0)
            {
                r.material.color = Color.red;
                villain = true;
            }
            else if (KarmaValue[i] <= 5)
            {
                r.material.color = new Color(1f, 0.64f, 0f, 1f);
            }
            else
            {
                r.material.color = Color.blue;
            }
        }

        if (!villain)
        {
            int rand = Random.Range(0, NPCList.Length);
            NPCList[rand].GetComponent<Renderer>().material.color = Color.red;
            KarmaValue[rand] = 0;
        }
    }

    void UpdateColors()
    {
        for(int i = 0; i < NPCList.Length; i++)
        {
            if (KarmaValue != previousKarma)
            {
                Renderer r = NPCList[i].GetComponent<Renderer>();
                if (KarmaValue[i] == 0)
                {
                    r.material.color = Color.red;
                    villain = true;
                }
                else if (KarmaValue[i] <= 5)
                {
                    r.material.color = new Color(1f, 0.64f, 0f, 1f);
                }
                else
                {
                    r.material.color = Color.blue;
                }
            }
        }
    }

    public void AddKarma(GameObject NPC){

        for(int i = 0; i < NPCList.Length; i++)
        {
            if(NPC == NPCList[i]){
                KarmaValue[i]++;
            }
        }
    }

    public void RemoveKarma(GameObject NPC){

         for(int i = 0; i < NPCList.Length; i++)
        {
            if(NPC == NPCList[i]){
                KarmaValue[i]--;
            }
        }
    }
}