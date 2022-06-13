using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GG3000 : MonoBehaviour
{
    [SerializeField]
    GameObject prefab1;
    [SerializeField]
    GameObject prefab2;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    float lerpSpeed = 2f;
    [SerializeField]
    Transform objectHolder;
    [SerializeField]
    float suckDistance;
    [SerializeField]
    int suckedCharges = 0;
    [SerializeField]
    GameObject raycastCone;
    CollidedPosition collidedPosition;
    PlankBlueprint plankBlueprint;
    [SerializeField]
    GameObject blueprintGameObject;
    

    Rigidbody grabbedRB;
    //Rigidbody suckedRB;

    private void Awake()
    {
        collidedPosition = raycastCone.GetComponent<CollidedPosition>();
        plankBlueprint = blueprintGameObject.GetComponent<PlankBlueprint>();
    }
   

    // Update is called once per frame
    void Update()
    {
        SuckFunction();

        CreateFunction();
    }

    private void CreateFunction()
    {
        // This function will move create new objects and place them in the world
        if (grabbedRB)
        {
            grabbedRB.MovePosition(Vector3.Lerp(grabbedRB.position, objectHolder.transform.position, Time.deltaTime * lerpSpeed * 10));
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && suckedCharges > 0)
        {
            
                GameObject prefab_gameobject = Instantiate(prefab, objectHolder.transform.position, Quaternion.identity);
                grabbedRB = prefab_gameobject.GetComponent<Rigidbody>();
                grabbedRB.isKinematic = true;
                suckedCharges--;
            
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && suckedCharges > 0 && plankBlueprint.plankBlueprintUnlocked == true)
        {

            GameObject prefab_gameobject = Instantiate(prefab1, objectHolder.transform.position, Quaternion.identity);
            grabbedRB = prefab_gameobject.GetComponent<Rigidbody>();
            grabbedRB.isKinematic = true;
            suckedCharges--;


        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && suckedCharges > 0)
        {

            GameObject prefab_gameobject = Instantiate(prefab2, objectHolder.transform.position, Quaternion.identity);
            grabbedRB = prefab_gameobject.GetComponent<Rigidbody>();
            grabbedRB.isKinematic = true;
            suckedCharges--;


        }
        if (Input.GetMouseButton(0) && grabbedRB)
        {
            grabbedRB.isKinematic = false;
            grabbedRB = null;
        }
    }

    private void SuckFunction()
    {
        ////This function will create the ray that will be used in multiple other functions
        if (Input.GetMouseButton(1) && collidedPosition.suckedObject != null)
        {
            collidedPosition.suckedRB.isKinematic = true;
            collidedPosition.suckedRB.MovePosition(Vector3.Lerp(collidedPosition.suckedRB.position, transform.position, Time.deltaTime * lerpSpeed));
            suckDistance = Vector3.Distance(collidedPosition.suckedRB.position, transform.position);

            if (suckDistance < 2f)
            {
                Destroy(collidedPosition.suckedObject);
                collidedPosition.suckedRB.isKinematic = false;
                suckedCharges++;
            }
        }
    }
}
