using System;
using System.Collections;
using System.Collections.Generic;
using TMPro; // TextMeshProUGUI, TMP_Text Ŭ����
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public TMP_Text tutorialTxt;
    public Canvas panelCanvas;

    string[] tutorialDialogue = {
        "������ ȯ�� �������� ���� ���ߴ�.\n��� �̻�ȭź�� �󵵴� ���� ���� ��������, �������� �ټ� �����ߴ�.\n������ �𸣴� ������ �ڿ����ط� �α����� �پ���.\n��ȸ �ý����� �������� ����ġ�� �糭�� �̴�� �η��� �������ϴ� �� �˾�����",
        "�ð��� �帣�鼭 ����̺��� ���� �ֱ⸦ ������ �Ǿ���\n��� ���� ������ ����������.\n������� �� ������ ��Ȳ�� ������ ������ ������ ���߾�\n���� �ּ��� ���� �����ϰ� �ִ�.\n�浶��, ������ ��, �������� �־�� �� �� �ִ� ������������,\n����� ƴ�������� ��� ������ â���� �����ߴ�.",
        "�������� ������ ������ڸ� ��������\n���� ���� ���ڸ� ������ ������ ���ݿ� �Ǹ��ϰ�,\n���� �߻��ϴ� ��ǵ鿡 �����ϰ� ��ó�ϸ� �ִ� ������ �� ����!"
    };
    bool isNext = false; // Ư�� Ű �Է� ��⸦ ���� ����
    int paragraphCnt = 0; // ���� ī��Ʈ
    public float textDelay = 0.05f; // ����Ƽ �ν����Ϳ��� ���� �����ϵ��� public

    // Start is called before the first frame update
    public void StartTutorial()
    {
        panelCanvas.gameObject.SetActive(false); // �� �� �ڵ尡 �� �����°�
        tutorialTxt.gameObject.SetActive(true);
        tutorialTxt.text = null; // TMP_Text.text ����
        StartCoroutine(Typing(tutorialDialogue[paragraphCnt]));
    }

    void EndTutorial()
    {
        tutorialTxt.text = null;
        tutorialTxt.gameObject.SetActive(false); // SetActive�� gameObject�� �پ� �ִ� �޼ҵ�
        // ���� ���� �Լ� ȣ��
        panelCanvas.gameObject.SetActive(true); // ���� ������ ����.. ���߿� �ʿ�������� ����
    }

    IEnumerator Typing(string texts) // �ڷ�ƾ
    {
        // Ÿ���� ȿ�� - �� ���ھ� �Է�
        for (int i = 0; i < texts.Length; i++)
        {
            string letter = texts[i].ToString(); // char -> string
            tutorialTxt.text += letter; // ��� �� ���� ���
            yield return new WaitForSeconds(textDelay); // ��� ������ �� ���� ���� ���
        }
        isNext = true; // ���� ���� �Ѿ�� ���� �����̽��� ���� ���� �� �ְ� ��
    }

    private void Update()
    {
        if (isNext) // ���� ��簡 �� ��µǾ��ٸ�
        {
            if (Input.GetKeyDown(KeyCode.Space)
                || Input.GetMouseButtonDown(0))
                // ��� �Ѿ�� ���� Ű & ���콺 �̺�Ʈ
            {
                isNext = false;
                tutorialTxt.text = "";

                if (++paragraphCnt < tutorialDialogue.Length) // �ؽ�Ʈ �����ִٸ�
                {
                    StartCoroutine(Typing(tutorialDialogue[paragraphCnt]));
                }
                else EndTutorial();
            }
        }
    }
}
