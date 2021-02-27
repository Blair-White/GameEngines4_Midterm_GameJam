using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//This Script is copied directly from character.move on unity website.
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public GameObject brush, brushStick;
    private Animator brushAnimator;
    public Material matRed, matGreen, matBlue;
    public string BrushColor;
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField]
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    private InputManager inputManager;
    private Transform cameraTransform;
    //talent bools
    private void Start()
    {

        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
        brushAnimator = brushStick.GetComponent<Animator>();
    }


    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (inputManager.PlayerJumped() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


    }

    private void PoolInteracted()
    {
        brushAnimator.SetBool("isActive", true);
    }
    private void Interacted(string color)
    {
        BrushColor = color;
        brushAnimator.SetBool("isActive", true);
        switch (color)
        {
            case "Blue":
                brush.GetComponent<MeshRenderer>().material = matBlue;
                break;
            case "Red":
                brush.GetComponent<MeshRenderer>().material = matRed;
                break;

            case "Green":
                brush.GetComponent<MeshRenderer>().material = matGreen;
                break;
               
            default:
                break;
        }

     
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "EndGamePortal")
        {
            other.SendMessage("Entered");
        }
    }
}
