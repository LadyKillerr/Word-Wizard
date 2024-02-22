using Framework;
using System.Collections.Generic;
using UnityEngine;
public class Intro : MonoBehaviour
{
    [SerializeField] GameObject createPopup;
    [SerializeField] GameObject selectAccountPopup;
    public void OnclickLearnButton() 
    {
        if(AccountConfig.ListAccount.Count != 0)
        {
            PopupHelper.Create(selectAccountPopup);
        }
        else
        {
            PopupHelper.Create(createPopup);
        }
    }
}

