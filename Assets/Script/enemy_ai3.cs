using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;
public class enemy_ai3 : MonoBehaviour
{
    public static enemy_ai3 ins;
    public NavMeshAgent agent;
    public GameObject player;
    public Transform Point;
    public static NavMesh_Component nav;
    public int PointIndex = 0;
    public float CloseDistance;
    public Transform RestartPoint;
    public Transform RestartPoint1;
    public Transform RestartPoint2;
    public Transform Monster1;
    public Transform Monster2;
    public bool Reset;
    private void Awake()
    {
        ins = this;
    }
    // Start is called before the first frame update
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Point.position);
        Reset = false;
        MusicManager.ins.Monsterrr_player.clip = MusicManager.ins.Monster_clip[0];
        MusicManager.ins.Monsterrr_player.Play();
    }

    // Update is called once per frame
    private void FixedUpdate()

    {
        if (player.tag=="Prey")
        {
            agent.SetDestination(player.transform.position);
            
        }
    if(player.tag=="Player")
        {
            agent.SetDestination(Point.position);
            
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "Player")
        {
            Invoke("restart", 3.5f);
            Reset = true;
            MusicManager.ins.Monsterr_player.Pause();
            MusicManager.ins.Monster_player.Pause();
            MusicManager.ins.Monsterrr_player.Pause();

            agent.speed = 0;
            NavMesh_Component.ins.agent.speed = 0;
            enemy_ai2.ins.agent.speed = 0;
        }

        if (col.collider.tag == "Wood")
        {
            col.collider.GetComponent<BoxCollider>().isTrigger = true;
        }

    }
    private void restart()
    {
        if (Reset)
        {
            gameObject.SetActive(false);
            transform.position = RestartPoint.position;
            Monster1.position = RestartPoint1.position;
            Monster2.position = RestartPoint2.position;
        }
        MusicManager.ins.Monsterr_player.clip = MusicManager.ins.Monster_clip[0];
        MusicManager.ins.Monsterr_player.Play();
        MusicManager.ins.Monsterrr_player.clip = MusicManager.ins.Monster_clip[0];
        MusicManager.ins.Monsterrr_player.Play();
        MusicManager.ins.Monster_player.clip = MusicManager.ins.Monster_clip[0];
        MusicManager.ins.Monster_player.Play();
        gameObject.SetActive(true);
    }
}
