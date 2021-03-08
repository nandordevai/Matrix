using UnityEngine;

public class Matrix : MonoBehaviour
{
    public Transform cube;
    public Vector3 cameraRotation;
    public float spacing = 5f;
    public float scale = .25f;
    public int n = 25;
    public float speed = 0.02f;

    void Start()
    {
        cameraRotation.x = 0.3F;
        cameraRotation.y = 0.2F;
        cameraRotation.z = 0.1F;
        cube.transform.localScale = new Vector3(scale, scale, scale);
        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < n; y++)
            {
                for (int z = 0; z < n; z++)
                {
                    Instantiate(
                        cube, 
                        new Vector3(
                            x - (n / 2), 
                            y - (n / 2), 
                            z - (n / 2)
                        ) * spacing, 
                        Quaternion.identity
                    );
                }
            }
        }
        transform.position = new Vector3(0, 0, 0);
    }
    void Update()
    {
        transform.localEulerAngles = cameraRotation * Time.frameCount;
        transform.position += Vector3.forward * Mathf.Sin(Time.frameCount / 100) * speed;
        transform.position += Vector3.up * Mathf.Cos(Time.frameCount / 100) * speed;
    }
}