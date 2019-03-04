
using UnityEngine;
[RequireComponent(typeof(playermotor))]
public class  playercontroll : MonoBehaviour
{

  
    public float speed = 5f;

    public playermotor motor;
    private float look = 3f;



    private void Start()
    {
        motor = GetComponent<playermotor>();
    }




    void Update()
    { //movements input
        float _xmov = Input.GetAxisRaw("Horizontal");

        float _zmov = Input.GetAxisRaw("Vertical");



        Vector3 _movhor = transform.right * _xmov;
        Vector3 _movver = transform.forward * _zmov;

        Vector3 _velocity = (_movhor + _movver).normalized * speed;

        motor.move(_velocity);

        float _yrot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f,_yrot,0f) * look;

        motor.ro(_rotation);

        float _xrot = Input.GetAxisRaw("Mouse Y");

        Vector3 _camrotation = new Vector3(_xrot, 0f, 0f) * look;

        motor.co(_camrotation);
    }
}

