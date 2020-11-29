using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionGrid : MonoBehaviour
{
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform tileContainer;
    [SerializeField] private static int xBound = 6;
    [SerializeField] private static int yBound = 3;
    [SerializeField] private static float gridLowerLeftTileCenter_XCoordinate = 0.0f;
    [SerializeField] private static float gridLowerLeftTileCenter_YCoordinate = 0.0f;
    private Tile[,] grid = new Tile[xBound,yBound];

    public PositionGrid()
    {
        
    }

    public void AssignTransformPositionsToTiles()
    {
        float xTransform = gridLowerLeftTileCenter_XCoordinate;
        float yTransform = gridLowerLeftTileCenter_YCoordinate;
        Vector2 tileSpriteSize = tilePrefab.GetComponent<SpriteRenderer>().bounds.size;
        float xOffset = tileSpriteSize.x;
        float yOffset = tileSpriteSize.y;

        for (int i = 0; i < xBound; i++)
        {
            yTransform = 0.0f;

            for (int j = 0; j < yBound; j++)
            {
                Vector3 tilePosition = new Vector3(xTransform, yTransform);
                grid[i,j] = Instantiate(tilePrefab, tilePosition, Quaternion.identity, tileContainer);
                yTransform += yOffset;
            }

            xTransform += xOffset;
        }
    }

    public void AssignMovementAllowanceOfTiles()
    {
        //Assign the left half to the Player
        for (int i = 0; i < (xBound/2); i++)
        {
            for (int j = 0; j < yBound; j++)
            {
                grid[i,j].MovementTagAllowed = Tile.MovementAllowance.Players;
            }
        }
        //Assign the right half to the Enemy
        for (int i = (xBound/2); i < xBound; i++)
        {
            for (int j = 0; j < yBound; j++)
            {
                grid[i,j].MovementTagAllowed = Tile.MovementAllowance.Enemies;
            }
        }
    }

    public Vector3 GetTileVector3(GridCoordinates gridCoordinates)
    {
        Vector3 tileSize = tilePrefab.GetComponent<SpriteRenderer>().bounds.size;
        Vector3 characterOffset = new Vector3();
        characterOffset.y = tileSize.y / 2;
        return grid[gridCoordinates.X, gridCoordinates.Y].transform.position + characterOffset;
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
        bool validMove = BoundCheck(character, target);
        if (validMove) 
        {
            Debug.Log ("valid move");
            RemoveCharacterFromTile(character.Position);
            AddCharacterToTile(target, character);
        }
        else
        {
            Debug.Log ("invalid move");
        }
        return validMove;
    }

    //Characters can only move within established bounds
    private bool BoundCheck(Character character, GridCoordinates target)
    {
        return (AbsoluteBoundCheck(target.X, target.Y) && IffBoundCheck(character, target));
        
    }

    //Moving Character must not go outside the bounds of the grid
    private bool AbsoluteBoundCheck(int xCoordinate, int yCoordinate)
    {
        return ((xCoordinate < xBound) && 
                (yCoordinate < yBound) && 
                (xCoordinate >= 0) &&
                (yCoordinate >= 0));
        
    }

    //Ask the target Tile if the character is allowed to move onto it
    private bool IffBoundCheck(Character character, GridCoordinates target)
    {
        return grid[target.X, target.Y].IsCharacterMoveAllowed(character);
    }

    public void RemoveCharacterFromTile(GridCoordinates gridCoordinatesToRemoveFrom)
    {
        Tile tile = grid[gridCoordinatesToRemoveFrom.X, gridCoordinatesToRemoveFrom.Y];
        tile.ClearStanding();
    }
    public void AddCharacterToTile(GridCoordinates gridCoordinatesToAddTo, Character characterToAdd)
    {
        Tile tile = grid[gridCoordinatesToAddTo.X, gridCoordinatesToAddTo.Y];
        tile.Standing = characterToAdd;
        characterToAdd.Position = gridCoordinatesToAddTo;
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
