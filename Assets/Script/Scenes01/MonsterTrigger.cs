using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    public Material MonsterMat;
    public float count = 0;
    public float fadeSpeed = 3f;
    public Transform[] Point;
    public GameObject Player;
    bool FadeOut = false;

    // Update is called once per frame
    void Update()
    {
        if (FadeOut)
        {
            MonsterMat.color = Color.Lerp(MonsterMat.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);
        }

        if (!FadeOut)
        {
            MonsterMat.color = Color.white;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            PlayerMovement_Scenes01.ins.speed = 0;
            FadeOut = true;
            TriggerCount();
            Debug.Log("碰到了");
        }

        if (other.tag=="Point")
        {
            other.tag = "NotPoint";
            FadeOut = false;
        }
    }

    void TriggerCount()
    {
        if (MonsterMat.color.a <= 0.1f)
        {
            Debug.Log("消失");
            MonsterMat.color = Color.clear;
            count++;
            PlayerMovement_Scenes01.ins.speed = 2;
        }

        if (count==1)
        {
            gameObject.transform.position = Point[0].position;
            gameObject.transform.rotation = Quaternion.Euler(0, -6.8f, 0);
        }

        if (count == 2)
        {
            gameObject.transform.position = Point[1].position;
            gameObject.transform.rotation = Quaternion.Euler(0, 40, 0);
        }

        if (count == 3)
        {
            gameObject.transform.position = Point[2].position;
            gameObject.transform.rotation = Quaternion.Euler(2.57f, -106, 0);
        }

        if (count >= 4)
        {
            gameObject.transform.position = Point[3].position;
            gameObject.transform.rotation = Quaternion.Euler(2, -166, 0);
        }

        if (count>=5)
        {
            Player.tag = "NotPlayer";
        }
    }
}
