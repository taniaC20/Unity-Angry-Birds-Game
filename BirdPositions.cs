using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPositions : MonoBehaviour
{
    public Bird[] _birds;
    // Start is called before the first frame update
    private void OnEnable(){
        _birds = FindObjectsOfType<Bird>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
