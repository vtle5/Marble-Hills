using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointText : MonoBehaviour
{
    public bool active = false;
    public float timeVisible;
    public float floatSpeed;
    private float fadeTime;

    private RectTransform tf;
    private Text txt;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<RectTransform>();
        txt = GetComponent<Text>();
        startPos = tf.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (fadeTime < 3*(timeVisible/4))   //start moving after 25% of time has passed
            {
                tf.position = new Vector3(tf.position.x, tf.position.y + floatSpeed * Time.deltaTime, tf.position.z);

                if (fadeTime < 2*timeVisible/3) //start fading after 33% of time has passed
                {
                    txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, fadeTime/(timeVisible/2));
                    if (txt.color.a <= 0)
                    {
                        active = false; //if the text is completely invisible, stop
                    }
                }
            }
            fadeTime -= Time.deltaTime; //continue counting down
        }
    }

    public void Activate()
    {
        fadeTime = timeVisible;     //resets timer
        active = true;
        tf.position = startPos;     //resets position
        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, 1);    //resets transparency
    }
    public void ChangeText(string text)
    {
        txt.text = text;
    }
}
