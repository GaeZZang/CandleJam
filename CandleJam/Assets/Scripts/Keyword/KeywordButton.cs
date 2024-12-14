
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeywordButton : MonoBehaviour, IDropHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Button m_keywordButton;
    [SerializeField] public TMP_Text m_keywordText;
    Image m_image;

    Vector2 m_defaultPos;


    private void Start()
    {
        m_image = GetComponent<Image>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        m_defaultPos = this.transform.position;
        eventData.pointerDrag = this.gameObject;
        Debug.Log($"OnBeginDrag: pointerDrag 설정 완료 - {this.gameObject.name}");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(eventData.position);
        this.transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.position = m_defaultPos;

    }

    public void OnDrop(PointerEventData eventData)
    {
        if ( this.tag == "Blank")
        {
            m_image.color = new Color(1,1,1, 0);
            m_keywordText.color = new Color(1, 1, 1, 0);
        }
    }
}
