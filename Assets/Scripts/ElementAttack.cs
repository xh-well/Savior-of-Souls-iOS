using UnityEngine;
using System.Collections;

public class ElementAttack : MonoBehaviour {



	public GameObject fireexp;
	public GameObject waterexp;
	public GameObject earthexp;

void OnTriggerEnter(Collider other)
	{
		if (this.tag == "EnemyFire" || this.tag =="EnemyWater" || this.tag =="EnemyEarth") {
			if (other.tag =="Player")
			{
			if (this.tag =="Fire" || this.tag =="EnemyFire")
			{
				Instantiate(fireexp,this.transform.position,this.transform.rotation);
			}
			if (this.tag =="Water" || this.tag =="EnemyWater")
			{
				Instantiate(waterexp,this.transform.position,this.transform.rotation);
			}
			if (this.tag =="Earth" || this.tag =="EnemyEarth")
			{
				Instantiate(earthexp,this.transform.position,this.transform.rotation);
			}
			Destroy(this.gameObject);
			}
		}


		if (this.tag == "Fire" || this.tag =="Water" || this.tag =="Earth") {
			if (other.tag =="Enemy")
			{
				if (this.tag =="Fire" || this.tag =="EnemyFire")
				{
					Instantiate(fireexp,this.transform.position,this.transform.rotation);
				}
				if (this.tag =="Water" || this.tag =="EnemyWater")
				{
					Instantiate(waterexp,this.transform.position,this.transform.rotation);
				}
				if (this.tag =="Earth" || this.tag =="EnemyEarth")
				{
					Instantiate(earthexp,this.transform.position,this.transform.rotation);
				}
				Destroy(this.gameObject);
			}
		}

	}
}
