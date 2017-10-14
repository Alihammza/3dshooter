using System.Collections;
using UnityEngine;

public class Globalflock : MonoBehaviour {
    public GameObject fishPrefab;

    public static int tankSize = 20;
    static int numFish = 20;
    public static GameObject[] allFish = new GameObject[numFish];
    public static float[] lifeTime = new float[numFish];
    static int offset = 30;

    public static Vector3 goalPos = Vector3.zero;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < numFish; i++)
        {
            Vector3 pos = getRandomPos();
            //allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Random.rotation);
            lifeTime[i] = Random.RandomRange(4, 7);
        }

    }

    private static Vector3 getRandomPos()
    {
        return new Vector3(Random.Range(-tankSize, tankSize),
                                  Random.Range(-tankSize, tankSize),
                                  Random.Range(-tankSize + offset, +tankSize + offset));
    }

    // Update is called once per frame
    void Update () {
        float dt = Time.deltaTime;
        for (int i = 0; i < numFish; i++)
        {
            lifeTime[i] -= dt;
            if (lifeTime[i] <= 0)
            {
                lifeTime[i] = Random.Range(4, 7);
                allFish[i].transform.position = getRandomPos();
            }
        }
	}
}
