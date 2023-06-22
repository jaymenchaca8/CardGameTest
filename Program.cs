/*
 Player
  -Hand
  -Deck
Field
  -Player
Hand
  -Card
Deck
  -Card
GameState
  -Menu
  -StartBattle
  -ProcessInput
  -ProcessAI
  -ProcessDamage
 */


using System;

static class Constants {
    public const int HANDSIZE = 7;
    public const int DECKSIZE = 30;
    public const int FIELDSIZE = 3;
}

//card attributes
public class Card { 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Card(int id, string name, string description) { 
        Id = id;
        Name = name;
        Description = description;
    }

    public void printCardInfo() {
        Console.WriteLine("Name: {0}", Name);
        Console.WriteLine("ID: {0}", Id);
        Console.WriteLine("Description: {0}", Description);
    }

}

//list of cards in player hand (could possibly just become part of the Player class)
public class Hand { 
    public bool Player { get; set; } //probably not used
    //public int CurrentCardCount  { get; set; } //probably doesn't need to be used
    public int MaxCardCount { get; set; }
    public List<Card> CardsInHand { get; set; } //question is if i just want the ids(int) of the cards or the objects(Card)
    public Hand(bool player) { 
        Player = player;
        //CurrentCardCount = 0;
        MaxCardCount = Constants.HANDSIZE;
        CardsInHand = new List<Card>();
    }

    public void addCardToHand(Card card) {
        CardsInHand.Add(card);
    }

    public Card PlayCardAt(int position) {
        if (position > CardsInHand.Count) { 
            //this could handled outside of this function(?)
        }
        Card card = CardsInHand[position];
        CardsInHand.Remove(card); //assuming items in the list are set to fill in emptied items, nothing else should need to be done
        return card;
    }
}

//where cards will interact
public class Field { 
    public Player PlayerTurn { get; set; } //maybe unneeded, managed in Game object instead
    public Card[,] CardPosition { get; set; }
    public Field(int gameState, Player playerTurn)
    {
        CardPosition = new Card[Constants.FIELDSIZE, Constants.FIELDSIZE];
        PlayerTurn = playerTurn;    
    }
}

//contains hit points, hand, deck
public class Player { 
    public int HitPoints { get; set; }
    public bool CPU { get; set; } //0 = human, 1 = cpu
    public Deck PlayerDeck { get; set; }
    public Hand PlayerHand { get; set; }
    public Player(bool control, Deck deck, Hand hand) {
        HitPoints = 10;
        CPU = control;
        PlayerDeck = deck;
        PlayerHand = hand;
    }

    //draw card from deck
    public void ProcessDraw() {
        Card tempCard = PlayerDeck.DrawTopCard();
        PlayerHand.addCardToHand(tempCard);
    }

}

//information and order of cards in the deck
public class Deck { 
    public string Name { get; set; }
    public int MaxSize { get; set; }
    public int CurrentSize { get; set; } //unused?
    public Stack<Card> DeckList { get; set; } //dont know if i want the card order in this list as well
    public Deck(string name, Stack<Card> decklist) { 
        Name = name;
        MaxSize = Constants.DECKSIZE;
        DeckList = decklist;
    }

    public Card DrawTopCard() { 
        return DeckList.Pop();
    }
    
}

//manipulate and process gamestate
public class Game {
    public enum States { 
        Menu,
        StartBattle,
        PlayerTurn,
        AITurn,
        BattleDamage,
        Win
    }
    public Field GameField { get; set; }
    public Player player1 { get; set; } //set as user for the time being
    public Player player2 { get; set; } //set as CPU for the time being
    public States GameState { get; set; }  //menu, deck selection, deck creation, play, ???
    public Game(States gameState) { 
        GameState = gameState;
    }

    public int processStart() {
        //Menu gamestate
        //will probably be the first thing to run
        //create menu list of commands
        //ask for user input for menu items
        return 0;
    }

    public int processPlayBattle() {
        //StartBattle gamestate
        //load deck
        //load user Player and AI player
        //load board
        //fill Hands
        //call PayerTurn or AITurn
        return 0;
    }

    public void processPlayerTurn()
    {
        //PlayerTurn gamestate
        //(User)draw card and other upkeep items that maybe added later
        //ask for user input
        //process input & check for valid move (ask for input again if not)
        //call DamageCalculation
    }

    public void processAITurn()
    {
        //AITurn gamestate
        //(CPU)draw card and other upkeep items that maybe added later
        //process CPU move (probably just random for now. still would need to check if valid move)
        //call DamageCalculation
    }

    public void processDamageCalculation(States turn)
    {
        //BattleDamage gamestate
        //look at Field state
        //process card damage and health (effects?)
        //process Player and CPU health
        //check for win conditions
        //call opposite gamestate from 'turn'
    }

    public void processWin(Player winner) {
        //Win gamestate
        //display win message
        //wait for user input to continue
        //delete field and player objects
        //call to start to return to menu
    }

    //checking to ensure only valid commands are used
    public void processInput(string input) {
        switch (this.GameState) { 
            case States.Menu:
                menuInput(input);
                break;
            case States.PlayerTurn:
                playerInput(input);
                break;
            default:
                Console.WriteLine("You shouldn't be able to input now");
                break;
        }
    }

    /*
     Menu Commands:
        Start Battle -
        Deck(Editor?) - 
        Exit - 
     */
    public void menuInput(string input) {
        input = input.ToLower();
        switch (input) {
            default:
                break;

        }
    }
    /*
     Player Turn Commands:
        Check Hand - 
        Check Card (Card) -
        Check Board (Card -optional) -
        Play Card (Card, Position) - 
        End Turn - 
     */
    public void playerInput(string input) {
        input = input.ToLower();
        switch (input)
        {
            default:
                break;

        }
    }

}

public class Program
{
    static void Main()
    {
        while (true) {
            Console.Write("User: ");
            string consoleInput = Console.ReadLine();
            consoleInput = consoleInput.ToLower();

            switch (consoleInput) {
                case "test":
                    Console.WriteLine("Tested");
                    break;
                case "help":
                    Console.WriteLine("Insert help documentation here");
                    break;
                default:
                    Console.WriteLine("Please try something else");
                    break;
            }
        }
    }
}
