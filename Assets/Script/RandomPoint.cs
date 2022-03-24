using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPoint : MonoBehaviour
{
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("位置：" + this.transform.position);
    }

    private void OnEnable()
    {
        count = Random.Range(1, 4);

        if (count == 1)
        {
            transform.localPosition = new Vector3(-667, 80, 0);
            //GetComponent<RectTransform>().position = new Vector3(1375, 495, 0);
            Debug.Log("位置：" + this.transform.localPosition);
        }

        if (count == 2)
        {
            transform.localPosition = new Vector3(-282, 470, 0);
            //GetComponent<RectTransform>().position = new Vector3(1114, 750, 0);
            Debug.Log("位置：" + this.transform.localPosition);
        }

        if (count == 3)
        {
            transform.localPosition = new Vector3(235, 477, 0);
            //GetComponent<RectTransform>().position = new Vector3(772, 750, 0);
            Debug.Log("位置：" + this.transform.localPosition);
        }

        if (count==4)
        {
            transform.localPosition = new Vector3(628, 84, 0);
            //GetComponent<RectTransform>().position = new Vector3(512, 493, 0);
            Debug.Log("位置：" + this.transform.localPosition);
        }
    }
}
