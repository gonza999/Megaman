using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LifeBar : MonoBehaviour
{
    public float hpMax = 100f;
    public static float hpActual = 100f;
    public Image lifeBar;

    private void Start()
    {
        hpActual = hpMax;
    }
    private void Update()
    {
        lifeBar.fillAmount = hpActual / hpMax;
    }

 

}
