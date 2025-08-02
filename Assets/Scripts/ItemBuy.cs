using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemBuy : MonoBehaviour
{
    GameManager gameManager;
    //public Panel buyPanel; // ��ȣ ���� ������ Panel�� public �Ұ���
    public Canvas buyCanvas;

    string dealerText = "������ ������ �� ���� �־�.\n�� �� �ž�?";
    bool[] itemBuyornot;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        buyCanvas.gameObject.SetActive(false);
        itemBuyornot = new bool[7];
    }

    public void BuyItems()
    {
        buyCanvas.gameObject.SetActive(true);

        // ���� �ؽ�Ʈ ����
        gameManager.eventText.text = dealerText;

        // �Ǹ� ���ǵ� ���� (buyCanvas��)
        int newItemTotalNum = 0;
        for (int i = 0; i < gameManager.items.Length; i++)
        {
            if (Random.value < gameManager.items[i].proba)
            {
                // ��ǰ �Ǹ� O
                newItemTotalNum++;

                // ���� UI ���� - TMP_Text
                GameObject textObj = new GameObject("ItemText");
                textObj.transform.SetParent(buyCanvas.transform); // buyCanvas�� ����


                TextMeshProUGUI tmpText = textObj.AddComponent<TextMeshProUGUI>(); // ������ ������Ʈ�� ������Ʈ ����
                tmpText.text = gameManager.items[i].name; // �Ǹ� ��ǰ �̸�
                tmpText.text += "\t";

                int newItemNum = 0; // �Ǹ� ��ǰ ����
                // if ���� ���� �� ����������
                switch (gameManager.items[i].name)
                {
                    case "��":
                    case "������":
                    case "����ũ":
                        newItemNum = Random.Range(1, 10); // 1 �̻� 10 �̸�
                        break;
                    case "�浶��":
                    case "��ȭ�� ��":
                    case "��":
                    case "����":
                        newItemNum = Random.Range(1, 4);
                        break;
                }
                tmpText.text += newItemNum.ToString() + " ��";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
