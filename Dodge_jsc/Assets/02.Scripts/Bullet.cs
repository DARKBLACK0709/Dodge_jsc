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


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
