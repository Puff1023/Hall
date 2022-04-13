using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    public Material MonsterMat;
    public Color MonsterMatA;
    /*public Color MonsterHandMat;
   public Color MonsterFootsMat;
   public Color MonsterClothMat;
   public Color MonsterHeadMat;*/
    public float TempTime;
    public float count = 0;
    bool FadeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        TempTime = 0;
        MonsterMat = Resources.Load("NewMonster/NewMonsterMaterial_Scenes01") as Material;
        MonsterMat = GetComponent<Renderer>().material;
        MonsterMat.color = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (TempTime<1)
        {
            TempTime += Time.deltaTime; 
        }

        if (FadeOut)
        {
            if (MonsterMat.color.a>=1)
            {
                //MonsterMat.color.a -= TempTime / 5 * Time.deltaTime;
            }
            
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            count++;
            FadeOut = true;
            Debug.Log("¸I¨ì¤F");
        }
    }

    /*void TriggerCount()
    {
        if (count >= 5)
        {
            if (MonsterMat.a==0)
            {
                gameObject.transform.position = new Vector3(-40, 0, 30);
            }
        }
    }*/
}
