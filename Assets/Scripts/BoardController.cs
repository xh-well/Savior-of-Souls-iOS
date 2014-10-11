using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BoardController: MonoBehaviour {

	public GameObject[,] bricks;
	public BrickClass[,] brickClass;
	public GameObject brickPrefab;
	public HighScoreController highScoreController;
	public Vector3 StartVector;
	public int matchingBrickCounter;
	public ParticleSystem hintParticles;
	public GameObject[] explosion;
	public int boardSize;
	public int boardSizew;
	
	public bool toScramble=false;
	public bool hintsUpdated=false;
	public bool timeUp=false;
	public bool menuOn=true;

	public BattleCheck battle;
	
	public float hintTimer;
	public float scrambleTimer;
	public float roundSeconds=60f;
	public float roundTimer;
	public float standByTimer=0f;
	
	public List<GameObject> hints = new List<GameObject>();


	public UIProgressBar Feverbar;
	public static float feverboost;
	private bool fever;

	public static bool chainbreaker;

	//runs first
	void Awake(){
		hintTimer = Time.time;
		Feverbar.value = 0;
		fever = false;
	}
	
	void Start () {
		Time.timeScale=1;
		UpdateRoundTimer();
		bricks = new GameObject[boardSize,boardSizew];
		brickClass = new BrickClass[boardSize,boardSizew];
		BuildBoard ();
		chainbreaker = false;

	}

	void Update()
	{
		CheckForMovement ();
		UpdateHintArray ();

		if (Input.GetMouseButtonDown (0)) {
			ClickMouseAction();
		}
		CheckShowHints ();
		CheckForSolution ();
		FeverTime ();
	}

	public void FeverTime()
	{
		if (Feverbar.value == 1)
		{
			fever =true;		
		}

		if (fever & !battle.SkillActive)
		{
			Feverbar.value -= 0.2f*Time.deltaTime;
			if (Feverbar.value <=0)
			{
				fever =false;
			}
		}


	}
	//Check For Hint
	void UpdateHintArray()
	{
		if (!hintsUpdated) 
		{
			hints.Clear();
			for(int it1=0;it1<boardSize;it1+=2)
			{
				for(int it2=0;it2<boardSizew;it2+=2)
				{
					matchingBrickCounter=0;
					MatchAlgorithm(it1,it2,false);
					if (matchingBrickCounter >=3)
					{
						hints.Add(bricks[it1,it2]);
					}
				}
			}
			hintsUpdated = true;
		}
		matchingBrickCounter = 0;
		for (int it1=0; it1<boardSize; it1+=2) {
			for (int it2=0;it2<boardSizew;it2+=2)
			{
				brickClass[it1,it2].toBeDestroyed=false;
				brickClass[it1,it2].hasBeenChecked=false;
			}
		}
	}

	//Same Break
	//Restore

	//Captain Skill 0
	public IEnumerator SetBlockRegular ()
	{
		int fire = 0;
		int water = 0;
		int earth = 0;
		int shield = 0;
		int light = 0;

		for (int it1=0; it1<boardSize; it1+=2) {
			for (int it2=0;it2<boardSizew;it2+=2)
			{
				if (brickClass[it1,it2].brickValue ==0)
				{
					water ++;
				}else if (brickClass[it1,it2].brickValue ==1)
				{
					fire ++;
				}else if (brickClass[it1,it2].brickValue ==2)
				{
					earth ++;
				}else if (brickClass[it1,it2].brickValue ==3)
				{
					shield ++;
				}else if (brickClass[it1,it2].brickValue ==4)
				{
					light ++;
				}
			}
		}
		for (int it1=0; it1<boardSize; it1+=2) {
			for (int it2=0;it2<boardSizew;it2+=2)
			{
				yield return new WaitForSeconds(0.01f);
				Instantiate (explosion[4],bricks[it1,it2].transform.position,bricks[it1,it2].transform.rotation);
				if (water>0)
				{
				brickClass[it1,it2].FeverBrickWater();
				water--;
				}else if (fire >0)
				{
				brickClass[it1,it2].FeverBrickFire();
					fire --;
				}else if (earth >0)
				{
					brickClass[it1,it2].FeverBrickGrass();
					earth --;
				}else if (shield >0)
				{
					brickClass[it1,it2].FeverBrickShield();
					shield --;
				}else if (light >0)
				{
					brickClass[it1,it2].FeverBrickLight();
					light --;
				}
			}
		}
		yield break;
	}

	//Captain Skill 1
	public void BreakBlock()
	{
			for(int it1=0;it1<boardSize;it1+=2)
			{
				for(int it2=0;it2<boardSizew;it2+=2)
				{
					matchingBrickCounter=0;
					MatchAlgorithm(it1,it2,false);
					if (matchingBrickCounter ==3)
					{
					Instantiate (explosion[4],bricks[it1,it2].transform.position,bricks[it1,it2].transform.rotation);
					Destroy(bricks[it1,it2]);
					bricks[it1,it2] = null;

					if (brickClass[it1,it2].brickValue == 0) {
						battle.Water();
					} else if (brickClass[it1,it2].brickValue == 1) {
						battle.Fire();
					} else if (brickClass[it1,it2].brickValue == 2) {
						battle.Earth();
					} else if (brickClass[it1,it2].brickValue == 3) {
						battle.Shield();						
					}
				}
				}
			}
		matchingBrickCounter = 0;
	}
	
	//Captain Skill 2
	public void FeverSetBlock()
	{	
		int y = Random.Range (0, 4);
		int x = Random.Range (0, 4);

		if (y == 0) {
			x=Random.Range(0,4);
						for (int it1=0; it1<4; it1+=2) {
								for (int it2=0; it2<boardSizew; it2+=2) {
										brickClass [it1, it2].FeverBrick (x);
								}
						}
				}

		if (y == 1) {
						x = Random.Range (0, 4);
						for (int it1=4; it1<8; it1+=2) {
								for (int it2=0; it2<boardSizew; it2+=2) {
										brickClass [it1, it2].FeverBrick (x);
								}
						}
				}

		if (y == 2) {
						x = Random.Range (0, 4);
						for (int it1=8; it1<12; it1+=2) {
								for (int it2=0; it2<boardSizew; it2+=2) {
										brickClass [it1, it2].FeverBrick (x);
								}
						}
				}

		if (y == 3) {
						x = Random.Range (0, 4);
						for (int it1=12; it1<14; it1+=2) {
								for (int it2=0; it2<boardSizew; it2+=2) {
										brickClass [it1, it2].FeverBrick (x);
								}
						}
				}
	}

	//Captain Skill 3
	public void RuneChangeFire()
	{
		for (int it1=0; it1<boardSize; it1+=2) {
			for (int it2=0;it2<boardSizew;it2+=2)
			{
				if (brickClass[it1,it2].brickValue ==2)
				{
					brickClass[it1,it2].FeverBrickFire();
				}
			}
		}
	}

	//Captain Skill 4
	public void ChainBreaker(int chain)
	{

		for (int it1=0; it1<boardSize; it1+=2) {
			for (int it2=0;it2<boardSizew;it2+=2)
			{
				if (brickClass[it1,it2].brickValue == chain)
				{
					brickClass [it1,it2].hasBeenChecked = true;
					brickClass [it1,it2].toBeDestroyed = false;
					Instantiate (explosion[4],bricks[it1,it2].transform.position,bricks[it1,it2].transform.rotation);
					Destroy(bricks[it1,it2]);
					bricks[it1,it2] = null;

					if (chain == 0) {
						battle.Water();
					} else if (chain == 1) {
						battle.Fire();
					} else if (chain == 2) {
						battle.Earth();
					} else if (chain == 3) {
						battle.Shield();						
					}
				}
			}
		}
	}



	void CheckShowHints()
	{
		if (Time.time - hintTimer >= 3.0f) {
		if (!hintParticles.isPlaying)
			{
				GameObject r = hints[Random.Range(0,hints.Count)];
				hintParticles.transform.position = r.transform.position;
				hintParticles.Play();
			}
		}
	}

	void CheckForSolution()
	{
		if (hints.Count==0&&!toScramble) 
		{
			scrambleTimer=Time.time;
			toScramble = true;
		}
		if (toScramble) {
		if (Time.time-scrambleTimer<0.2f)
			{
				ScrambleBoard();
			}else
			{
				toScramble=false;
				hintsUpdated = false;
				standByTimer +=0.1f;
			}

		}
	}
	void ScrambleBoard()
	{
		for (int it1=0; it1<boardSize; it1+=2) {
			for (int it2=0;it2<boardSizew;it2+=2)
			{
				brickClass[it1,it2].RandomBrickValue();
			}
		}
	}


	void CheckForMovement()
	{
		for (int it1=0; it1<boardSize; it1+=2) {
			for (int it2=0;it2<boardSizew;it2+=2)
			{
				if (bricks[it1,it2]!=null)
				{
					if(bricks[it1,it2].transform.position.y!=it2-10f)
					{
						brickClass[it1,it2].toMove=true;
					}
					else{
						brickClass[it1,it2].toMove=false;
					}
				}
			}
		
		}
	}





	void ClickMouseAction()
	{
		feverboost = 0;
		if (chainbreaker) {
			matchingBrickCounter += 3;		
		}
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
						if (hit.transform.gameObject.name.Equals ("Brick(Clone)")) {
								Vector3 hitObject = hit.transform.position - StartVector;
								if (!brickClass [Mathf.FloorToInt (hitObject.x), Mathf.FloorToInt (hitObject.y)].toMove) {
										//Judge If there're same blocks
										MatchAlgorithm (Mathf.FloorToInt (hitObject.x), Mathf.FloorToInt (hitObject.y), true);
										if (matchingBrickCounter >= 3) {
											if (fever ==false)
												{
											feverboost = matchingBrickCounter*0.01f;
											Feverbar.value += feverboost;
													}
												hintTimer = Time.time;
												hintParticles.Stop();
												for (int it1=0; it1<boardSize; it1+=2) {
														for (int it2=0; it2<boardSizew; it2 +=2) {
																if (brickClass [it1, it2] != null) {
																		if (brickClass [it1, it2].toBeDestroyed) {
										if (fever)
										{
											Instantiate (explosion[4],bricks[it1,it2].transform.position,bricks[it1,it2].transform.rotation);
											//BreakBlock();
											//FeverSetBlock();
											//SetBlockRegular();
										}else {
												Instantiate (explosion[brickClass[it1,it2].brickValue],bricks[it1,it2].transform.position,bricks[it1,it2].transform.rotation);
										}
										if (chainbreaker)
										{
											ChainBreaker(brickClass[it1,it2].brickValue);
										}
										CheckElement(brickClass[it1,it2].brickValue);
											Destroy (bricks [it1, it2]);
																				bricks [it1, it2] = null;
																				
																		}
																}
														}
												}
						for (int it1=0;it1<boardSize;it1+=2)
						{
							MoveBlocks(it1);
						}
						Reinstantiate();
						ResetBlockClasses();
						hintsUpdated=false;
										}
											else {
												for (int it1=0; it1<boardSize; it1+=2) {
														for (int it2=0; it2<boardSizew; it2+=2) {
																brickClass [it1, it2].toBeDestroyed = false;
																brickClass [it1, it2].hasBeenChecked = false;
														}
												}
										}
								}
				matchingBrickCounter =0;
						}
				}
	}

	void CheckElement(int brickvalue)
	{
		if (brickvalue == 0) {
			battle.Water();
		} 
		else if (brickvalue == 1) {
			battle.Fire();
				} else if (brickvalue == 2) {
			battle.Earth();
				} else if (brickvalue == 3) {
			battle.Shield();

				}
	}

	void MatchAlgorithm(int brickPositionX,int brickPositionY,bool clicked)
	{				
						brickClass [brickPositionX, brickPositionY].hasBeenChecked = true;
						brickClass [brickPositionX, brickPositionY].toBeDestroyed = clicked;
						matchingBrickCounter += 1;
						if (brickPositionX > 0) {
								if (!brickClass [brickPositionX - 2, brickPositionY].hasBeenChecked && brickClass [brickPositionX - 2, brickPositionY].brickValue == brickClass [brickPositionX, brickPositionY].brickValue) {
										MatchAlgorithm (brickPositionX - 2, brickPositionY, clicked);
								}
						}
						if (brickPositionX < 12) {
								if (!brickClass [brickPositionX + 2, brickPositionY].hasBeenChecked && brickClass [brickPositionX + 2, brickPositionY].brickValue == brickClass [brickPositionX, brickPositionY].brickValue) {
										MatchAlgorithm (brickPositionX + 2, brickPositionY, clicked);
							}
						}
						if (brickPositionY > 0) {
								if (!brickClass [brickPositionX, brickPositionY - 2].hasBeenChecked && brickClass [brickPositionX, brickPositionY - 2].brickValue == brickClass [brickPositionX, brickPositionY].brickValue) {
										MatchAlgorithm (brickPositionX, brickPositionY - 2, clicked);
								}
					}
						if (brickPositionY < 8) {
								if (!brickClass [brickPositionX, brickPositionY + 2].hasBeenChecked && brickClass [brickPositionX, brickPositionY + 2].brickValue == brickClass [brickPositionX, brickPositionY].brickValue) {
										MatchAlgorithm (brickPositionX, brickPositionY + 2, clicked);
						}
						}			
	
	
	}
				


	

	
	void UpdateRoundTimer(){
		roundTimer=roundSeconds-Time.timeSinceLevelLoad+standByTimer;
		
	}

	void Reinstantiate()
	{
	while (CheckForNull()) {
			for (int it1=0;it1<boardSize;it1+=2)
			{
				for (int it2=0;it2<boardSizew;it2+=2)
				{
					if (bricks[it1,it2]==null)
					{
						bricks[it1,it2] = Instantiate(brickPrefab,new Vector3(-6f+it1,it2-5f,0f),Quaternion.identity) as GameObject;
					}
				}
			}
		}
	}

	void MoveBlocks(int brickPositionX)
	{
		GameObject tempGameObject;
		for (int it1=0; it1<8; it1+=2) {
		if (bricks[brickPositionX,it1]==null)
			{
				for (int it2=it1;it2<boardSizew;it2+=2)
				{
					if (bricks[brickPositionX,it2]!=null)
					{
						tempGameObject=bricks[brickPositionX,it1];
						bricks[brickPositionX,it1]=bricks[brickPositionX,it2];
						bricks[brickPositionX,it2]=tempGameObject;
						it2 = 10;
					}
				}
			}
		}
	}

	void ResetBlockClasses()
	{
		for (int it1=0; it1<boardSize; it1+=2) {
			for (int it2=0;it2<boardSizew;it2+=2)
			{
				brickClass[it1,it2]=bricks[it1,it2].GetComponent<BrickClass>();
			}
		}
	}


	bool CheckForNull()	{
		for (int it1=0; it1<boardSize; it1+=2) {
			for (int it2=0;it2<boardSizew;it2+=2)
			{
				if(bricks[it1,it2]==null)
					return true;
			}
		}
		return false;
	}



	//Instantiates the whole board
	void BuildBoard(){
		for (int it1=0;it1<boardSize;it1+=2){
			for(int it2=0;it2<boardSizew;it2+=2){
				bricks[it1,it2]=Instantiate (brickPrefab,new Vector3(-6f+it1,-10F+it2,0F),Quaternion.identity) as GameObject;
				brickClass[it1,it2]=bricks[it1,it2].GetComponent<BrickClass>();
			}
		}
		hintsUpdated=false;
	}


}