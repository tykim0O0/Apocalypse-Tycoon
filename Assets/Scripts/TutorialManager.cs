using System;
using System.Collections;
using System.Collections.Generic;
using TMPro; // TextMeshProUGUI, TMP_Text 클래스
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public TMP_Text tutorialTxt;
    public Canvas panelCanvas;

    string[] tutorialDialogue = {
        "지구는 환경 오염으로 인해 망했다.\n대기 이산화탄소 농도는 끝도 없이 높아지고, 생물종이 다수 멸종했다.\n원인을 모르는 질병과 자연재해로 인구수는 줄었다.\n사회 시스템이 무너지고 몰아치는 재난에 이대로 인류는 멸종…하는 줄 알았으나",
        "시간이 흐르면서 기상이변도 점차 주기를 가지게 되었고\n어느 정도 예측이 가능해졌다.\n사람들은 더 나아진 상황에 적응해 나름의 질서를 갖추어\n각자 최선을 다해 생존하고 있다.\n방독면, 오염된 물, 통조림이 있어야 살 수 있는 악조건이지만,\n당신은 틈새시장을 노려 편의점 창업에 도전했다.",
        "어찌저찌 공간과 유통업자를 구했으니\n이제 매일 물자를 구입해 적절한 가격에 판매하고,\n매일 발생하는 사건들에 현명하게 대처하며 최대 이윤을 내 보자!"
    };
    bool isNext = false; // 특정 키 입력 대기를 위한 변수
    int paragraphCnt = 0; // 문단 카운트
    public float textDelay = 0.05f; // 유니티 인스펙터에서 수정 가능하도록 public

    // Start is called before the first frame update
    public void StartTutorial()
    {
        panelCanvas.gameObject.SetActive(false); // 왜 이 코드가 안 먹히는가
        tutorialTxt.gameObject.SetActive(true);
        tutorialTxt.text = null; // TMP_Text.text 비우기
        StartCoroutine(Typing(tutorialDialogue[paragraphCnt]));
    }

    void EndTutorial()
    {
        tutorialTxt.text = null;
        tutorialTxt.gameObject.SetActive(false); // SetActive는 gameObject에 붙어 있는 메소드
        // 게임 시작 함수 호출
        panelCanvas.gameObject.SetActive(true); // 게임 시작을 위해.. 나중에 필요없어지면 삭제
    }

    IEnumerator Typing(string texts) // 코루틴
    {
        // 타이핑 효과 - 한 글자씩 입력
        for (int i = 0; i < texts.Length; i++)
        {
            string letter = texts[i].ToString(); // char -> string
            tutorialTxt.text += letter; // 대사 한 글자 출력
            yield return new WaitForSeconds(textDelay); // 잠시 딜레이 후 다음 글자 출력
        }
        isNext = true; // 다음 대사로 넘어가기 위한 스페이스바 등을 누를 수 있게 됨
    }

    private void Update()
    {
        if (isNext) // 이전 대사가 다 출력되었다면
        {
            if (Input.GetKeyDown(KeyCode.Space)
                || Input.GetMouseButtonDown(0))
                // 대사 넘어가기 위한 키 & 마우스 이벤트
            {
                isNext = false;
                tutorialTxt.text = "";

                if (++paragraphCnt < tutorialDialogue.Length) // 텍스트 남아있다면
                {
                    StartCoroutine(Typing(tutorialDialogue[paragraphCnt]));
                }
                else EndTutorial();
            }
        }
    }
}
