using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public float speed;
    public float jump;
    private Vector3 movement;
    private Rigidbody rb;
    public GameObject bullet;
    public GameObject follower;
    public bool isgrounded;
    private float bulletDelay;
    public float bulletJump;
    public float jumpBulletDelay;
    private float nextBullet;
    public bool murder;
    Vector3 v;
    public Material colour;
    public bool hurt;
    public int bulletCounter;
    public int bulletMax;
    private float invinEnd;
    private float invinLength = 3;
    public int health;
    private bool invin;
    public int maxHealth;
    Renderer rend;
    RaycastHit belowPlayer;
    public int combo;
    public float invinFlashInterval;
    private float invinFlashNext;
    public int gems;
    public string currentGun;
    private int bulletBunches = 0;
    private int bunchProgress = 0;
    private float bunchGroupingDelay;
    private float nextBunch;
    private int bulletsAtATime = 1;
    private int bulletsAtATimeProgress = 0;
    private float bulletAngle = 0;
    private int bulletGridWidth = 3;
    private int bulletGridLength = 3;
    public float shotgunSpread = 1;
    private bool shotgunType = false;
    public GameObject laser;
    private bool laserType = false;
    private bool noppyType = false;
    private GameObject objectShot;
    private float bulletYOffset;
    private float rotationOffset;
    private bool tripleType;
    float randx;
    float randy;
    float randz;
    private GameObject bulletFired;
    private int fixedBulletCost;
    public int bonusHealth;
    public int area;
    public int level;

    public void healthUp(int healthUpAmount = 1) {
        health+=healthUpAmount;
        if (health>maxHealth) {
            bonusHealth += health - maxHealth;
            health = maxHealth;
        }
        if (bonusHealth>4) {
            maxHealth++;
            bonusHealth=0;
        }
    }

    public void levelUp()
    {
        print("levelup");
        level++;
        if (level> 3)
        {
            area++;
            level = 1;
        }
    }

    public void gunChange(string toGunType)
    {
        currentGun = toGunType;

        switch (toGunType)
        {
            //defining properties of each guns; abilities and limitations, i could probably dedicate a seperate file to this section
            case "Machine Gun": //base gun, i'll explain what each property does
                bulletDelay = 0.35f; //delay between a group of bullets
                bulletBunches = 0; //0 for no vertical groupings, positive int for the number of bullets in a vertical group
                bunchGroupingDelay = 0f; //vertical spacing between a group of bullets
                bulletAngle = 0; //angle bullets are to be shot at, 0 is straight
                bulletsAtATime = 1; //amount of bullets to be shot per vertical spacing, each spacing has this amount shot all at once
                 //wether or not bullets are spawned in a grid, i may have removed this, can't remember
                bulletGridWidth = 0; 
                bulletGridLength = 0;
                shotgunType = false; //wether or not to use a shotgun pattern
                shotgunSpread = 0; 
                laserType = false; //false= use bullets, true = use lasers instead
                noppyType = false; //should the bullets tilt as you move?
                bunchProgress = 0; //don't modify this, should all be at one
                tripleType = false; //should it evenly rotate all bulletsAtATime?
                fixedBulletCost = 0; //0=price is per bullet, any integer ignores bullet amount and assigns a fixed amount to be subtracted from ammo
                break;
            case "Burst":
                bulletDelay = .6f;
                bulletBunches = 3;
                bunchGroupingDelay = .1f;
                bulletAngle = 0;
                bulletsAtATime = 1;
                bulletGridWidth = 0;
                bulletGridLength = 0;
                shotgunType = false;
                shotgunSpread = 0;
                laserType = false;
                noppyType = false;
                bunchProgress = 1;
                tripleType = false;
                fixedBulletCost = 0;
                break;
            case "Triple":
                bulletDelay = 0.35f;
                bulletBunches = 0;
                bunchGroupingDelay = 0f;
                bulletAngle = 20;
                bulletsAtATime = 3;
                bulletGridWidth = 0;
                bulletGridLength = 0;
                shotgunType = false;
                shotgunSpread = 0;
                laserType = false;
                noppyType = false;
                bunchProgress = 0;
                tripleType = true;
                fixedBulletCost = 0;
                break;
            case "Puncher":
                bulletDelay = 0.6f;
                bulletBunches = 0;
                bunchGroupingDelay = 0f;
                bulletAngle = 0;
                bulletsAtATime = 1;
                bulletGridWidth = 3;
                bulletGridLength = 3;
                shotgunType = false;
                shotgunSpread = 0;
                laserType = false;
                noppyType = false;
                bunchProgress = 0;
                tripleType = false;
                fixedBulletCost = 3;
                break;
            case "Shotgun":
                bulletDelay = 0.7f;
                bulletBunches = 0;
                bunchGroupingDelay = 0f;
                bulletAngle = 0;
                bulletsAtATime = 7;
                bulletGridWidth = 0;
                bulletGridLength = 0;
                shotgunType = true;
                shotgunSpread = 1;
                laserType = false;
                noppyType = false;
                bunchProgress = 0;
                tripleType = false;
                fixedBulletCost = 5;
                break;
            case "Laser":
                bulletDelay = 0.35f;
                bulletBunches = 0;
                bunchGroupingDelay = 0f;
                bulletAngle = 0;
                bulletsAtATime = 1;
                bulletGridWidth = 0;
                bulletGridLength = 0;
                shotgunType = false;
                shotgunSpread = 0;
                laserType = true;
                noppyType = false;
                bunchProgress = 0;
                tripleType = false;
                fixedBulletCost = 0;
                break;
            case "Noppy":
                bulletDelay = 0.35f;
                bulletBunches = 0;
                bunchGroupingDelay = 0f;
                bulletAngle = 0;
                bulletsAtATime = 1;
                bulletGridWidth = 0;
                bulletGridLength = 0;
                shotgunType = false;
                shotgunSpread = 0;
                laserType = false;
                noppyType = true;
                bunchProgress = 0;
                tripleType = false;
                fixedBulletCost = 0;
                break;
            case "Nuke":
                bulletDelay = 0.1f;
                bulletBunches = 3;
                bunchGroupingDelay = .1f;
                bulletAngle = 5;
                bulletsAtATime = 10;
                bulletGridWidth = 5;
                bulletGridLength = 5;
                shotgunType = true;
                shotgunSpread = 3;
                laserType = true;
                noppyType = false;
                bunchProgress = 0;
                tripleType = false;
                fixedBulletCost = -1;
                break;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextBullet = Time.time;
        v = rb.velocity;
        bulletMax = 8;
        bulletCounter = 8;
        invin = false;
        maxHealth = 4;
        health = maxHealth;
        rend = GetComponent<Renderer>();
        combo = 0;
        gems = 0;
        bonusHealth = 0;
        gunChange("Machine Gun");
        area = 1;
        level = 1;
        DontDestroyOnLoad(this.transform.parent);
        follower = GameObject.Find("CameraFocus");
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {

        movement.Set(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        movement.y = 0.0f;
        //print(Input.GetAxis("Horizontal") * speed);
        v.x = Input.GetAxis("Horizontal") * 13.6f;
        v.z = Input.GetAxis("Vertical") * 13.6f;
        v.y = rb.velocity.y;
        rb.velocity = transform.TransformDirection(v);
        //rb.transform.Translate(movement * speed);

        // print(rb.velocity);

        var rotationVector = follower.transform.rotation.eulerAngles;
        rotationVector.x = 0;
        rotationVector.z = 0;
        rotationVector.y = Mathf.Floor(rotationVector.y / 3) * 3;
        transform.rotation = Quaternion.Euler(rotationVector);

        if (hurt)
        {

            if (!invin)
            {
                //print("OW!");
                health--;
                invinEnd = Time.time + invinLength;

                invinFlashNext = Time.time + invinFlashInterval;
                rend.enabled = false;
            }

            hurt = false;
            invin = true;
        }

        if (invin && Time.time >= invinFlashNext)
        {
            rend.enabled = !rend.enabled;
            invinFlashNext = Time.time + invinFlashInterval;
        }

        if (Time.time >= invinEnd)
        {
            rend.enabled = true;
            invin = false;
        }

        if (murder)
        {
            v.y = jump;
            murder = false;
            rb.velocity = v;
            bulletCounter = bulletMax;
            combo++;
        }

        //dev change weapons
        if (Input.GetKey(KeyCode.Alpha1)) { 
            gunChange("Machine Gun");
        }
        if (Input.GetKey(KeyCode.Alpha2)) { 
            gunChange("Burst");
        }
        if (Input.GetKey(KeyCode.Alpha3)) { 
            gunChange("Triple");
        }
        if (Input.GetKey(KeyCode.Alpha4)) { 
            gunChange("Puncher");
        }
        if (Input.GetKey(KeyCode.Alpha5)) { 
            gunChange("Shotgun");
        }
        if (Input.GetKey(KeyCode.Alpha6)) { 
            gunChange("Laser");
        }
        if (Input.GetKey(KeyCode.Alpha7)) { 
            gunChange("Noppy");
        }
        if (Input.GetKey(KeyCode.Alpha8)) { 
            gunChange("Nuke");
        }

        if (Input.GetKey(KeyCode.Space)||(bulletBunches > 0&&bunchProgress > 1))
        {
            if (isgrounded == true)
            {
                v.y = jump;
                isgrounded = false;
                rb.velocity = v;
            } 
            
            Vector3 noppyVector = new Vector3(0,0,0);
            if (!isgrounded && (Time.time >= nextBullet && bulletCounter > 0) || (bunchProgress > 1 && Time.time >= nextBunch))
            {
                while (bulletsAtATimeProgress < bulletsAtATime)
                {
                    v.y = bulletJump;
                    if (noppyType==true) {
                        noppyVector = transform.TransformDirection(v); //sets direction of angled bullets to the direction the player is moving
                        Vector3 newRotation = gameObject.transform.rotation.eulerAngles;
                        noppyVector = Quaternion.Euler(0,-newRotation.y,0) * noppyVector;
                    } else {
                        noppyVector.Set(0f,0f,0f);
                    }
                    if(laserType == false) {
                        objectShot = bullet;
                        bulletYOffset = .9f;
                    }
                    if(laserType == true) { //when laserType is on the gun shoots lasers, and does so a bit lower so they don't despawn immediatley
                        objectShot = laser;
                        bulletYOffset = 1f;
                    }
                    if(tripleType == true) {
                        rotationOffset = ((360/ bulletsAtATime) * bulletsAtATimeProgress);
                    }
                    if(tripleType == false) {
                        rotationOffset = 0;
                    }
                    if(shotgunType == true) {
                        randx = Random.Range(-shotgunSpread, shotgunSpread); //different
                        randy = Random.Range(-1f, 1f)-2.19f; //different
                        randz = Random.Range(-shotgunSpread, shotgunSpread); //different
                    }
                    if(shotgunType == false) {
                        randx = 0f;
                        randy = 0f;
                        randz = 0f;
                    }
                    
                    for (int bulletX = 0 - (int)Mathf.Floor(bulletGridWidth / 2); bulletX < 1 + (int)Mathf.Floor(bulletGridWidth / 2); bulletX++) //make this function to gridwith by gridheight
                    {
                        for (int bulletZ = 0 - (int)Mathf.Floor(bulletGridLength / 2); bulletZ < 1 + (int)Mathf.Floor(bulletGridLength / 2); bulletZ++) //make this function to gridwith by gridheight
                        {
                            bulletFired = Instantiate(objectShot, new Vector3(transform.position.x + randx + bulletX, transform.position.y - bulletYOffset + randy - (Mathf.Abs(bulletX) + Mathf.Abs(bulletZ)), transform.position.z+ randz + bulletZ), Quaternion.Euler(noppyVector.z * -3, transform.rotation.eulerAngles.y + rotationOffset, -bulletAngle+noppyVector.x * 3));
                            if (fixedBulletCost == 0) {
                                bulletCounter--;
                            }
                            
                        }
                    }

                    bulletsAtATimeProgress++; //shotty and possibly triple use bullets at a time progress

                    if(shotgunType == true) {
                        bulletFired.transform.LookAt(this.transform); //different
                        bulletFired.transform.Rotate(90, 0, 0); //different
                    }

                    if(bunchProgress>=bulletBunches){ //check if bunch is done
                        nextBullet = Time.time + bulletDelay; 
                        bunchProgress = 0; 
                    }

                    rb.velocity = v;
                    if (bulletBunches > 0) {
                        bunchProgress++; 
                        nextBunch = Time.time + bunchGroupingDelay; 
                    }
                    if (bulletCounter < 0)
                        bulletCounter = 0;
                }
                bulletsAtATimeProgress = 0;
                nextBullet = Time.time + bulletDelay;
                if (fixedBulletCost!=0) {
                    bulletCounter-=fixedBulletCost;
                    if (bulletCounter < 0)
                        bulletCounter = 0;
                }
                
            }
        }//end of the bullet shooty part


        Vector3 boxpos = transform.position;
        boxpos.y += .4f;
        if (Physics.BoxCast(boxpos, new Vector3(.4f, .4f, .4f), -transform.up, out belowPlayer, transform.rotation, 1))
        {
            if (belowPlayer.collider.gameObject.tag != "Bullet" && belowPlayer.collider.gameObject.tag != "Wall" && belowPlayer.collider.gameObject.tag != "Enemy" && belowPlayer.collider.gameObject.tag != "SmallGem" && belowPlayer.collider.gameObject.tag != "LargeGem")
            {
                isgrounded = true;
                nextBullet = Time.time + jumpBulletDelay;
                bulletCounter = bulletMax;
                combo = 0;
            }
            else
            {
                isgrounded = false;
            }
        }
        else
        {
            isgrounded = false;
        }

        //print(rb.velocity);
    }
}