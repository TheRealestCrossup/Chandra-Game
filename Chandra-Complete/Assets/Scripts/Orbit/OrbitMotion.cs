using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{

    public Transform orbitingObject;
    public Ellipse orbitPath;

    [Range(0f,1f)]
    public float orbitProgress;
    public float orbitPeriod = 3f;
    public bool isOrbiting = true;



    // Start is called before the first frame update
    void Start()
    {

        if (orbitingObject == null)
        {
            isOrbiting = false;
            return;
        }

        SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit()); 
         

    }

    void SetOrbitingObjectPosition() {
        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
        orbitingObject.localPosition = new Vector3(orbitPos.x, 0f, orbitPos.y );
    }

    IEnumerator AnimateOrbit() {
        if(orbitPeriod < 0.1f) {
            orbitPeriod = 0.1f; 
        }
        float orbitSpeed = 1f / orbitPeriod;

        while(isOrbiting) {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            SetOrbitingObjectPosition();
            yield return null; 
        }
         
    }
}
