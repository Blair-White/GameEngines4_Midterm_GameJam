using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultController : MonoBehaviour
{
    public GameObject Pool1, Pool2, Door, effect, uiMgr;
    public string CorrectColor, MyColor;
    private Material myMat;
    public Material matGreen, matRed, matBlue, matYellow, matPurple, matCyan;
    private bool isOpen, endedAnim;
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOpen)
            if (this.MyColor == CorrectColor)
            {
                Door.SendMessage("Open");
                uiMgr.SendMessage("RoomCompleted");
                this.GetComponent<Animator>().SetBool("isOpen", true);
                isOpen = true;
                effect.SetActive(true);
            }
        if(isOpen && !endedAnim)
        {
            count += Time.deltaTime;
            if(count > 3)
            {
                this.GetComponent<Animator>().SetBool("isOpen", false);
                count = 0;
                endedAnim = true;
                effect.SetActive(false);
            }
        }
    }

    void SetColor()//this is kind of a monster but whatevs! it works lol. 
    {
        //compare from pool 1 
        //if pool 1 is default
        if (Pool1.GetComponent<PoolController>().myColor == "Default")
        {
            if(Pool2.GetComponent<PoolController>().myColor == "Red")
            {
                this.GetComponent<MeshRenderer>().material = matRed;
                MyColor = "Red";
                return;
            }
            if (Pool2.GetComponent<PoolController>().myColor == "Blue")
            {
                this.GetComponent<MeshRenderer>().material = matBlue;
                MyColor = "Blue";
                return;
            }
            if (Pool2.GetComponent<PoolController>().myColor == "Green")
            {
                this.GetComponent<MeshRenderer>().material = matGreen;
                MyColor = "Green";
                return;
            }
        }
        //if pool 1 is red
        if (Pool1.GetComponent<PoolController>().myColor == "Red")
        {
            if (Pool2.GetComponent<PoolController>().myColor == "Red")
            {
                this.GetComponent<MeshRenderer>().material = matRed;
                MyColor = "Red";
                return;
            }
            if (Pool2.GetComponent<PoolController>().myColor == "Blue")
            {
                this.GetComponent<MeshRenderer>().material = matPurple;
                MyColor = "Purple";
                return;
            }
            if (Pool2.GetComponent<PoolController>().myColor == "Green")
            {
                this.GetComponent<MeshRenderer>().material = matYellow;
                MyColor = "Yellow";
                return;
            }
            if (Pool2.GetComponent<PoolController>().myColor == "Default")
            {
                this.GetComponent<MeshRenderer>().material = matRed;
                MyColor = "Red";
                return;
            }
        }
        //if pool 1 is blue
        if (Pool1.GetComponent<PoolController>().myColor == "Blue")
        {
            if (Pool2.GetComponent<PoolController>().myColor == "Red")
            {
                this.GetComponent<MeshRenderer>().material = matPurple;
                MyColor = "Purple";
                return;
            }
            if (Pool2.GetComponent<PoolController>().myColor == "Blue")
            {
                this.GetComponent<MeshRenderer>().material = matBlue;
                MyColor = "Blue";
                return;
            }
            if (Pool2.GetComponent<PoolController>().myColor == "Green")
            {
                this.GetComponent<MeshRenderer>().material = matCyan;
                MyColor = "Cyan";
                return;
            }
            if (Pool2.GetComponent<PoolController>().myColor == "Blue")
            {
                this.GetComponent<MeshRenderer>().material = matBlue;
                MyColor = "Blue";
                return;
            }
        }
        //if pool 1 is green
        if (Pool1.GetComponent<PoolController>().myColor == "Green")
        {
            if (Pool2.GetComponent<PoolController>().myColor == "Red")
            {
                this.GetComponent<MeshRenderer>().material = matYellow;
                MyColor = "Yellow";
                return;
            }
            if (Pool2.GetComponent<PoolController>().myColor == "Blue")
            {
                this.GetComponent<MeshRenderer>().material = matCyan;
                MyColor = "Cyan";
                return;
            }
            if (Pool2.GetComponent<PoolController>().myColor == "Green")
            {
                this.GetComponent<MeshRenderer>().material = matGreen;
                MyColor = "Green";
                return;
            }
            if (Pool2.GetComponent<PoolController>().myColor == "Default")
            {
                this.GetComponent<MeshRenderer>().material = matGreen;
                MyColor = "Green";
                return;
            }
        }

    }
}
