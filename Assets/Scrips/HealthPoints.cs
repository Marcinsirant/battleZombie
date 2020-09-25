using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public GameObject bar;
    public int fullHp = 100;
    //public int currentHp = 100;
    // Start is called before the first frame update
    void Start()
    {
        bar = gameObject.transform.Find("Bar").gameObject;
    }

    public void SetHealthPoint(int currentHp) {
        double currentBar = ((double)currentHp / (double)fullHp) *120;
        bar.transform.localScale = new Vector2((float)currentBar, bar.transform.localScale.y);
    }
}
