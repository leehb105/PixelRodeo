using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//나에게 닿으면 모두 없앤다.
public class DestroyZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //다른 물체가 닿으면 없앤다
    private void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
