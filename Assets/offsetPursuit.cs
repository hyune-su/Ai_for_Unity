using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class offsetPursuit : MonoBehaviour
{

    public Transform target = null;
    public GameObject target_GameObject = null;

    public float _maxSpeed_offset = 1.0f;
    public float speed = 1.0f;
    public float distance_wall = 5.0f;
    public float wall_speed = 0;
    public float Mass = 15;

    private int count = 0;

    public bool is_Reader;

    public Vector3 offsetPos_to_target = new Vector3(0.0f, 0.0f, 0.0f);

    private float target_speed = 0.0f;

    public Vector3 _velocity = Vector3.zero;
    private Vector3 target_velocity = Vector3.zero;
    private Vector3 offsetDis_from_target = Vector3.zero;
    private Vector3 targetLength = Vector3.zero;
    private Vector3 offsetPos = Vector3.zero;
    private Vector3 wall_velocity = Vector3.zero;

    public Node[] Reader_Node = new Node[30];

    private RaycastHit hit_3;
    private RaycastHit hit_4;
    private RaycastHit hit_5;

    private float LookAheadTime = 0.0f;

    private void Start()
    {
        target_speed = target_GameObject.GetComponent<PlayerMgr>()._maxSpeed;
        target_velocity = target_GameObject.GetComponent<PlayerMgr>()._velocity;
        Reader_Node = target_GameObject.GetComponent<PlayerMgr>().target_Node;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //클릭하면 카운트 초기화 및 리더가 계산한 경로 노드를 받아 옴

            count = 0;

            Reader_Node = target_GameObject.GetComponent<PlayerMgr>().target_Node;
        }
        offsetPos = target.TransformPoint(offsetPos_to_target);

        offsetDis_from_target = offsetPos - transform.position;

        LookAheadTime = offsetDis_from_target.magnitude / (target_speed + _maxSpeed_offset);

        //원래 오프셋의 코드
        //_velocity = _velocity + (Arrive(offsetPos + (target_velocity * LookAheadTime)) * Time.deltaTime);

        //리더가 false(리더의 경로 노드를 사용하지 않는 경우)일 때는 리더를 따라서 오프셋 이동을 함
        if (!is_Reader)
        {
            _velocity = _velocity + (Arrive(offsetPos + (target_velocity * LookAheadTime)) * Time.deltaTime);
            //Wall_Avoidance();
        }
        else
        {
            //리더에게서 받아온 노드들을 따라서 이동함
            if (target_GameObject.GetComponent<PlayerMgr>().target_Node[count] != null)
            {
                _velocity = _velocity + (Seek(target_GameObject.GetComponent<PlayerMgr>().target_Node[count].transform.position) * Time.deltaTime);

                if ((target_GameObject.GetComponent<PlayerMgr>().target_Node[count].transform.position - transform.position).magnitude <= 0.2f)
                {
                    //해당 노드를 향한 벡터를 0으로 만들어 주고 새로운 벡터값을 주는 방식
                    _velocity = Vector3.zero;

                    count++;
                }
            }
            //마지막 노드까지 이동을 했다면 리더의 상대적 위치에 오프셋 하도록 함
            else
            {
                _velocity = _velocity + (Arrive(offsetPos + (target_velocity * LookAheadTime)) * Time.deltaTime);
            }
        }

        if (_velocity != Vector3.zero)
        {
            transform.position = transform.position + _velocity;
            transform.forward = _velocity.normalized;
        }
    }

    private Vector3 Seek(Vector3 target_pos)
    {
        Vector3 desired_velocity_1 = ((target_pos - transform.position).normalized) * _maxSpeed_offset;

        desired_velocity_1.y = 0.0f;

        return (desired_velocity_1 - _velocity);
    }

    private Vector3 Wall_Avoidance()
    {
        hit_3.distance = distance_wall;
        hit_4.distance = distance_wall;
        hit_5.distance = distance_wall;

        Ray raycast_forward = new Ray();
        Ray raycast_right = new Ray();
        Ray raycast_left = new Ray();

        raycast_forward.origin = transform.position;
        raycast_right.origin = transform.position;
        raycast_left.origin = transform.position;

        raycast_forward.direction = transform.forward;
        raycast_right.direction = transform.forward + transform.right;
        raycast_left.direction = transform.forward - transform.right;

        Debug.DrawLine(transform.position, transform.position + raycast_forward.direction * hit_3.distance, Color.red);
        Debug.DrawLine(transform.position, transform.position + raycast_right.direction * hit_4.distance, Color.red);
        Debug.DrawLine(transform.position, transform.position + raycast_left.direction * hit_5.distance, Color.red);

        if (Physics.Raycast(raycast_forward, out hit_3, hit_3.distance))
        {
            if (hit_3.collider.tag == "Wall" || hit_3.collider.tag == "Tower")
            {
                if (Physics.Raycast(raycast_forward, out hit_3, hit_3.distance * 3))
                    wall_speed = ((raycast_forward.direction * hit_3.distance * 3) - hit_3.transform.position).magnitude;

                wall_velocity = hit_3.normal * (wall_speed / Mass);

                wall_velocity.y = 0;

                _velocity = _velocity + wall_velocity;
            }
        }
        if (Physics.Raycast(raycast_right, out hit_4, hit_4.distance))
        {
            if (hit_4.collider.tag == "Wall" || hit_4.collider.tag == "Tower")
            {
                if (Physics.Raycast(raycast_forward, out hit_3, hit_3.distance * 3))
                    wall_speed = ((raycast_forward.direction * hit_3.distance * 3) - hit_3.transform.position).magnitude;

                wall_velocity = hit_4.normal * (wall_speed / Mass);

                wall_velocity.y = 0;

                _velocity = _velocity + wall_velocity;
            }
        }
        if (Physics.Raycast(raycast_left, out hit_5, hit_5.distance))
        {
            if (hit_5.collider.tag == "Wall" || hit_5.collider.tag == "Tower")
            {
                if (Physics.Raycast(raycast_forward, out hit_3, hit_3.distance * 3))
                    wall_speed = ((raycast_forward.direction * hit_3.distance * 3) - hit_3.transform.position).magnitude;

                wall_velocity = hit_5.normal * (wall_speed / Mass);

                wall_velocity.y = 0;

                _velocity = _velocity + wall_velocity;
            }
        }

        return _velocity;
    }

    private Vector3 Arrive(Vector3 target_pos)
    {
        Vector3 targetVelocity = target_pos - transform.position;

        float dist = targetVelocity.magnitude;

        if (dist > 40.0f)
        {
            speed = _maxSpeed_offset;
        }
        else
        {
            speed = _maxSpeed_offset * (dist / 40.0f);
        }

        targetVelocity.Normalize();
        targetVelocity *= speed;

        Vector3 acceleration = targetVelocity - _velocity;

        acceleration *= 1 / 0.1f;

        if (acceleration.magnitude > 15.0f)
        {
            acceleration.Normalize();
            acceleration *= 5.0f;
        }

        speed = Mathf.Min(speed, _maxSpeed_offset);

        return acceleration;
    }
}


