using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Sign : MonoBehaviour
{
    public static Text_Sign ins;

    public float charsPerSecond = 0.2f;//���r�ɶ����j

    private string words;//�O�s�ݭn��ܪ���r

    private bool isActive = false;
    public float timer;//�p�ɾ�
    private Text myText;
    private int currentPos = 0;//��e���r��m
    private void Awake()
    {
        ins = this;

    }

    // Use this for initialization
    void Start()
    {
        timer = 0;
        isActive = true;
        // charsPerSecond = Mathf.Max(0.2f, charsPerSecond);
        myText = GetComponent<Text>();
        words = myText.text;
        myText.text = "";//���Text���奻�H���A�O�s��words���A�M��ʺA��s�奻��ܤ��e�A��{���r�����ĪG
    }

    // Update is called once per frame
    void Update()
    {
        OnStartWriter();
        //Debug.Log (isActive);
    }

    public void StartEffect()
    {
        isActive = true;
    }
    /// <summary>
    /// ���楴�r����
    /// </summary>
    void OnStartWriter()
    {

        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {//�P�_�p�ɾ��ɶ��O�_��F
                timer = 0;
                currentPos++;
                myText.text = words.Substring(0, currentPos);//��s�奻��ܤ��e

                if (currentPos >= words.Length)
                {
                    OnFinish();

                }
            }

        }
    }
    /// <summary>
    /// �������r�A��l�Ƽƾ�
    /// </summary>
    public void OnFinish()
    {
        myText.gameObject.SetActive(false);
        isActive = false;
        timer = 0;
        currentPos = 0;
        myText.text = words;
        PlayerMovement_Scenes01.ins.speed = 2;
    }
}

