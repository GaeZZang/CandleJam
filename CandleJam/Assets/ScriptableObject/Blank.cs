using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Blank : MonoBehaviour 
{

    [SerializeField] private Image m_image;
    [SerializeField] public TMP_Text m_text;
    [SerializeField] public String m_correct;

    private Keyword assignedKeyword;

    public void AssignKeyword(Keyword keyword)
    {
        if (assignedKeyword != null && assignedKeyword != keyword)
        {
            assignedKeyword.ResetPosition();
        }

        assignedKeyword = keyword;
        m_text.text = keyword.m_keywordText.text;

        if (m_text.text == m_correct)
        {
            Debug.Log("정답");
        }
        else
        {
            Debug.Log("오답");
        }
    }

    public void ClearKeyword()
    {
        if (assignedKeyword != null)
        {
            var tempKeyword = assignedKeyword; 
            assignedKeyword = null; 
            tempKeyword.ResetPosition();
        }
        m_text.text = "";
    }

}
