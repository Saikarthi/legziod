using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class playermotor : MonoBehaviour
{
    private Vector3 vel = Vector3.zero;
    public Camera cam;
    private Vector3 rot = Vector3.zero;
    private float cam1x = 0f;
    private float ccr = 0f;
    private Rigidbody rb;
    private Vector3 ap = Vector3.zero;

    [SerializeField]
    private float crl = 85f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void move(Vector3 _velo)
    {
        vel = _velo;
    }

    public void ro(Vector3 _v)
    {
        rot = _v;
    }
    public void co(float _v)
    {
        cam1x = _v;
    }
    void FixedUpdate()
    {
        //output
        pe();
        re();
        Ce();
    }
    
    public void pe()
    {
        if (vel != Vector3.zero)
        {

            rb.MovePosition(rb.position + vel * Time.deltaTime);
        }
        if(ap != Vector3.zero)
        {

            rb.AddForce(ap * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }
    public void re()
    {
        if (rot != Vector3.zero)
        {

            rb.MoveRotation(rb.rotation * Quaternion.Euler(rot));
        }
    }
    public void applythu(Vector3 _thu)
    {
        ap = _thu;
    }
    public void Ce()
    {
        if (cam != null)
        {

            //new calc for cam -+
            //we set rot and camp
            ccr -= cam1x;
            ccr = Mathf.Clamp(ccr, -crl, crl);
            //apply our rotation to tranfrom
            cam.transform.localEulerAngles = new Vector3(ccr, 0, 0);
        }
    }
}