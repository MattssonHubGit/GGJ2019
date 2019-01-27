using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour {

    public Player player;
    public Image fillImage;
    public Text timerText;

    public static TimerUI Instance;

    private void Awake()
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

    private void Update()
    {
        timerText.text = Mathf.FloorToInt(player.timeleft).ToString();
        if (Mathf.FloorToInt(player.timeleft) < 0)
        {
            timerText.text = "0";
        }
        fillImage.fillAmount = ((float)player.timeleft / (float)player.maxturntime) ;
    }

    private IEnumerator HandleFill()
    {
        yield return null;
    }
}
