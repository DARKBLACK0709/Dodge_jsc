using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    // Update is called once per frame

    void Start()
    { //���� ������Ʈ���� Rigidbody ������Ʈ�� ã��
        // bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        // ������ �ٵ� �ӵ� = ���� ���� * �̵� �ӷ� 
        bulletRigidbody.velocity = transform.forward * speed;
        //new Vector3()

        // 3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
        // �޼ҵ�
        Destroy(gameObject, 3f);
    }



   // void Update()
    //{
  
    //}
    // Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���

    private void OnTriggerEnter(Collider other)
    //�浹�� ���� ���� ������Ʈ�� Player �±׸� �����ٸ�,
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
