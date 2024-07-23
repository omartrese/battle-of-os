using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combatMode : MonoBehaviour
{
    private const float HP_MAX = 80, MAX_ATTACK= 100, MAX_DEFENSE = 100;



    [SerializeField]
    private float currHP = 80;

    [Space(height: 20)]

    [SerializeField]
    private Image HPBar;

    void Start()
    {
        
    }

    void Update()
    {
       HPBar.fillAmount = currHP / HP_MAX;
    }
}
