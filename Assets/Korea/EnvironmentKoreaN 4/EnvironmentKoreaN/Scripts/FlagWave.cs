using UnityEngine;

public class FlagWave : MonoBehaviour
{
    public float waveSpeed = 2f;     
    public float waveHeight = 0.2f;  
    public float waveLength = 2f;  
    public bool loop = true;         

    private Mesh mesh;
    private Vector3[] baseVertices;
    private Vector3[] displacedVertices;
    private float timeOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        baseVertices = mesh.vertices;
        displacedVertices = new Vector3[baseVertices.Length];
        timeOffset = Random.Range(0f, 100f);
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimateFlag();
    }
    void AnimateFlag()
    {
        for (int i = 0; i < baseVertices.Length; i++)
        {
            Vector3 vertex = baseVertices[i];

            // Move only vertices away from the "flagpole" side (assume X is width)
            float wave = Mathf.Sin((Time.time * waveSpeed + vertex.x / waveLength) + timeOffset) * waveHeight;

            vertex.z += wave; // Move along Z-axis (adjust if your flag is rotated differently)
            displacedVertices[i] = vertex;
        }

        mesh.vertices = displacedVertices;
        mesh.RecalculateNormals(); // Update lighting
    }
}
