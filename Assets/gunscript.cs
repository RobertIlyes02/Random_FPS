using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
    public float weaponrange = 50f;
    public Camera fpsCam;
    private LineRenderer laserLine;
    private AudioSource shootingsound;
    private bool shooting = false;
    public float shottimer = 0.01f;
    private bool shotallowed = true;
    private float lastshot = 0f;
    //private Vector3[] recoil = new[] {new Vector }  

    // Start is called before the first frame update
    void Start()
    {
        shootingsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
        Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponrange, Color.green);

        if (Input.GetMouseButton(0) && Time.time > lastshot + shottimer)
        {
            //Debug.Log("shot"); 
            //FireOneShot();
            lastshot = Time.time;
        } 

    }

    void FireOneShot()
    {
        shotallowed = false;
        shootingsound.Play();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 50))
        {
            Debug.Log("hit");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green, 50f);
        }
        else
        {
            Debug.Log("missed");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red, 50f);
        }
        shotallowed = true; 
    }
}
