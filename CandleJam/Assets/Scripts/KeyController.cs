using System;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] GameObject m_menu;
    
    public Boolean isOpenedMenu = false;   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Å° ´­¸²");
            if (isOpenedMenu == true)
            {
                m_menu.SetActive(false);
                isOpenedMenu = false;
            }
            else
            {
                m_menu.SetActive(true);
                isOpenedMenu = true;
            }
        }
    }
}
