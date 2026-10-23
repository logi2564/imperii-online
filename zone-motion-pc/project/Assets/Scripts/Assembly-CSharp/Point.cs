using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Point : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEventSystemHandler
{
	public void OnBeginDrag(PointerEventData eventData)
	{
		if (Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
		{
			CharacterMotion.posSwipe0 = -eventData.position;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (Data.CharacterD[CharacterMotion._curCharacter].ControlGamer && !CharacterMotion.zoom)
		{
			CharacterMotion.posSwipe1 = CharacterMotion.posSwipe0;
			CharacterMotion.posSwipe0 = -eventData.position;
			CharacterMotion.posSwipe2 = -eventData.position;
			CharacterMotion.VectorOfSwipe = CharacterMotion.posSwipe2 - CharacterMotion.posSwipe1;
			CharacterMotion.VectorOfSwipe /= CharacterMotion.coefficientScreen;
			CharacterMotion.VectorOfSwipe += CharacterMotion._CameraCM.transform.position;
			CharacterMotion.swipe = true;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Methods.AAAAAAAAAAAAAAcn();
		if (Methods.GOMessaegeTask)
		{
			return;
		}
		for (int i = 0; i < Gexa.GexLib.Count; i++)
		{
			if (Gexa.GexLib[i].NameGex == base.gameObject.name)
			{
				Debug.Log(base.gameObject.name + " - " + Gexa.GexLib[i].ID);
			}
		}
		Debug.Log(base.gameObject.name);
		if (!Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
		{
			return;
		}
		CharacterMotion.GexX.SetActive(false);
		if (!(CharacterMotion.posSwipe2 == CharacterMotion.posSwipe0) || Inventory._GGActive || !Data.CharacterD[CharacterMotion._curCharacter].ControlGamer)
		{
			return;
		}
		CharacterMotion._DistansMove = 0;
		if (CharacterMotion._NextGex.Count > 0)
		{
			for (int j = 0; j < CharacterMotion._NextGex.Count; j++)
			{
				CharacterMotion._NextGex[j].GexGO.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.45f, 0.25f, 0f);
			}
			CharacterMotion._NextGex.Clear();
		}
		for (int k = 0; k < Gexa.GexLib.Count; k++)
		{
			if (Gexa.GexLib[k].NameGex == base.gameObject.name)
			{
				CharacterMotion._NextGex.Add(Gexa.GexLib[k]);
				CharacterMotion._NextGex.Add(Gexa.GexLib[k]);
				CharacterMotion._CurGex = Gexa.GexLib[k];
			}
		}
		for (int l = 0; l < Data.Points.Count; l++)
		{
			if (Data.Points[l].namePoint == base.gameObject.name)
			{
				CharacterMotion._NextGex.Add(Data.Points[l].curGexPoint);
				CharacterMotion._NextGex.Add(Data.Points[l].curGexPoint);
				CharacterMotion._CurGex = Data.Points[l].curGexPoint;
			}
		}
		for (int m = 0; m < Data.CharacterD.Count; m++)
		{
			if (Data.CharacterD[m].CharUnits.name == base.gameObject.name)
			{
				CharacterMotion._NextGex.Add(Data.CharacterD[m].CurGexChar);
				CharacterMotion._NextGex.Add(Data.CharacterD[m].CurGexChar);
				CharacterMotion._CurGex = Data.CharacterD[m].CurGexChar;
			}
		}
		if (CharacterMotion._CurGex.NameGex != Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.NameGex)
		{
			while (true)
			{
				GameObject gexGO = Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.GexGO;
				if (CharacterMotion._CurGex._YGex % 2 == 0)
				{
					for (int n = 0; n < Gexa.GexLib.Count; n++)
					{
						if (Gexa.GexLib[n].NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
						{
							CharacterMotion.GexNears[0] = Gexa.GexLib[n];
							if (Vector3.Distance(CharacterMotion.GexNears[0].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[0];
								break;
							}
						}
					}
					for (int num = 0; num < Gexa.GexLib.Count; num++)
					{
						if (Gexa.GexLib[num].NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + CharacterMotion._CurGex._YGex + "y")
						{
							CharacterMotion.GexNears[1] = Gexa.GexLib[num];
							if (Vector3.Distance(CharacterMotion.GexNears[1].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[1];
								break;
							}
						}
					}
					for (int num2 = 0; num2 < Gexa.GexLib.Count; num2++)
					{
						if (Gexa.GexLib[num2].NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
						{
							CharacterMotion.GexNears[2] = Gexa.GexLib[num2];
							if (Vector3.Distance(CharacterMotion.GexNears[2].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[2];
								break;
							}
						}
					}
					for (int num3 = 0; num3 < Gexa.GexLib.Count; num3++)
					{
						if (Gexa.GexLib[num3].NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
						{
							CharacterMotion.GexNears[3] = Gexa.GexLib[num3];
							if (Vector3.Distance(CharacterMotion.GexNears[3].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[3];
								break;
							}
						}
					}
					for (int num4 = 0; num4 < Gexa.GexLib.Count; num4++)
					{
						if (Gexa.GexLib[num4].NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + CharacterMotion._CurGex._YGex + "y")
						{
							CharacterMotion.GexNears[4] = Gexa.GexLib[num4];
							if (Vector3.Distance(CharacterMotion.GexNears[4].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[4];
								break;
							}
						}
					}
					for (int num5 = 0; num5 < Gexa.GexLib.Count; num5++)
					{
						if (Gexa.GexLib[num5].NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
						{
							CharacterMotion.GexNears[5] = Gexa.GexLib[num5];
							if (Vector3.Distance(CharacterMotion.GexNears[5].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[5];
								break;
							}
						}
					}
				}
				else
				{
					for (int num6 = 0; num6 < Gexa.GexLib.Count; num6++)
					{
						if (Gexa.GexLib[num6].NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
						{
							CharacterMotion.GexNears[0] = Gexa.GexLib[num6];
							CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[0];
							break;
						}
					}
					for (int num7 = 0; num7 < Gexa.GexLib.Count; num7++)
					{
						if (Gexa.GexLib[num7].NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + CharacterMotion._CurGex._YGex + "y")
						{
							CharacterMotion.GexNears[1] = Gexa.GexLib[num7];
							if (Vector3.Distance(CharacterMotion.GexNears[1].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[1];
								break;
							}
						}
					}
					for (int num8 = 0; num8 < Gexa.GexLib.Count; num8++)
					{
						if (Gexa.GexLib[num8].NameGex == CharacterMotion._CurGex._XGex - 1 + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
						{
							CharacterMotion.GexNears[2] = Gexa.GexLib[num8];
							if (Vector3.Distance(CharacterMotion.GexNears[2].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[2];
								break;
							}
						}
					}
					for (int num9 = 0; num9 < Gexa.GexLib.Count; num9++)
					{
						if (Gexa.GexLib[num9].NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex + 1) + "y")
						{
							CharacterMotion.GexNears[3] = Gexa.GexLib[num9];
							if (Vector3.Distance(CharacterMotion.GexNears[3].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[3];
								break;
							}
						}
					}
					for (int num10 = 0; num10 < Gexa.GexLib.Count; num10++)
					{
						if (Gexa.GexLib[num10].NameGex == CharacterMotion._CurGex._XGex + 1 + "x" + CharacterMotion._CurGex._YGex + "y")
						{
							CharacterMotion.GexNears[4] = Gexa.GexLib[num10];
							if (Vector3.Distance(CharacterMotion.GexNears[4].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[4];
								break;
							}
						}
					}
					for (int num11 = 0; num11 < Gexa.GexLib.Count; num11++)
					{
						if (Gexa.GexLib[num11].NameGex == CharacterMotion._CurGex._XGex + "x" + (CharacterMotion._CurGex._YGex - 1) + "y")
						{
							CharacterMotion.GexNears[5] = Gexa.GexLib[num11];
							if (Vector3.Distance(CharacterMotion.GexNears[5].GexGO.transform.position, gexGO.transform.position) < Vector3.Distance(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].GexGO.transform.position, gexGO.transform.position))
							{
								CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1] = CharacterMotion.GexNears[5];
								break;
							}
						}
					}
				}
				if (!(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1].NameGex != Data.CharacterD[CharacterMotion._curCharacter].CurGexChar.NameGex))
				{
					break;
				}
				CharacterMotion._CurGex = CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1];
				CharacterMotion._NextGex.Add(CharacterMotion._NextGex[CharacterMotion._NextGex.Count - 1]);
				CharacterMotion._DistansMove++;
			}
			CharacterMotion._DistansMove++;
		}
		for (int num12 = 0; num12 < CharacterMotion._NextGex.Count; num12++)
		{
			CharacterMotion._NextGex[num12].GexGO.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 1f, 0.8f);
		}
		for (int num13 = 0; num13 < CharacterMotion._NextGex.Count - 1 - CharacterMotion._PointsMove; num13++)
		{
			CharacterMotion._NextGex[num13].GexGO.GetComponent<SpriteRenderer>().color = new Color(0.65f, 0.65f, 0.5f, 0.8f);
		}
		if (CharacterMotion._DistansMove < CharacterMotion._PointsMove)
		{
			Inventory._StateCharacter = true;
		}
		else
		{
			Inventory._StateCharacter = false;
		}
		CharacterMotion._Turget.transform.position = base.gameObject.transform.position;
		CharacterMotion._TurgetGexName = base.gameObject.name;
		for (int num14 = 0; num14 < Gexa.GexLib.Count; num14++)
		{
			if (Gexa.GexLib[num14].NameGex == base.gameObject.name)
			{
				CharacterMotion._TurGex = Gexa.GexLib[num14];
			}
		}
		for (int num15 = 0; num15 < Data.CharacterD.Count; num15++)
		{
			if (Data.CharacterD[num15].CharUnits.name == base.gameObject.name)
			{
				CharacterMotion._TurGex = Data.CharacterD[num15].CurGexChar;
			}
		}
		Inventory._CurrentCharUnit.Clear();
		Inventory._CurrentPoint.Clear();
		Object.Destroy(CharacterMotion.PointInform);
		if (Inventory._CurtainInventory.activeSelf)
		{
			return;
		}
		CharacterMotion.PointInform = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInformation"));
		CharacterMotion.PointInform.name = "PointInformation";
		CharacterMotion.PointInform.transform.SetParent(GameObject.Find("Canvas").transform);
		CharacterMotion.PointInform.transform.GetChild(0).GetComponent<GridLayoutGroup>().cellSize = new Vector2(Screen.height / 3, Screen.height / 10);
		CharacterMotion.PointInform.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 3);
		CharacterMotion.PointInform.transform.GetChild(0).GetComponent<GridLayoutGroup>().padding.left = Inventory._posY4;
		CharacterMotion.PointInform.transform.position = eventData.pointerCurrentRaycast.screenPosition;
		PointAndChar.PlaseButtonFire = eventData.pointerCurrentRaycast.screenPosition;
		for (int num16 = 0; num16 < Data.Points.Count; num16++)
		{
			if (Data.Points[num16].curGexPoint != CharacterMotion._TurGex)
			{
				continue;
			}
			Inventory._CurrentPoint.Add(num16);
			CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
			CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.PointInform.transform.GetChild(0));
			CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = (Texture)Resources.Load("Sprites/IconGroup/Star");
			CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
			CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
			CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
			CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.GetChild(0).transform);
			CharacterMotion.NameChild.GetComponent<Text>().text = Data.Points[num16].namePoint;
			CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
			CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 5);
			if ((Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == CharacterMotion._TurGex && Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.NameSubject == "Детектор ''Медведь''") || (Data.CharacterD[CharacterMotion._curCharacter].CurGexChar == CharacterMotion._TurGex && Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.NameSubject == "Модернизированный ''Медведь''"))
			{
				for (int num17 = 0; num17 < 20; num17++)
				{
					if (Data.Points[Inventory._CurrentPoint[0]].Cache[num17].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact)
					{
						CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
						CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.PointInform.transform.GetChild(0));
						CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.TextureSubject;
						CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
						CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
						CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
						CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
						CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.GetChild(0).transform);
						CharacterMotion.NameChild.GetComponent<Text>().text = "Найден артефакт";
						CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
						CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 5);
						break;
					}
				}
			}
			if (!(Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.NameSubject == "Детектор ''Велес''"))
			{
				break;
			}
			Debug.Log("358");
			for (int num18 = 0; num18 < 20; num18++)
			{
				if (Data.Points[Inventory._CurrentPoint[0]].Cache[num18].TypeSubj == AAAAAAAAAAAAAAAAAAk.TypeSubject.Artefact)
				{
					CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
					CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.PointInform.transform.GetChild(0));
					CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Data.CharacterD[CharacterMotion._curCharacter].DetectorChar.TextureSubject;
					CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
					CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
					CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
					CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
					CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.GetChild(0).transform);
					CharacterMotion.NameChild.GetComponent<Text>().text = "Найден артефакт";
					CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
					CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 5);
					break;
				}
			}
			break;
		}
		for (int num19 = 0; num19 < Data.CharacterD.Count; num19++)
		{
			if (Data.CharacterD[num19].CurGexChar == CharacterMotion._TurGex)
			{
				Inventory._CurrentCharUnit.Add(num19);
				CharacterMotion.PanelInfChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/PointInfChild"));
				CharacterMotion.PanelInfChild.transform.SetParent(CharacterMotion.PointInform.transform.GetChild(0));
				if (Data.CharacterD[num19].Life)
				{
					CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Data.CharacterD[num19].SuitChar.IconCharacter;
				}
				else
				{
					CharacterMotion.PanelInfChild.GetComponentInChildren<RawImage>().texture = Data.CharacterD[num19].SuitChar.IconCharacterDead;
				}
				CharacterMotion.PanelInfChild.GetComponentInChildren<GridLayoutGroup>().cellSize = new Vector2(Inventory._posY9, Inventory._posY9);
				CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 9);
				CharacterMotion.PanelInfChild.transform.Find("RawImage").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 9);
				CharacterMotion.NameChild = (GameObject)Object.Instantiate(Resources.Load("Prefabs/NameChild"));
				CharacterMotion.NameChild.transform.SetParent(CharacterMotion.PanelInfChild.transform.GetChild(0).transform);
				CharacterMotion.NameChild.GetComponent<Text>().text = Data.CharacterD[num19].CharUnits.name;
				if (CharacterMotion.NameChild.GetComponent<Text>().text == "Странник")
				{
					CharacterMotion.NameChild.GetComponent<Text>().text = PlayerPrefs.GetString("HeroName");
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.CharacterD[num19].TypeChInt] == 0)
				{
					CharacterMotion.NameChild.GetComponent<Text>().color = new Color(0.85f, 0f, 0f, 0.9f);
				}
				if (AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.CharacterD[num19].TypeChInt] > 0 && AAAAAAAAAAAAAAAAAAAAct.AAAAAAAAAAAAAAAAAa[Data.CharacterD[CharacterMotion._curCharacter].TypeChInt, Data.CharacterD[num19].TypeChInt] < 5)
				{
					CharacterMotion.NameChild.GetComponent<Text>().color = new Color(0.8f, 0.8f, 0.1f, 0.9f);
				}
				CharacterMotion.NameChild.transform.localPosition = new Vector2(Screen.height / 5, 0f);
				CharacterMotion.NameChild.transform.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height / 5);
			}
		}
		PointAndChar.AAAAAAAAAAAAAAAAAAdc();
		PointAndChar.AAAAAAAAAAAAAAcg();
		PointAndChar.AAAAAAAAAAAAAAAAAAAch();
		PointAndChar.AAAAAAAAAAAAAAAAAAAAAcm();
		CharacterMotion.PointInform.transform.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 10 * CharacterMotion.PointInform.transform.GetChild(0).childCount);
		if (Inventory._CurrentPoint.Count > 0)
		{
			if (Data.Points[Inventory._CurrentPoint[0]].XRay > 0)
			{
				Inventory.SoundMenu.clip = (AudioClip)Resources.Load("Sound/pda/xRay");
				Inventory.SoundMenu.Play();
			}
			else
			{
				Inventory.AAAAAAAAAAAAAAbz();
			}
		}
		if (Inventory._CurrentPoint.Count == 0)
		{
			Inventory.AAAAAAAAAAAAAAbz();
		}
		Inventory._CurtainIconCharacterU.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (Inventory._CurrentCharUnit.Count + Inventory._CurrentPoint.Count) * Inventory._posY8);
		Inventory._Range = Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.Range;
		if (Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.SightInstallation)
		{
			Inventory._Range++;
		}
		if (Inventory._CurrentCharUnit.Count > 0)
		{
			if (CharacterMotion._DistansMove <= Inventory._Range && CharacterMotion._DistansMove >= Data.CharacterD[CharacterMotion._curCharacter].WeaponChar.MinRange)
			{
				Inventory._fireButton = true;
			}
			else
			{
				Inventory._fireButton = false;
			}
		}
		if (Inventory._CurrentCharUnit.Count > 0)
		{
			Inventory._currentCharacterNumber = CharacterMotion._curCharacter;
			Inventory._curNumb = 0;
			for (int num20 = Inventory._CurrentCharUnit.Count - 1; num20 >= 0; num20--)
			{
				if (Inventory._CurrentCharUnit[num20] != CharacterMotion._curCharacter)
				{
					Inventory._currentCharacterNumber = Inventory._CurrentCharUnit[num20];
					Inventory._curNumb = num20;
				}
			}
			for (int num21 = Inventory._CurrentCharUnit.Count - 1; num21 >= 0; num21--)
			{
				if (Inventory._CurrentCharUnit[num21] != CharacterMotion._curCharacter && Data.CharacterD[Inventory._CurrentCharUnit[num21]].Life)
				{
					Inventory._currentCharacterNumber = Inventory._CurrentCharUnit[num21];
					Inventory._curNumb = num21;
				}
			}
		}
		if (Inventory._CurrentCharUnit.Count == 0)
		{
			Inventory._currentCharacterNumber = CharacterMotion._curCharacter;
		}
		CharacterMotion.AAAAAAAAAAAAAAAAAAAAAAj();
	}
}
