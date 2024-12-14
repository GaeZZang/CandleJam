using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class PaseController : MonoBehaviour
{
    [SerializeField] GameObject[] m_pase;
    [SerializeField] GameObject m_end;
    [SerializeField] TMP_Text m_endText;
    [SerializeField] Button m_clickButton;

    Int32 m_currentPaseIndex = 0;
    Int32 m_currentTextIndex = 0;
    

    void Start()
    {
        m_clickButton.onClick.AddListener(OnClickChangeText);
    }

    public void End()
    {
        m_pase[m_currentPaseIndex].SetActive(false);
        m_end.SetActive(true);
        OnClickChangeText();
    }


    void OnClickChangeText()
    {
        switch (m_currentPaseIndex)
        {
            case 0:
                ChangeText(ref m_currentTextIndex, texts1, m_pase[m_currentTextIndex + 1]);
                break;
            case 1:
                ChangeText(ref m_currentTextIndex, texts2, m_pase[m_currentTextIndex + 1]);
                break;
            case 2:
                ChangeText(ref m_currentTextIndex, texts3, m_pase[m_currentTextIndex + 1]);
                break;
       
        }
   
    }

    void ChangeText(ref int currentTextIndex, List<string> texts, GameObject nextPase)
    {
        if (currentTextIndex < texts.Count)
        {
            m_endText.text = texts[currentTextIndex];
            currentTextIndex++;
        }
        else
        {
            nextPase.SetActive(true);
            m_end.SetActive(false);
            m_currentPaseIndex++;
        }
    }



    private List<string> texts1 = new List<string> {
        "첫 번째 텍스트",
        "두 번째 텍스트",
        "세 번째 텍스트",
        "네 번째 텍스트"
    };

    private List<string> texts2 = new List<string> {
        "첫 번째 텍스트",
        "두 번째 텍스트",
        "세 번째 텍스트",
        "네 번째 텍스트"
    };

    private List<string> texts3 = new List<string> {
        "첫 번째 텍스트",
        "두 번째 텍스트",
        "세 번째 텍스트",
        "네 번째 텍스트"
    };

}