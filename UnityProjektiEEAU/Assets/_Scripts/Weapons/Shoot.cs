using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject bullet;

	public int damagePerShot = 20; 
	public float delayTime = 8;
	public float range = 100f;


	// Ammo
//	public int maxAmmo = 10;
//	private int clip;
//	private int reserve = 50;

	//NEW//	
	public float Ammoleft, full, StartAmmount, FullAmmo;
	private float ShotsFired, Shots;
	public Text In, Left;


	public float reloadTime = 2f;
	private bool isReloading = false;

	public Animator animator;

	private float counter = 0;


	AudioSource gunAudio;
	ParticleSystem gunParticles;
	Ray shootRay;                                    // A ray from the gun end forwards.
	RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
	int shootableMask;                             // A layer mask so the raycast only hits things on the shootable layer.



	void Start ()
	{
		Shots = StartAmmount; //NEW// Start the Clip Ammo with the Start Amount and to keep the Whole Ammo from being subtracted too much
	}
		

	void OnEnable ()
	{
		Shots = StartAmmount;
		Ammoleft = FullAmmo;
		isReloading = false;
		animator.SetBool ("Reloading", false);
	}


	void Awake () 
	{
		// Create a layer mask for the Shootable layer.
		shootableMask = LayerMask.GetMask ("Shootable");
		gunAudio = GetComponent<AudioSource> ();
		gunParticles = GetComponent<ParticleSystem> ();
	}
		


	void Update () {

		if (isReloading)
		return;
					
		//NEW//
		if (Input.GetButton ("Fire2") && Ammoleft > 0 && ShotsFired > 0) //if the Whole Ammo is greater than 0 and the Reload button is pressed, then start the Reload Sequence
		{
			StartCoroutine (Reload ());

		}
		if (Input.GetButton ("Fire1") && Shots <= 0 && Ammoleft > 0) //if the Whole Ammo is greater than 0 and if the Shots are less than or equal to 0 and the Fire Button is pressed, then start the Reload Sequence
		{
			StartCoroutine (Reload ());

		}
		if (Ammoleft <= 0)
		{
			Ammoleft = 0;
		}
		AmmoLeftIn();
		LeftInClip();
	



		counter += Time.deltaTime;

		// If the Fire1 button is being press and it's time to fire...
		if(Input.GetButton ("Fire1") && counter >= delayTime && isReloading == false)
		{
			if (Shots == 0 && Ammoleft == 0) 
			{
				return;
			}

				//NEW//
				Shots -= 1;
				ShotsFired += 1;

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
				if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
					// Try and find an EnemyHealth script on the gameobject hit.
					EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();

					// If the EnemyHealth component exist...
					if (enemyHealth != null) {
						// ... the enemy should take damage.
						enemyHealth.TakeDamage (damagePerShot, shootHit.point);
					}
				}
		}
	}
		


	IEnumerator Reload ()
	{
		isReloading = true;
		Debug.Log ("Reloading...");

		animator.SetBool ("Reloading", true);

		yield return new WaitForSeconds (reloadTime - .25f);

		//NEW//
		if(Shots > 0) //if the shots are bigger than 0, then subtract the Whole Ammo from the remainder of a the Ammo Clip to create a Full Ammo Clip
		{
			Ammoleft -= ShotsFired;
			Shots = full;
		}
		//NEW//
		if (Shots <= 0) //if the shots are less than or equal than 0, then refill the Empty Clip to a Full Clip abd subtract it from the Whole Ammo
		{
			Ammoleft -= full;
			Shots = full;
		}
		//NEW//
		if (Shots > 0 && Ammoleft < 0) //if the shots are bigger than 0 and the Whole Ammo left is less than 0, then add the last ammount of Ammo into the clip
		{
			Shots += Ammoleft;
			Ammoleft -= ShotsFired;
		}

		animator.SetBool ("Reloading", false);
		yield return new WaitForSeconds (.25f);
		ShotsFired = 0; //return the remainder to 0
		isReloading = false;
	}

	//NEW//
	void LeftInClip()
	{
		Left.text = "" + Shots.ToString();
	}
	//NEW//
	void AmmoLeftIn()
	{
		In.text = "/ " + Ammoleft.ToString();
	}
}