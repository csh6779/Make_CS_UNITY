using UnityEngine;
using TMPro;  // TextMeshPro ���
using UnityEngine.UI;  // UI �̹��� ���

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;  // ��ȭ UI �г�
    public TextMeshProUGUI dialogueText; // ��ȭ �ؽ�Ʈ
    public Image portraitImage; // NPC �ʻ�ȭ �̹���
    public Sprite lunaPortrait; // �糪 �ʻ�ȭ �̹���

    public string[] dialogueLines;  // ��ȭ ���� �迭
    private int currentLineIndex = 0;  // ���� ��ȭ ���� ����

    private bool isPlayerNear = false; // �÷��̾ NPC ��ó�� �ִ��� ����

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialoguePanel.activeSelf)
            {
                StartDialogue();
            }
            else
            {
                NextDialogue();
            }
        }
    }

    void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        portraitImage.sprite = lunaPortrait; // �ʻ�ȭ ����
        dialogueText.text = dialogueLines[currentLineIndex]; // ù ��° ��� ���
    }

    void NextDialogue()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex]; // ���� ��� ǥ��
        }
        else
        {
            dialoguePanel.SetActive(false); // ��ȭ ����
            currentLineIndex = 0;
        }
    }

    // �÷��̾ NPC ��ó�� ������ ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    // �÷��̾ NPC ��ó���� �־����� ��
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = false;
            dialoguePanel.SetActive(false);
            currentLineIndex = 0;
        }
    }
}