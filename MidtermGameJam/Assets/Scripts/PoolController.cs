using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    public GameObject myArm, myArm2, mPlayer, ResultCube;
    public string myColor;
    private Material myMaterial;
    public Material matGreen, matBlue, matRed;
    private bool isInRange;
    public GameObject InteractionText;
    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.Find("Player");
        myColor = "Default";
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInRange)
        {
            if (Vector3.Distance(this.transform.position, mPlayer.transform.position) < 5.0f)
            {
                EnteredRange();
            }
        }
        if (isInRange)
        {
            if (Vector3.Distance(this.transform.position, mPlayer.transform.position) > 6.0f)
            {
                LeftRange();
            }
            if (InputManager.Instance.Interacted())
            {
                interacted();
                this.GetComponent<Animator>().SetBool("isHit", true);
            }
        }
    }
    void EndAnimations() { this.GetComponent<Animator>().SetBool("isHit", false); }

    void LeftRange()
    {
        isInRange = false;
        InteractionText.SetActive(false);
    }

    void EnteredRange()
    {
        isInRange = true;
        InteractionText.SetActive(true);
    }
    
    void interacted()
    {
        mPlayer.SendMessage("PoolInteracted");
        
        switch (mPlayer.GetComponent<PlayerController>().BrushColor)
        {
            case "Blue":
                myColor = "Blue";
                this.GetComponent<MeshRenderer>().material = matBlue;
                myArm.GetComponent<MeshRenderer>().material = matBlue;
                myArm2.GetComponent<MeshRenderer>().material = matBlue;
                break;

            case "Green":
                myColor = "Green";
                this.GetComponent<MeshRenderer>().material = matGreen;
                myArm.GetComponent<MeshRenderer>().material = matGreen;
                myArm2.GetComponent<MeshRenderer>().material = matGreen;
                break;

            case "Red":
                myColor = "Red";
                this.GetComponent<MeshRenderer>().material = matRed;
                myArm.GetComponent<MeshRenderer>().material = matRed;
                myArm2.GetComponent<MeshRenderer>().material = matRed;
                break;
            default:
                break;
        }
        ResultCube.SendMessage("SetColor");
    }


}
