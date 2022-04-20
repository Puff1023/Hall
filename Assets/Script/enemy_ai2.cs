using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;

public class enemy_ai2 : MonoBehaviour
{
    public static enemy_ai2 ins;
    //public float speed;
    public Transform[] Point;
    //第一個點
    public int PointIndex = 0;

    
    public GameObject player;
    public NavMeshAgent agent;
    public static NavMesh_Component nav;
    public float CloseDistance;

   
    public Transform RestartPoint;
    public Transform RestartPoint1;
    public Transform RestartPoint3;
    public bool Reset;

    public bool HuntMode = false;

    public Transform Monster1;
    public Transform Monster3;
    public bool StopMove;
    public bool Level2;
    public bool Level3;
    private void Awake()
    {
        ins = this;
    }
    // Start is called before the first frame update
    public void Start()
    {
        Reset = false;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Point[PointIndex].position);
        MusicManager.ins.Monsterr_player.clip = MusicManager.ins.Monster_clip[0];
        MusicManager.ins.Monsterr_player.Play();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (CheckPlayer())
        {
            HuntPlayer();
            return;
        }
        else
        {
            LeavePlayer();
        }

        if (CheckIsGetPoint())
        {

            PointIndex++;
            if (PointIndex > Point.Length - 1)
            {
                PointIndex = 0;
            }
            agent.SetDestination(Point[PointIndex].position);
        }
    }

    public void HuntPlayer()
    {
        if (!HuntMode)
        {
            HuntMode = true;
            agent.speed = 4f;
        }
        agent.SetDestination(player.gameObject.transform.position);
    }

    public void LeavePlayer()
    {
        if (HuntMode)
        {
           
            HuntMode = false;
            agent.speed = 3f;
            agent.SetDestination(Point[PointIndex].position);
        }
    }

    public bool CheckIsGetPoint()
    {
        //計算與點之間的距離
        float dis = Vector3.Distance(Point[PointIndex].position, transform.position);

        if (dis < CloseDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckPlayer()
    {
        if (player.tag == "Prey")
        {
            return true;

        }
        return false;
    }
  private  void OnCollisionEnter(Collision col) 
    {
        if (col.gameObject.name == "Player")
        {
            Invoke("restart", 3.5f);
            Reset = true;
            if (Level2)
            {
                MusicManager.ins.Monsterr_player.Pause(); enemy_ai3.ins.agent.speed = 0;
            }
            if (Level3)
            {
                MusicManager.ins.Monsterrr_player.Pause();
                enemy_ai3.ins.agent.speed = 0;
            }
            
            MusicManager.ins.Monster_player.Pause();

            enemy_ai3.ins.agent.speed = 0;
            NavMesh_Component.ins.agent.speed = 0;
            
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
            Monster3.position = RestartPoint3.position;
        }
        Reset = false;

        MusicManager.ins.Monsterr_player.clip = MusicManager.ins.Monster_clip[0];
        MusicManager.ins.Monsterr_player.Play();
        MusicManager.ins.Monsterrr_player.clip = MusicManager.ins.Monster_clip[0];
        MusicManager.ins.Monsterrr_player.Play();
        MusicManager.ins.Monster_player.clip = MusicManager.ins.Monster_clip[0];
        MusicManager.ins.Monster_player.Play();
        gameObject.SetActive(true);
    }
}