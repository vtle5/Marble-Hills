using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject blurPanel;

    public void ShowMenu()
    {
        Animator anim = gameObject.GetComponent<Animator>();
        if (anim != null)
        {
            bool isOpen = anim.GetBool("openMenu");
            anim.SetBool("openMenu", !isOpen);
            blurPanel.SetActive(!isOpen);
        }
    }
}
