
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class Keyword :  MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] public TMP_Text m_keywordText;

    private RectTransform m_rectTransform;
    private CanvasGroup m_canvasGroup;
    private Vector2 m_initialPosition;
    private Blank m_currentBlank;

    private void Awake()
    {
        m_rectTransform = GetComponent<RectTransform>();
        m_canvasGroup = GetComponent<CanvasGroup>();

        if (m_canvasGroup == null)
        {
            m_canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        m_initialPosition = m_rectTransform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        UpdateTransparency(false);
        m_canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        m_rectTransform.anchoredPosition += eventData.delta / CanvasScalerFactor();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_canvasGroup.blocksRaycasts = true;
        m_canvasGroup.alpha = 1f;

        Collider2D hitCollider = Physics2D.OverlapPoint(m_rectTransform.position);
        Blank hitBlank = GetHoveredBlank();
        if (hitBlank != null)
        {
            AssignToBlank(hitBlank);
            UpdateTransparency(true);
        }
        else
        {
            ResetPosition();
        }
    }

    private void AssignToBlank(Blank blank)
    {
        if (m_currentBlank != null)
        {
            m_currentBlank.ClearKeyword();
        }

        blank.AssignKeyword(this);
        m_currentBlank = blank;

        m_rectTransform.position = blank.transform.position;
    }

    private Blank GetHoveredBlank()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        var raycastResults = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        foreach (var result in raycastResults)
        {
            Blank blank = result.gameObject.GetComponent<Blank>();
            if (blank != null)
                return blank;
        }

        return null;
    }

    public void ResetPosition()
    {
  
        m_rectTransform.position = m_initialPosition;

  
        if (m_currentBlank != null)
        {
            var tempBlank = m_currentBlank; 
            m_currentBlank = null;          
            tempBlank.ClearKeyword();
        }
    }


    private float CanvasScalerFactor()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        return canvas != null ? canvas.scaleFactor : 1f;
    }

    private void UpdateTransparency(bool transparent)
    {
        m_canvasGroup.alpha = transparent ? 0f : 0.5f;
    }
}
