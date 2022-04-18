using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignTrigger : MonoBehaviour
{
    public Vector3 PlayerNewPos;
    public Transform Player;
    public bool PlayerStop;
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
            Player.rotation = Quaternion.Lerp(Player.rotation, Quaternion.Euler(0, 360f, 0), 0.05f);
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
}
