using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketController : MonoBehaviour
{
    private bool isInRange = false;
    public GameObject InteractionText;
    public Material myMaterial;
    private GameObject mPlayer;
    public string myColor;
    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.Find("Player");
        this.GetComponent<MeshRenderer>().material = myMaterial;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isInRange)
        {
            if(Vector3.Distance(this.transform.position, mPlayer.transform.position)<5.0f)
            {
                EnteredRange();
            }
        }
        if(isInRange)
        {
            if (Vector3.Distance(this.transform.position, mPlayer.transform.position) > 6.0f)
            {
                LeftRange();
            }
            if(InputManager.Instance.Interacted())
            {
                mPlayer.SendMessage("Interacted", myColor, SendMessageOptions.RequireReceiver);
            }
        }

    }

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

}
