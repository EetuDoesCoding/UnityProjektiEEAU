using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject bullet;

	public int damagePerShot = 20; 
	public float delayTime = 8;
	public float range = 100f;

	private float counter = 0;

	AudioSource gunAudio;
	ParticleSystem gunParticles;
	Ray shootRay;                                   // A ray from the gun end forwards.
	RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
	int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.



	void Awake () 
	{
		// Create a layer mask for the Shootable layer.
		shootableMask = LayerMask.GetMask ("Shootable");

		gunAudio = GetComponent<AudioSource> ();
		gunParticles = GetComponent<ParticleSystem> ();
	}
		

	void Update () 
	{
		counter += Time.deltaTime;


		// If the Fire1 button is being press and it's time to fire...
		if(Input.GetButton ("Fire1") && counter >= delayTime)
		{
			Instantiate (bullet, transform.position, transform.rotation);
			counter = 0;

			// Play the gun shot audioclip.
			gunAudio.Play ();

			// Stop the particles from playing if they were, then start the particles.
			gunParticles.Stop ();
			gunParticles.Play ();

			// Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
			shootRay.origin = transform.position;
			shootRay.direction = transform.forward;

			// Perform the raycast against gameobjects on the shootable layer and if it hits something...
			if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) 
			{
				// Try and find an EnemyHealth script on the gameobject hit.
				EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();

				// If the EnemyHealth component exist...
				if (enemyHealth != null) 
				{
					// ... the enemy should take damage.
					enemyHealth.TakeDamage (damagePerShot, shootHit.point);
				}
			}
		
		
		}
	}
}