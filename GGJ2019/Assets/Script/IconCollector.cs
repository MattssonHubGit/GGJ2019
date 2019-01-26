using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconCollector : MonoBehaviour {

    [SerializeField] private Image iconPrefab;
    [Space]
    public Sprite northIcon;
    public Sprite southIcon;
    public Sprite westIcon;
    public Sprite eastIcon;
    public Sprite waitIcon;

    public static IconCollector Instance;

    private List<Image> allIcons = new List<Image>();

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void UpdateCommandList()
    {
        for (int i = 0; i < allIcons.Count; i++)
        {
            Destroy(allIcons[i].gameObject);
        }

        allIcons = new List<Image>();

        //create new ones
        for (int i = 0; i < InputCollector.Instance.keylist.Count; i++)
        {
            Image _icon = Instantiate(iconPrefab, this.transform);
            allIcons.Add(_icon);

            //north
            if (InputCollector.Instance.keylist[i] == "up")
            {
                _icon.sprite = northIcon;
            }

            //south
            if (InputCollector.Instance.keylist[i] == "down")
            {
                _icon.sprite = southIcon;
            }

            //east
            if (InputCollector.Instance.keylist[i] == "right")
            {
                _icon.sprite = eastIcon;
            }

            //west
            if (InputCollector.Instance.keylist[i] == "left")
            {
                _icon.sprite = westIcon;
            }

            //wait
            if (InputCollector.Instance.keylist[i] == "space")
            {
                _icon.sprite = waitIcon;
            }
            
        }
    }
}
