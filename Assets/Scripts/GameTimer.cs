using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float Timer;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 300.0f;
        text = GetComponent<Text>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        text.text = Timer.ToString("0.0");
    }
}
