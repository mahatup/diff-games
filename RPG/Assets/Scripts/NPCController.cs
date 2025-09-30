using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    [SerializeField]
    private GameObject _target, _NPCArmR, _NPCArmL, _NPCLegR, _NPCLegL;
    private NavMeshAgent _agent;
    private Quaternion _restRotationAR, _restRotationAL, _restRotationLR, _restRotationLL;
    [SerializeField]
    private float speedRotateArmNPC = 10f;
    private bool _onFloor;

    public enum NPCState
    {
        ChillOut,
        Friendly,
        Unfriendly,
        Agressive
    }
    [SerializeField]
    private NPCState state;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_target.transform.position);
        _restRotationAR = _NPCArmR.transform.localRotation;
        _restRotationAL = _NPCArmL.transform.localRotation;
        if(_restRotationLR.z >= 0f || _restRotationLL.z <= 0f)
        {

        }
        _restRotationLR = _NPCLegR.transform.localRotation;
        _restRotationLL = _NPCLegL.transform.localRotation;
    }
    void Update()
    {

        switch (state)
        {
            case NPCState.ChillOut:
                ChillOut(); break;
            case NPCState.Friendly:
                Friendly(); break;
            case NPCState.Unfriendly:
                Unfriendly(); break;
            case NPCState.Agressive:
                Agressive(); break;
            default:
                ChillOut(); break;
        }

    }
    void ChillOut()
    {
        float angle = Mathf.Sin(Time.time * speedRotateArmNPC) * 35f;

        _NPCArmR.transform.localRotation = _restRotationAR * Quaternion.Euler(0, 0, angle);
        _NPCArmL.transform.localRotation = _restRotationAL * Quaternion.Euler(0, 0, -angle);
        _NPCLegR.transform.localRotation = _restRotationLR * Quaternion.Euler(0, 0, angle);
        _NPCLegL.transform.localRotation = _restRotationLL * Quaternion.Euler(0, 0, -angle);
        if (_onFloor = false)
        {

            _onFloor = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        _onFloor = false;
        _NPCArmR.transform.localRotation = Quaternion.Lerp(_NPCArmR.transform.localRotation, _restRotationAR, 10f);
        _NPCArmL.transform.localRotation = Quaternion.Lerp(_NPCArmL.transform.localRotation, _restRotationAL, 10f);
    }

    void Friendly()
    {
        return;
    }
    void Unfriendly()
    {
        return;
    }
    void Agressive()
    {
        _agent.SetDestination(_target.transform.position);
    }
}
