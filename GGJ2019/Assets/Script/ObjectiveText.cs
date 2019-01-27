using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveText : MonoBehaviour {

    [SerializeField] public Text textToEdit;


    public static ObjectiveText Instance;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
}
