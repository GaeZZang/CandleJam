using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KeywordSystem : MonoBehaviour
{
    [SerializeField] Blank[] m_blanks;
    [SerializeField] Keyword[] m_keywords;
    [SerializeField] PaseController m_paseController;

    private void Update()
    {
        CheckCompletion();
    }

    private void CheckCompletion()
    {
        foreach (var blank in m_blanks)
        {
            if( blank.m_text.text != blank.m_correct)
            {
                //Debug.Log(blank.m_text.text);
                //Debug.Log(blank.m_correct);
                return;
            }
        }

        Invoke("CallEnd", 1f);
        
        
    }

    private void CallEnd()
    {
        Debug.Log("»£√‚«‘");
        m_paseController.End();
    }
}