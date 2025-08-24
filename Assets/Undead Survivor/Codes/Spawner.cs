using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  public SpawnData[] spawnData;
  public Transform[] spawnPoint;
  public float levelTime;
  int level;
  float timer;
  void Awake()
  {
    spawnPoint = GetComponentsInChildren<Transform>();
    levelTime = GameManager.instance.maxGameTime / spawnData.Length;
  }
  void Update()
  {
    if (!GameManager.instance.isLive)
      return;

    timer += Time.deltaTime;
    level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / levelTime), spawnData.Length - 1);

    if (timer > spawnData[level].spawnTime)
    {
      timer = 0f;
      Spawn();
    }
  }
  void Spawn()
  {
    GameObject enemy = GameManager.instance.pool.Get(0);
    enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position; //1~n 중 랜덤 위치에 적 배치 //자기자신을 포함하기 때문에 0이 아니라 1부터
    enemy.GetComponent<Enemy>().Init(spawnData[level]);
  }
}
[System.Serializable]
public class SpawnData
{
  public float spawnTime;
  public int spriteType;
  public int health;
  public float speed;

}
