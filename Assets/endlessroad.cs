using UnityEngine;

public class endlessroad : MonoBehaviour
{
    [SerializeField] Transform carTransform;
    [SerializeField] Transform otherroadTransform;
    [SerializeField] float halfLength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(carTransform.position.z>transform.position.z+halfLength+10f)
        {
            transform.position = new Vector3(0, 0, otherroadTransform.position.z + halfLength * 2);
        }
    }
}
