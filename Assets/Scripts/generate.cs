using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class generate : MonoBehaviour {

    public GameObject player;
    public GameObject block;
    public GameObject breakable;
    public GameObject platform;
    private float y;
    private int height;
    private float offsetx;
    private float offsety;
    public int platStartX;
    public int platStartY;
    public GameObject normalWalls;
    public GameObject caveWalls;
    public int layers = 12;
    public GameObject Metroid;
    public GameObject Frog;
    public GameObject Worm;
    public GameObject Bat;
    public GameObject Turtle;
    public GameObject Crawler;
    public GameObject Snail;
    public GameObject Player;
    private List<int> CaveLocations = new List<int>();

    // Use this for initialization
    void Start() {
        if (GameObject.Find("Player") == null)
        {
            GameObject player = Instantiate(Player, new Vector3(5f, 54f, 5f), new Quaternion());
        }   


        int numberOfCaves = Random.Range(2, 4); 
        int tryCaveSpot;
        
        for (int numberOfCavesTemp = numberOfCaves; numberOfCavesTemp >= 0; numberOfCavesTemp--) //place 2 to 3 caves at least one layer apart from each other, randomly
        {
            do {
                tryCaveSpot = Random.Range(1, layers); //should +1 be there?
                //print(tryCaveSpot);
                //print(!(!CaveLocations.Contains(tryCaveSpot) && !CaveLocations.Contains(tryCaveSpot + 1) && !CaveLocations.Contains(tryCaveSpot - 1)));

            } while (!(!CaveLocations.Contains(tryCaveSpot) && !CaveLocations.Contains(tryCaveSpot + 1) && !CaveLocations.Contains(tryCaveSpot - 1)));
            CaveLocations.Add(tryCaveSpot);
        }

        for (var y = 0; y >= layers * -18; y -= 18) //third param (y-=) controls frequency of layers
        {
            // PROTIP: using Random.Range for integers has the min as inclusive and max as exclusive

            offsetx = Random.Range(0f, 999999f);
            offsety = Random.Range(0f, 999999f);
            int solid = Random.Range(1, 3);
            int platforms = Random.Range(1, 4);
            int enemies = Random.Range(1, 3);
            int doubleEnemies = Random.Range(1, 2);
            int tripleEnemies = Random.Range(1, 4);
            int cave = Random.Range(1, 7);
            int workingLayer = y / -18;
            int numOfEnemies = 0;
            //print(workingLayer);

            if (enemies == 2)
            {
                if(doubleEnemies==1)
                {
                    if (tripleEnemies == 1)
                        numOfEnemies++;
                    numOfEnemies++;
                }
                numOfEnemies++;
            }

            //if (cave != 1)
            if (!(CaveLocations.Contains(workingLayer)))
            {
                //print(cave + " spawned reg");
                Instantiate(normalWalls, new Vector3((float)5, y, (float)5), new Quaternion(), this.transform);

                for (var x = 0.5f; x <= 9.5f; x++) //place 8 (9?) rows
                {
                    for (var z = 0.5f; z <= 9.5f; z++) //place 8 (9?) blocks making a row
                    {
                        height = (int)(Mathf.PerlinNoise((x + offsetx) / 5.5f, (z + offsety) / 5.5f) * 4); //make dirt from perlin noise
                        for (var heightgen = 1; heightgen <= height; heightgen++)
                        {
                            if (solid == 1 && height == 1) //should the bottom layer be solid or breakable
                            {
                                Instantiate(block, new Vector3((float)x, y + heightgen - 3, (float)z), new Quaternion(), this.transform);
                            }
                            else
                            {
                                Instantiate(breakable, new Vector3((float)x, y + heightgen - 3, (float)z), new Quaternion(), this.transform);
                            }
                        }
                    }
                }

                for(int en = 0; en < numOfEnemies + 1;en++) {
                    int enemytype = Random.Range(1, 8);
                    switch (enemytype)
                    {
                        case (1):
                            Instantiate(Metroid, new Vector3(Random.Range((float)0, (float)10), y + 3, Random.Range((float)0, (float)10)), new Quaternion(), this.transform);
                            break;
                        case (2):
                            Instantiate(Frog, new Vector3(Random.Range((float)0, (float)10), y + 3, Random.Range((float)0, (float)10)), new Quaternion(), this.transform);
                            break;
                        case (3):
                            Instantiate(Worm, new Vector3(Random.Range((float)0, (float)10), y + 3, Random.Range((float)0, (float)10)), Quaternion.Euler(0, Random.Range(0,4)*90, 0), this.transform);
                            break;
                        case (4):
                            Instantiate(Bat, new Vector3(Random.Range((float)0, (float)10), y + 3, Random.Range((float)0, (float)10)), new Quaternion(), this.transform);
                            break;
                        case (5):
                            Instantiate(Turtle, new Vector3(Random.Range((float)0, (float)10), y + 3, Random.Range((float)0, (float)10)), Quaternion.Euler(0, Random.Range(0, 4) * 90, 0), this.transform);
                            break;
                        case (6):
                            Instantiate(Crawler, new Vector3(Random.Range((float)0, (float)10), y + Random.Range(3,9), Random.Range((float)0, (float)10)), Quaternion.Euler(0, Random.Range(0, 2) * 180, 0), this.transform);
                            break;
                        case (7):
                            Instantiate(Snail, new Vector3(Random.Range((float)0, (float)10), y + Random.Range(3, 9), Random.Range((float)0, (float)10)), Quaternion.Euler(0, Random.Range(0, 2) * 180, 0), this.transform);
                            break;
                    }
                }

                if (platforms >= 3) //spawn platforms
                {
                    platStartX = Random.Range(0, 7);
                    platStartY = Random.Range(0, 7);

                    for (var x = platStartX; x <= platStartX + 3; x++)
                    {
                        for (var z = platStartY; z <= platStartY + 3; z++)
                        {
                            Instantiate(platform, new Vector3((float)x+.5f, y + 5, (float)z+.5f), new Quaternion(), this.transform);
                        }
                    }
                    if (platforms == 3)
                    {
                        platStartX = Random.Range(0, 7);
                        platStartY = Random.Range(0, 7);

                        for (var x = platStartX; x <= platStartX + 3; x++)
                        {
                            for (var z = platStartY; z <= platStartY + 3; z++)
                            {
                                Instantiate(platform, new Vector3((float)x+.5f, y + 11, (float)z+.5f), new Quaternion(), this.transform);
                            }
                        }
                    }
                }
            }
            else
            {
                //print(cave + " spawned cave");
                Quaternion rot = Quaternion.Euler(0, Random.Range(1, 4) * 90f, 0); //rotate cave to make it interesting
                Instantiate(caveWalls, new Vector3((float)5, y, (float)5), rot, this.transform);
            }
        }
        Instantiate(normalWalls, new Vector3((float)5, (layers + 1) * -18, (float)5), new Quaternion(), this.transform); //add one at the bottom
    }

    // Update is called once per frame
    void Update() {

    }
}