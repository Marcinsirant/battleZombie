using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerClickHandler
{

    public AreaWithButtons areaWithButtons;


    public void OnPointerClick(PointerEventData eventData)
    {
        areaWithButtons.ChangePanel(this);
    }


}
