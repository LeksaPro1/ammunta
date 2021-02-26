using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammu : MonoBehaviour
{
    Camera FPSCamera;

    public float throwForce = 10f;
    public GameObject throwObjPrefab;
    private GameObject ammus = null;

    public LineRenderer Ir;

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        FPSCamera = Camera.main;

        if (gameObject.CompareTag("laserase"))
        {

            Ir.enabled = false;

        }

    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && gameObject.CompareTag("ase"))
        {
            Throw();

        }
        if (Input.GetButtonDown("Fire2") && gameObject.CompareTag("laserase"))
        {
            //Laser();
            StartCoroutine(Laser());
        }
    }

    public void Throw()
    {

        ammus = Instantiate(throwObjPrefab, transform.position, Quaternion.identity);
        ammus.GetComponent<Rigidbody>().AddForce(FPSCamera.transform.forward * throwForce, ForceMode.Impulse);
    }

    public IEnumerator Laser()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            Ir.SetPosition(0, transform.position);
            Ir.SetPosition(1, hit.point);

            if (hit.collider.gameObject.name == "Zombie1")
            {

                anim.SetBool("ammuttu", true);
                hit.collider.gameObject.GetComponent<zombie>().eteenpain_nopeus = 0;
               }

            Rigidbody rb = hit.collider.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(FPSCamera.transform.forward * 100, ForceMode.Impulse);
            }


        }

        Ir.enabled = true;
        yield return new WaitForSecondsRealtime(2.6f);
        Ir.enabled = false;


    }
}
