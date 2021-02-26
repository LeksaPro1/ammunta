using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{

    public float eteenpain_nopeus = 1.0f;

    string suunta = "eteenpain";

    private float horisontaalinenPyorinta = 0;

    int layer_index;
    //public LayerMask includeLayers;
    public LayerMask wallMask;
    // Start is called before the first frame update
    void Start()
    {
        layer_index = LayerMask.GetMask("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController hahmokontrolleri = GetComponent<CharacterController>();
        Vector3 nopeus = new Vector3(0, 0, eteenpain_nopeus);

        transform.localRotation = Quaternion.Euler(0, horisontaalinenPyorinta, 0);

        nopeus = transform.rotation * nopeus;

        hahmokontrolleri.SimpleMove(nopeus);
    }

    void OnTriggerEnter(Collider other)
    {
        print("osui");
        if (other.gameObject.layer == layer_index)
        {
            print("osui seinaan");
        }
        if (other.gameObject.tag == "seina")
        {
            print("osui seina ykkoseen");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        int kaannos = 0;
        kaannos = Random.Range(90, 270);

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            horisontaalinenPyorinta += kaannos;
        }
    }





    public void stop_zombie_1()
    {
        eteenpain_nopeus = 0f;
    }


}
