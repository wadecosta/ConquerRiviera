

using System.Collections.Generic;

using System.IO;

using UnityEngine;


public class LevelParser : MonoBehaviour

{

    public string filename;

    public GameObject Rock;

    public GameObject Ladder;

    public GameObject Stone;

    public GameObject Water;

    public GameObject Chest;

    public GameObject Iguana;

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
        GameObject newObject;
		var chestObject = Instantiate(Chest);
        var iguanaObject = Instantiate(Iguana);


		if(letter == 'x')
		{
            newObject = Instantiate(Rock);
			newObject.transform.position = new Vector3(column, row, 0f);
		}
		else if(letter == 'l')
		{
            newObject = Instantiate(Ladder);
            newObject.transform.position = new Vector3(column, row, 0f);
		}
		else if(letter == 's')
		{
            newObject = Instantiate(Stone);
            newObject.transform.position = new Vector3(column, row, 0f);
		}
		else if(letter == 'w')
		{
            newObject = Instantiate(Water);
			newObject.transform.position = new Vector3(column, row, 0f);
		}
		else if(letter == 'g')
		{
            newObject = Instantiate(Chest);
			newObject.transform.position = new Vector3(column, row, 0f);
		} else if (letter == 'i')
        {
            newObject = Instantiate(Iguana);
            newObject.transform.position = new Vector3(column, row, 0f);
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


