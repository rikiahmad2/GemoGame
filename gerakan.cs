using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class gerakan : MonoBehaviour {
   

    //inisialisasi
    bool jump = false;
    public float jumpforce = 100f;
    float jeda = 0f;
    private Rigidbody2D m_Rigidbody2D;
    float gerak = 0f;
    public float movementS = 10f;
    public Transform target;
    public bool FacingRight = true;
    void Start()
    {
        //mendapatkan rigidbody
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //meemberi nilai gerakan pada sumbu X
        gerak = Input.GetAxis("Horizontal") * movementS;
        if(gerak > 0 && !FacingRight || gerak < 0 && FacingRight)
        {
            FlipPlayer();
        }
    }

    void FixedUpdate () {

        //jeda melompat dikurangi dengan waktu update per frame
        jeda -= Time.deltaTime;

        //input button
        if (Input.GetButtonDown("Jump"))
        {
            if (jeda < 0)
            {
                //memberi dorongan pada sumbu Y menggunakan addforce
                jump = true;
                m_Rigidbody2D.AddForce(new Vector2(0f, jumpforce));
                jeda = 1.5f;
            }
        }

        //memberi dorongan pada object di sumbu x menggunakan velocity
        Vector2 velocity = m_Rigidbody2D.velocity;
        velocity.x = gerak;
        m_Rigidbody2D.velocity = velocity;
    }

    //mengubah posisi objek
    void FlipPlayer()
    {

           FacingRight = !FacingRight;

            //mengubah nilai local scale
            Vector3 theScale = target.localScale;
            theScale.x *= -1;
            target.localScale = theScale;
        
    }

}
