using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    // Update is called once per frame

    void Start()
    { //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아
        // bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        // 리지드 바디 속도 = 앞쪽 방향 * 이동 속력 
        bulletRigidbody.velocity = transform.forward * speed;
        //new Vector3()

        // 3초 뒤에 자신의 게임 오브젝트 파괴
        // 메소드
        Destroy(gameObject, 3f);
    }



   // void Update()
    //{
  
    //}
    // 트리거 충돌 시 자동으로 실행되는 메서드

    private void OnTriggerEnter(Collider other)
    //충돌한 상대방 게임 오브젝트가 Player 태그를 가졌다면,
    {
        if (other.tag == "player")
        {
            PlayerController playerController =
                 other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
