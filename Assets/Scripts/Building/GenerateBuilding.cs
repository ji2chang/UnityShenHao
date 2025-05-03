using UnityEngine;


public class GenerateBuilding : MonoBehaviour
{
    float height = 4.80f;
    public GameObject building;
    void Start()
    {
        Generate();
    }

    void Generate(){
        Instantiate(building, new Vector3(0, height, 0), Quaternion.identity);
        Instantiate(building, new Vector3(5, height, 0), Quaternion.identity);
        Instantiate(building, new Vector3(10, height, 0), Quaternion.identity);  
        Instantiate(building, new Vector3(15, height, 0), Quaternion.identity);
        Instantiate(building, new Vector3(20, height, 0), Quaternion.identity);
        Instantiate(building, new Vector3(0, height, 10), Quaternion.identity);
        Instantiate(building, new Vector3(5, height, 10), Quaternion.identity);
        Instantiate(building, new Vector3(10, height, 10), Quaternion.identity);
        Instantiate(building, new Vector3(15, height, 10), Quaternion.identity);
        Instantiate(building, new Vector3(20, height, 10), Quaternion.identity);
        Instantiate(building, new Vector3(0, height, 20), Quaternion.identity);
        Instantiate(building, new Vector3(5, height, 20), Quaternion.identity);
        Instantiate(building, new Vector3(10, height, 20), Quaternion.identity);
    }

}
