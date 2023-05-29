
using UnityEngine;
[System.Serializable]
public class Boundry
{
  public float xMax,xMin,zMax,zMin;
}
public class PlayerMovement : MonoBehaviour
{
    public Boundry boundry;
    public Rigidbody Rb; 
    public float forwardForce = 0.02f;
    public float sideForce = 5f;
    public float tilt;
    public float fireRate;
    private float nextFire;
    public GameObject shot;
    public Transform shotSpawn;

    void Update()
    {
     if( Input.GetKey("f") && Time.time>nextFire)
     {
      nextFire = Time.time+fireRate; 
      Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
     }
    }


    
    void  FixedUpdate()
    {
		if(Input.GetKey("w"))
		{
		Rb.AddForce(0,0,forwardForce * Time.deltaTime );
     	}
		if(Input.GetKey("s"))
		{
        Rb.AddForce(0,0,-forwardForce * Time.deltaTime );
		}
        if(Input.GetKey("a"))
        {
          Rb.AddForce(-sideForce * Time.deltaTime ,0,0);   
        }
         if(Input.GetKey("d"))
        {
          Rb.AddForce(sideForce * Time.deltaTime ,0,0);   
        }
		Rb.position= new Vector3
		(
			Mathf.Clamp(Rb.position.x ,boundry.xMin, boundry.xMax),    //math function
			0.0f,
			Mathf.Clamp(Rb.position.z, boundry.zMin, boundry.zMax)
		);

    Rb.rotation = Quaternion.Euler(0.0f,0.0f,Rb.velocity.x * -tilt);
    }
    
}
