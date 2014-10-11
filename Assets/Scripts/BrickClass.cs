using UnityEngine;
using System.Collections;

public class BrickClass : MonoBehaviour {
	
	public int brickValue { get; set; }
	public MaterialController materialController;
	public bool toBeDestroyed { get; set; }
	public bool hasBeenChecked { get; set; }
	public bool toMove { get; set; }

	public int brickcolor;
		
	void Start () {
		InitScripts();
		brickValue = Random.Range(0,5);
		this.renderer.material=materialController.brickMaterials[brickValue];	
		brickcolor = brickValue;

	}

	void Update () {
		if(toMove){
			transform.Translate(0F,-0.5F,0F);
		}

	}
	
	public void RandomBrickValue(){
		this.brickValue=Random.Range (0,5);
		this.renderer.material=materialController.brickMaterials[brickValue];
		brickcolor = brickValue;
	}

	public void FeverBrick(int feverrange)
	{
		this.brickValue = feverrange;
		this.renderer.material = materialController.brickMaterials [brickValue];
		brickcolor = brickValue;
	}

	public void FeverBrickFire()
	{
		this.brickValue = 1;
		this.renderer.material = materialController.brickMaterials [brickValue];
		brickcolor = brickValue;
	}

	public void FeverBrickWater()
	{
		this.brickValue = 0;
		this.renderer.material = materialController.brickMaterials [brickValue];
		brickcolor = brickValue;
		
	}
	public void FeverBrickGrass()
	{		
		this.brickValue = 2;
		this.renderer.material = materialController.brickMaterials [brickValue];
		brickcolor = brickValue;
	}
	public void FeverBrickShield()
	{		
		this.brickValue = 3;
		this.renderer.material = materialController.brickMaterials [brickValue];
		brickcolor = brickValue;
	}

	public void FeverBrickLight()
	{		
		this.brickValue = 4;
		this.renderer.material = materialController.brickMaterials [brickValue];
		brickcolor = brickValue;
	}


	

	
	void InitScripts(){
		if(materialController==null){
			materialController=GameObject.Find ("MaterialObject").GetComponent<MaterialController>();
		}
	}
	
}
