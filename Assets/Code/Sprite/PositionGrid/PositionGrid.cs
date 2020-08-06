using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionGrid : MonoBehaviour
{
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform tileContainer;
    [SerializeField] private static int xBound = 6;
    [SerializeField] private static int yBound = 3;
    private Tile[,] grid = new Tile[xBound,yBound];
    private List<Character> characters = new List<Character>();

    public PositionGrid()
    {
        
    }

    private void AssignTransformPositionsToTiles()
    {
        float xTransform = -7.5f;
        float yTransform = -4.4f;
        float xOffset = 2.2f;
        float yOffset = 1.1f;

        for (int i = 0; i < xBound; i++)
        {
            yTransform = -4.4f;

            for (int j = 0; j < yBound; j++)
            {
                Vector3 tilePosition = new Vector3(xTransform, yTransform);
                this.grid[i,j] = Instantiate(tilePrefab, tilePosition, Quaternion.identity, tileContainer);
                yTransform += yOffset;
            }

            xTransform += xOffset;
        }
    }

    public Vector3 GetTileVector3(GridCoordinates gridCoordinates)
    {
        return grid[gridCoordinates.X, gridCoordinates.Y].transform.position;
    }

    public bool MoveUp(Character character)
    {
        GridCoordinates target = character.Position;
        target.Y += 1;
        return Move(character, target);
    }
    public bool MoveDown(Character character)
    {
        GridCoordinates target = character.Position;
        target.Y -= 1;
        return Move(character, target);
    }
    public bool MoveLeft(Character character)
    {
        GridCoordinates target = character.Position;
        target.X -= 1;
        return Move(character, target);
    }
    public bool MoveRight(Character character)
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

    public void RemoveCharacterFromTile(GridCoordinates gridCoordinatesToRemoveFrom)
    {
        Tile tile = grid[gridCoordinatesToRemoveFrom.X, gridCoordinatesToRemoveFrom.Y];
        tile.ClearStanding();
    }
    public void AddCharacterToTile(GridCoordinates gridCoordinatesToAddTo, Character characterToAdd)
    {
        grid[gridCoordinatesToAddTo.X, gridCoordinatesToAddTo.Y].Standing = characterToAdd;
        characterToAdd.Position = gridCoordinatesToAddTo;
    }

    // Start is called before the first frame update
    void Start()
    {
        AssignTransformPositionsToTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
