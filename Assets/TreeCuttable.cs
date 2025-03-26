using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit //ToolHit�� ���߿� ������ �̿��� ��ȣ�ۿ��� ���� ����
{
    //SerializeField�� �������ָ�, �ڵ忡���� �ƴ� Unity�� ������Ʈ���� ���� ������ �� �ְ� ���ݴϴ�.
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;


    public override void Hit() //virtual���� ������ �־� override����
    {
        while (dropCount > 0)
        {
            dropCount -= 1;

            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(pickUpDrop);
            go.transform.position = position;
        }
        Destroy(gameObject);
    }
}