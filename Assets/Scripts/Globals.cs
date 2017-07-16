using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals 
{
	public static int score;
	public static int freezeCount;
	public static int superBallCount;
	public static int suicideCount;
	public static int brickCount;
	public static int goldCount;
	public static int refillCount;
	public static int previouslySelectedSpawner;
	public static int highScore;
    public static Color[] mainColors = { new Vector4(90f, 90f, 255f, 255f), new Vector4(90f, 255f, 90f, 255f), new Vector4(255f, 90f, 90f, 255f) };
	public static Color gold = new  Vector4(255f, 215f, 0f, 255f) / 255f;
}

