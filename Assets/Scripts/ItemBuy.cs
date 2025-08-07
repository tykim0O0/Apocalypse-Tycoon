using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ItemBuy : MonoBehaviour
{
    public GameManager gameManager;
    //public Panel buyPanel; // ��ȣ ���� ������ Panel�� public �Ұ���
    public Canvas buyCanvas;
    public TMP_Text[] itemtexts = new TMP_Text[6];
    public TMP_InputField[] iteminputs = new TMP_InputField[6];

    string dealerText = "������ ������ �� ���� �־�.\n�� �� �ž�?";
    bool[] itemBuyornot;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        buyCanvas.gameObject.SetActive(false);
        itemBuyornot = new bool[7];
        foreach (var itemtext in itemtexts) // c#�� foreach var in
            itemtext.gameObject.SetActive(false);
        foreach (var iteminput in iteminputs)
            iteminput.gameObject.SetActive(false);
        BuyItems();
    }

    void ShowBuying()
    {
        // ���� �ؽ�Ʈ ����
        gameManager.eventText.text = dealerText;

        // �Ǹ� ���ǵ� ���� (buyCanvas��)
        int newItemTotalNum = 0;
        for (int i = 0; i < gameManager.items.Length; i++)
        {
            if (newItemTotalNum == 6) break; // 6�������� �Ǹ�
            if (Random.value < gameManager.items[i].proba)
            {
                //itemBuyornot[i] = true; // ������ �ŷ���..? �� ��ߵ� ���ƾߵ�
                itemtexts[newItemTotalNum].gameObject.SetActive(true);
                iteminputs[newItemTotalNum].gameObject.SetActive(true);

                // ������Ʈ ��ġ ����
                int y_pos = -40 - (newItemTotalNum * 70);
                //itemtexts[newItemTotalNum].transform.position = new Vector3(0, y_pos, 0);
                //iteminputs[newItemTotalNum].transform.position = new Vector3(140, y_pos, 0);

                // UI�� RectTransform ����� ���� ��ǥ anchoredPosition ���
                itemtexts[newItemTotalNum].rectTransform.anchoredPosition = new Vector2(0, y_pos);
                iteminputs[newItemTotalNum].GetComponent<RectTransform>().anchoredPosition = new Vector2(140, y_pos);


                // ��ǰ �̸� -> TMP_Text.text
                string newItemString = "";
                switch (gameManager.items[i].name)
                {
                    case "��":
                        newItemString = "��  --------------------      / ";
                        break;
                    case "������":
                        newItemString = "������  ----------------      / ";
                        break;
                    case "����ũ":
                        newItemString = "����ũ  ----------------      / ";
                        break;
                    case "�浶��":
                        newItemString = "�浶��  ----------------      / ";
                        break;
                    case "��ȭ�� ��":
                        newItemString = "������ ��  -------------      / ";
                        break;
                    case "��":
                        newItemString = "��  --------------------      / ";
                        break;
                    case "����":
                        newItemString = "����  ------------------      / ";
                        break;
                }
                itemtexts[newItemTotalNum].text = newItemString;

                // ��ǰ ���� -> TMP_Text.text
                int newItemNum = 0; // �Ǹ� ��ǰ ����
                if (gameManager.items[i].name == "��" || gameManager.items[i].name == "������"
                    || gameManager.items[i].name == "����ũ")
                    newItemNum = Random.Range(1, 10); // 1 �̻� 10 �̸�
                else
                    newItemNum = Random.Range(1, 4);
                itemtexts[newItemTotalNum].text += newItemNum.ToString() + " ��";

                newItemTotalNum++;
            }
        }
    }

    public void BuyItems()
    {
        buyCanvas.gameObject.SetActive(true);

        ShowBuying(); // �ؽ�Ʈ ����


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
