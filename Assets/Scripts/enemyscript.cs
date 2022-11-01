using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    public Vector3 treepos;
    private bool treefocused = true;
    public float speed = 8f;
    private Vector3 walkdirection;
    public Transform body;
    // Start is called before the first frame update
    void Start()
    {
        treepos = new Vector3(0f, 3.38f, -76.4f);
    }

    // Update is called once per frame
    void Update()
    {
        walkdirection = (treepos - body.position).normalized;
        body.Translate(walkdirection * speed * Time.deltaTime);
        //body.localRotation = Quaternion.Euler(0f, 3.38f, -76.4f);
    }
}
