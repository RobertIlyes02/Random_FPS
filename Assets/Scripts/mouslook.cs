using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouslook : MonoBehaviour
{
    // Looking around stuff
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public Transform gun;
    float xRotation = 0f;

    // gun stuff
    public float shottimer = 0.25f;
    private bool shotallowed = true;
    private float lastshot = 0f;
    public GameObject shootingsound_object;
    private AudioSource shootingsound;

    // recoil stuff
    private Vector3 originalrotation;
    private Vector3 targetrotation;
    private Vector3 currentrotation;
    public float returnspeed;
    public float snappiness;
    private bool shooting = false;
    public float recoilx;
    public float recoily;
    public float recoilz;
    //public Gameobject reloadsound_object;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        shootingsound = shootingsound_object.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        targetrotation = Vector3.Lerp(targetrotation, Vector3.zero, returnspeed * Time.deltaTime);
        currentrotation = Vector3.Slerp(currentrotation, targetrotation, snappiness * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentrotation);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        //transform.localRotation = Quaternion.Euler(currentrotation);

        /*
        if (!shooting)
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        } else
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
            transform.localRotation = Quaternion.Euler(currentrotation);

        }
        */
        if (Input.GetMouseButton(0) && Time.time >= lastshot + shottimer)
        {
            shooting = true;
            Recoil(); 
            Fire();
            lastshot = Time.time;
        }
        else if (Time.time < lastshot + shottimer)
        {
            originalrotation = playerBody.localEulerAngles;
        }
        else
        {
            shooting = false;
        }
    }

    void Fire()
    {
        RaycastHit hit;
        shootingsound.Play();
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
    }

    void Recoil()
    {
        targetrotation += new Vector3(recoilx, Random.Range(-1f * recoily, recoily), Random.Range(-1f * recoilz, recoilz));
    }
}