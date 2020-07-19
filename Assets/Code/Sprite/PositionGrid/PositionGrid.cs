using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionGrid : MonoBehaviour
{
    [SerializeField] private static int xBound = 6;
    [SerializeField] private static int yBound = 3;
    public Vector3[,] tileTransformPositions = new Vector3[xBound, yBound];
    private Tile[,] grid = new Tile[xBound,yBound];
    private List<Character> characters = new List<Character>();

    public PositionGrid()
    {
        //AssignTransformPositionsToTiles();
    }

    /*private void AssignTransformPositionsToTiles()
    {
        for (int i = 0; i < xBound; i++)
        {
            for (int j = 0; j < yBound; j++)
            {
                //grid[i,j].transform.position = tileTransformPositions[i,j];
            }
        }
    }*/

    private bool MoveUp(Character character)
    {
        GridCoordinates target = character.Position;
        target.Y += 1;
        return Move(character, target);
    }
    private bool MoveDown(Character character)
    {
        GridCoordinates target = character.Position;
        target.Y -= 1;
        return Move(character, target);
    }
    private bool MoveLeft(Character character)
    {
        GridCoordinates target = character.Position;
        target.X -= 1;
        return Move(character, target);
    }
    private bool MoveRight(Character character)
    {
        GridCoordinates target = character.Position;
        target.X += 1;
        return Move(character, target);
    }

    private bool Move(Character character, GridCoordinates target)
    {
        bool validMove = BoundCheck(target.X, target.Y);
        if (validMove) 
        {
            RemoveCharacterFromTile(character.Position);
            AddCharacterToTile(target, character);
        }
        return validMove;
    }

    private bool BoundCheck(int xCoordinate, int yCoordinate)
    {
        return ((xCoordinate < xBound) && 
                (yCoordinate < yBound) && 
                (xCoordinate >= 0) &&
                (yCoordinate >= 0));
        
    }

    private void RemoveCharacterFromTile(GridCoordinates gridCoordinatesToRemoveFrom)
    {
        Tile tile = grid[gridCoordinatesToRemoveFrom.X, gridCoordinatesToRemoveFrom.Y];
        tile.ClearStanding();
    }
    private void AddCharacterToTile(GridCoordinates gridCoordinatesToAddTo, Character characterToAdd)
    {
        grid[gridCoordinatesToAddTo.X, gridCoordinatesToAddTo.Y].Standing = characterToAdd;
        characterToAdd.Position = gridCoordinatesToAddTo;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
