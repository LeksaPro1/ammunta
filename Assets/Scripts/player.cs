using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    
    public float speed = 5.0f;
	
	public Transform groundCheck;
	
	public float groundDistance = 0.2f;
	
	public LayerMask groundMask;

    private float vertikaalinenPyorinta = 0;
    private float horisontaalinenPyorinta = 0;
    private float xRotation = 0f;

    public float hyppyvoima = 30f;
    public float painovoima = 5f;

    
    private bool isGrounded = true;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        CharacterController hahmokontrolleri = GetComponent<CharacterController>();
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        Vector3 nopeus = new Vector3(horizontal, 0, vertical);

        horisontaalinenPyorinta += Input.GetAxis("Mouse X") * 3;

        transform.localRotation = Quaternion.Euler(0, horisontaalinenPyorinta, 0);

        nopeus = transform.rotation * nopeus;

        

        if (Input.GetKeyDown(KeyCode.Space))
        {
			Debug.Log("hyppy");
            isGrounded = false;
            nopeus.y = nopeus.y + hyppyvoima;
            anim.SetBool("JumpU", true);
        }
        else
        {
            anim.SetBool("JumpU", false);
        }
          if (Input.GetKeyDown(KeyCode.Q))
        {
			Debug.Log("hyppy");
            isGrounded = false;
            nopeus.y = nopeus.y + hyppyvoima;
            anim.SetBool("JumpR", true);
        }
        else
        {
            anim.SetBool("JumpR", false);
        }
           if (Input.GetKeyDown(KeyCode.R))
        {
			Debug.Log("hyppy");
            isGrounded = false;
            nopeus.y = nopeus.y + hyppyvoima;
            anim.SetBool("JumpL", true);
        }
        else
        {
            anim.SetBool("JumpL", false);
        }
        nopeus.y = nopeus.y - painovoima * Time.deltaTime;
        hahmokontrolleri.Move(nopeus * Time.deltaTime);

        
        if (Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("Walk", true);
			
			if (Input.GetKeyDown("left shift"))
			{
				anim.SetBool("Run", true);
				anim.SetBool("Walk", false);
			}
        }
        else
        {
            anim.SetBool("Walk", false);
			anim.SetBool("Run",false);
        }

    }

	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
	}
	
}
