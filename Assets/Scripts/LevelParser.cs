

using System.Collections.Generic;

using System.IO;

using UnityEngine;


public class LevelParser : MonoBehaviour

{

    public string filename;

    public GameObject Rock;

    public GameObject Brick;

    public GameObject Stone;

    public GameObject Water;

    public GameObject Coin;

    public GameObject Goal;

    public Transform levelRoot;


    // --------------------------------------------------------------------------

    void Start()

    {

        LoadLevel();

    }


    void Update()

    {

        if (Input.GetKeyDown(KeyCode.R))

        {

            ReloadLevel();

        }

    }


    // --------------------------------------------------------------------------

    private void LoadLevel()

    {

        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";

        Debug.Log($"Loading level file: {fileToParse}");

        

        Stack<string> levelRows = new Stack<string>();


        // Get each line of text representing blocks in our level

        using (StreamReader sr = new StreamReader(fileToParse))

        {

            string line = "";

            while ((line = sr.ReadLine()) != null)

            {

                levelRows.Push(line);

            }


            sr.Close();

        }


        // Go through the rows from bottom to top

        int row = 0;

        while (levelRows.Count > 0)

        {

            string currentLine = levelRows.Pop();


            int column = 0;

            char[] letters = currentLine.ToCharArray();

            foreach (var letter in letters)

            {

                // Instantiate a new GameObject that matches the type specified by letter
		var rockObject = Instantiate(Rock);
		var stoneObject = Instantiate(Stone);
		var brickObject = Instantiate(Brick);
		var waterObject = Instantiate(Water);
		var coinObject = Instantiate(Coin);
		var goalObject = Instantiate(Goal);


		if(letter == 'x')
		{
			rockObject.transform.position = new Vector3(column, row, 0f);
		}
		else if(letter == 'b')
		{
			brickObject.transform.position = new Vector3(column, row, 0f);


		}
		else if(letter == 's')
		{
			stoneObject.transform.position = new Vector3(column, row, 0f);

		}
		else if(letter == 'w')
		{
			waterObject.transform.position = new Vector3(column, row, 0f);
		}
		else if(letter == '*')
		{
			coinObject.transform.position = new Vector3(column, row, 0f);
		}
		else if(letter == 'g')
		{
			goalObject.transform.position = new Vector3(column, row, 0f);
		}


                // Position the new GameObject at the appropriate location by using row and column

                // Parent the new GameObject under levelRoot

                column++;

            }

            row++;

        }

    }


    // --------------------------------------------------------------------------

    private void ReloadLevel()

    {

        foreach (Transform child in levelRoot)

        {

           Destroy(child.gameObject);

        }

        LoadLevel();

    }

    private void BlockInteractive(GameObject go)
    {
	    print(go.name);
    }

}


