using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  public Vector2 inputVec;
  public float speed;
  public Scanner scanner;
  public Hand[] hands;

  Rigidbody2D rigid;
  SpriteRenderer spriter;
  Animator anim;

  void Awake()
  {
    rigid = GetComponent<Rigidbody2D>();
    spriter = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
    scanner = GetComponent<Scanner>();
    hands = GetComponentsInChildren<Hand>(true);
  }

  void FixedUpdate()
  {
    Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
    // 3. 위치 이동
    rigid.MovePosition(rigid.position + nextVec);
  }
  void OnMove(InputValue value)
  {
    inputVec = value.Get<Vector2>();
  }

  void LateUpdate()
  {
    anim.SetFloat("Speed", inputVec.magnitude);
    if (inputVec.x != 0)
    {
      spriter.flipX = inputVec.x < 0;
    }
  }

}

