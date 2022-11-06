using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField]
    private Image noteColor;
    
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }
}
