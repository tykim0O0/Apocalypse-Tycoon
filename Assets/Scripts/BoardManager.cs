using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    GameManager gameManager;

    public TMP_Text inventext;
    public TMP_Text invenNumtext;
    public TMP_Text moneytext;
    public TMP_Text daytext;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        daytext.text = "";
        moneytext.text = "";
        inventext.text = "";
        invenNumtext.text = "";
    }

    public void UpdateBoard()
    {
        // ��¥ ������Ʈ
        daytext.text = "���� ";
        daytext.text += gameManager.day.ToString();
        daytext.text += " ����";

        // �ڻ� ������Ʈ
        moneytext.text = gameManager.money.ToString() + " �� ��";

        // ��� ������Ʈ
        for(int i = 0; i < 7; i++)
        {
            if (gameManager.items[i].avail)
            {
                // ��ǰ �̸� �߰�
                inventext.text += gameManager.items[i].name;
                // --- �߰�
                switch (gameManager.items[i].name)
                {
                    case "��":
                    case "��":
                        inventext.text += " ---------\n";
                        break;
                    case "������":
                    case "�浶��":
                    case "����ũ":
                        inventext.text += "  ----\n";
                        break;
                    case "����":
                        inventext.text += "  ------\n";
                        break;
                    case "������ټ�":
                        inventext.text += "  -\n";
                        break;
                }

                // ��ǰ ����
                invenNumtext.text += gameManager.items[i].num.ToString();
                invenNumtext.text += " ��\n";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
