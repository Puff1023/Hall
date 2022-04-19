using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignTrigger : MonoBehaviour
{
    public Vector3 PlayerNewPos;
    public Transform Player;
    public Text[] text;
    public Transform Monster;
    public Vector3 MonsterNewPos;
    public bool PlayerStop;
    public bool T4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStop)
        {
            Player.position = Vector3.Lerp(Player.position, PlayerNewPos, 0.1f);
            Player.rotation = Quaternion.Lerp(Player.rotation, Quaternion.Euler(0, 10f, 0), 0.05f);
            text[0].color = Color.white;//第二句台詞出現
            StartCoroutine("TextChang");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            PlayerStop = true;
            PlayerMovement_Scenes01.ins.speed = 0;
            MouseLook_Scenes01.ins.MouseMoving = false;
        }
    }

    IEnumerator TextChang()//第三句台詞出來
    {
        Debug.Log("第三句");
        yield return new WaitForSeconds(3f);
        PlayerStop = false;
        text[0].color = Color.clear;
        text[1].color = Color.white;
        Monster.position = MonsterNewPos;
        StartCoroutine("SeeMonster");
    }
    IEnumerator SeeMonster()
    {
        Debug.Log("第四句");
        yield return new WaitForSeconds(3f);
        text[1].color = Color.clear;
        Player.rotation = Quaternion.Lerp(Player.rotation, Quaternion.Euler(0, 315f, 0), 0.05f);
        StartCoroutine("t4");
    }
    IEnumerator t4()
    {
        yield return new WaitForSeconds(2f);
        if (T4)
        {
            text[2].color = Color.white;
            StartCoroutine("t4lose");
        }
    }
    IEnumerator t4lose()
    {
        yield return new WaitForSeconds(2f);
        T4 = false;
        text[2].color = Color.clear;
        PlayerMovement_Scenes01.ins.speed = 2;
        MouseLook_Scenes01.ins.MouseMoving = true;
    }
}
