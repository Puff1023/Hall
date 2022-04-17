using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Video;
public class NavMesh_Component : MonoBehaviour
{
    public static NavMesh_Component ins;
    public NavMeshAgent agent;
    public static NavMesh_Component nav;
    public Transform RestartPoint;
    public Transform RestartPoint2;
    public Transform RestartPoint3;

    public GameObject player;
    public Transform Monster2;
    public Transform Monster3;
    public bool Reset;

    private void Awake()
    {
        ins = this;
    }
    // Update is called once per frame
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MusicManager.ins.Monster_player.clip = MusicManager.ins.Monster_clip[0];
        MusicManager.ins.Monster_player.Play();
        Reset = false;
    }
    private void FixedUpdate()
    {
        agent.SetDestination(player.transform.position);
        agent.nextPosition = transform.position;//Nav跟隨怪物
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "Player")
        {
            Debug.Log("抓到");
            Invoke("restart", 4.5f);
            Reset = true;
            MusicManager.ins.Monsterr_player.Pause();
            MusicManager.ins.Monster_player.Pause();
            MusicManager.ins.Monsterr_player.Pause();

            agent.speed = 0;
            enemy_ai2.ins.agent.speed = 0;
            enemy_ai3.ins.agent.speed = 0;
        }

        if (col.collider.tag=="Wood")
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
            Monster2.position = RestartPoint2.position;
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
