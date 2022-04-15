using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AniCheck : MonoBehaviour
{
    public Animator Wood;
    public Transform PlayerOriginal;
    bool CheckAni=true;
    // Start is called before the first frame update
    void Start()
    {
        Wood = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckAni)
        {
            if (Wood.GetCurrentAnimatorStateInfo(0).IsName("WoodTrigger"))
            {
                Debug.Log("дькOп}");
                NavMesh_Component.ins.agent.speed = 4;
                PlayerOriginal.position = new Vector3(-38.4f, 0, -42);
                CheckAni = false;
            }
            else
            {
                NavMesh_Component.ins.agent.speed = 0;
            }
        }
    }
}
