using UnityEngine;
using UnityEngine.Tilemaps;

public class PerlinNoiseScriptCaveGeneration : MonoBehaviour
{
    public Tilemap CaveTilemap; //tilemap for cave
    public TileBase Tile; //copied sprite
    public float width = 100f; //width of map
    public float length = 100f; //length of map
    public float NoiseControl = 0.05f; //controls cave smooth
    public float Threshold = 0.5f; //controls size of caverns

    private float seed; //the way to get a randomly generated map each time
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        seed = Random.Range(0, 100); //randomizes seed
        CaveGenerater();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CaveGenerater()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < length; y++)
            {
                //randomizes perlin value
                float PerlinValue = Mathf.PerlinNoise((x + seed) * NoiseControl, (y + seed) * NoiseControl);


                if (PerlinValue > Threshold)
                {
                    //places Tile at the randomized position
                    CaveTilemap.SetTile(new Vector3Int(x, y, 0), Tile);
                }
            }
        }
    }
}
