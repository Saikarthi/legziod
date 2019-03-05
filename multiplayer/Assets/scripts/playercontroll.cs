

using UnityEngine;
[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(playermotor))]
public class  playercontroll : MonoBehaviour
{

  
    public float speed = 5f;

    public playermotor motor;
    private float look = 3f;
    [SerializeField]
    private float thrusterforce = 1000f;
    [Header("Spring :")]
    [SerializeField]
    private JointDriveMode jointmode =JointDriveMode.Position;
    [SerializeField]
    private float jointspring = 20f;
    [SerializeField]
    private float jointmaxforce = 40f;
    private ConfigurableJoint joint;



    private void Start()
    {
        motor = GetComponent<playermotor>();
        joint = GetComponent<ConfigurableJoint>();
        setjoint(jointspring);
    }




    void Update()
    { //movements input
        float _xmov = Input.GetAxisRaw("Horizontal");

        float _zmov = Input.GetAxisRaw("Vertical");



        Vector3 _movhor = transform.right * _xmov;
        Vector3 _movver = transform.forward * _zmov;

        Vector3 _velocity = (_movhor + _movver).normalized * speed;

        motor.move(_velocity);
        //apply rot
        float _yrot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f,_yrot,0f) * look;

        motor.ro(_rotation);
        //apply cam rot
        float _xrot = Input.GetAxisRaw("Mouse Y");

        float _camrotationx = _xrot * look;

        motor.co(_camrotationx);
        Vector3 thu = Vector3.zero;
        //apply jump
        if (Input.GetButton("Jump"))
        {
            thu = Vector3.up * thrusterforce;
            setjoint(0f);
        }
        else
        {
            setjoint(jointspring);
        }
        motor.applythu(thu);
    }
    private void setjoint(float _jointsprint)
    {
        joint.yDrive = new JointDrive { mode = jointmode, positionSpring = jointspring, maximumForce = jointmaxforce };
    }
}

