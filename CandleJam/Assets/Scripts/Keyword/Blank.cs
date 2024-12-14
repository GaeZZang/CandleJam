
//using TMPro;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class Blank : MonoBehaviour
//{
//    [SerializeField] TMP_Text m_text;

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        collision.gameObject.tag = "Blank";
//        Debug.Log(collision.GetComponent<KeywordButton>().m_keywordText.text);
//        m_text.text = collision.GetComponent<KeywordButton>().m_keywordText.text;

//    }
//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        collision.gameObject.tag = "Untagged";
//        m_text.text = null;
//    }

//}
