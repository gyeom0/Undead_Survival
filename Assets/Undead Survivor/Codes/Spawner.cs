using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

  public Transform[] spawnPoint;
  float timer;
  void Awake()
  {
    spawnPoint = GetComponentsInChildren<Transform>();
  }
  void Update()
  {
    timer += Time.deltaTime;
    if (timer > 0.2f)
    {
      timer = 0f;
      Spawn();
    }
  }
  void Spawn()
  {
    GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, 2)); //0에서 1(스켈레톤, 좀비)인덱스의 적을 무작위로 선택
    enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position; //1~n 중 랜덤 위치에 적 배치 //자기자신을 포함하기 때문에 0이 아니라 1부터
  }
}
