using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public static Player_controller instance;
    public Rigidbody2D theRB;

    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;

    public Camera viewCam;

    public GameObject bulletimpact;

    public int CurrentAmmo;

    private void Awake() 
    {
        instance = this;
    }

    public Animator gunAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveHorizontal = transform.up *  moveInput.x;
        Vector3 moveVertical = transform.right *  -moveInput.y;
        theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;

        //player view
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);
        viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f,-mouseInput.y, 0f));


        //shooting

        if(Input.GetMouseButtonDown(0))
        {   
            if(CurrentAmmo>0)
            {
                Ray ray = viewCam.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    Instantiate(bulletimpact, hit.point, transform.rotation);
                }
                else
                {

                }
                CurrentAmmo--;
                gunAnim.SetTrigger("Shoot");
            }
            
        }
    }
}
