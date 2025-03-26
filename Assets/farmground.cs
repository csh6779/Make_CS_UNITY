using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Field"))
        {
            Debug.Log("������ ���� �ö��! ��ȣ�ۿ� ����");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Field"))
        {
            Debug.Log("���������� ���!");
        }
    }
}