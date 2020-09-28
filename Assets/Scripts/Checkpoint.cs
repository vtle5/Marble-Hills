using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointNum;       //checkpoint order
    public bool active = false;     //should only be toggled on for the checkpoint 0
    public bool finalPoint = false; //should onnly be toggled on for the last checkpoint
    [SerializeField]
    private float flashbang = 6;    //flash of light strength when activated
    [SerializeField]
    private float startingGlow = 1.5f;  //initial glow
    private float startY;   //starting Y to calculate movement post-activation

    private MeshRenderer render;    //gets the renderer
    private Material mat;           //gets the material for color changing
    private Color originalColor;
    private float flash;            //change in flash intensity over time
    private GameObject checkpointText;  

    void Start()
    {
        checkpointText = GameObject.Find("Canvas/Checkpoint Text"); //hard coded in due to checkpoint being a prefab
        render = GetComponent<MeshRenderer>();
        mat = render.material;
        originalColor = mat.color;                  //saves the original color

        flash = flashbang;                          //sets the flash strength for later activation
        float factor = Mathf.Pow(2, startingGlow);  //calculate the intensity factor
        Color color = new Color(originalColor.r * factor, originalColor.g * factor, originalColor.b * factor);  //applies intensity
        mat.color = color;                      //applies new intensified color

        startY = transform.position.y;
    }

    void Update()
    {
        if (active)     //different rotate speeds depending on activation
        {
            transform.Rotate(new Vector3(0, 140, 0) * Time.deltaTime);
        }
        else
        {
            transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (active)
        {
            if (transform.position.y < startY+4f)   //if the checkpoint hasnt reached its new destination
            {
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y,startY+2f,.1f), transform.position.z);   //raise y over time
            }
            if (flash >2)   //if the flash is too bright, lower it
            {
                float factor = Mathf.Pow(2, flash);
                Color color = new Color(originalColor.r * factor, originalColor.g * factor, originalColor.b * factor);
                mat.color = color;
                flash -= Time.deltaTime*3;
            }
        }
    }

    public void SelfCheck(int num)  //checks if it is a lower checkpoint then the new one. if so, destroy itself
    {
        if (checkpointNum < num)
        {
            Destroy(gameObject);
        }
    }

    public bool Activate(int num)   //kickstarts the activation process if the player has not reach it yet.
    {
        if (checkpointNum > num)
        {
            active = true;

            float factor = Mathf.Pow(2, flashbang);     //calculate the intensity factor
            Color color = new Color(originalColor.r * factor, originalColor.g * factor, originalColor.b * factor);  //apply intensity
            mat.color = color;                  //apply color

            checkpointText.GetComponent<CheckpointText>().Activate();       //activate the checkpoint text
            if (finalPoint)
            {
                checkpointText.GetComponent<CheckpointText>().ChangeText("Level Completed!");   //change the text if its the final one
            }
            return true;    //activation sucessful!
        }
        return false;   //activation failed
    }
}
