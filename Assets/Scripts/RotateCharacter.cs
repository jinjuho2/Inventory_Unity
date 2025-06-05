using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateCharacter : MonoBehaviour , IDragHandler , IEndDragHandler
{
    public GameObject character;
    private float rotateSpeed = 5f;
    private Vector3 rot;
    private Vector3 origin;

    void Start()
    {
        rot = character.transform.localEulerAngles; // 캐릭터 로컬 각도
        origin = rot;

    }

    public void OnDrag(PointerEventData eventData)
    {
        rot.y += Input.GetAxis("Mouse X") * rotateSpeed ;
        character.transform.localEulerAngles = -rot;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        character.transform.localEulerAngles = origin;
    }

}
