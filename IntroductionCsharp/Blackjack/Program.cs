
/// Shuffle the deck using Fisher-Yattes shuffle (https://stackoverflow.com/questions/273313/randomize-a-listt)
static void shuffleDeck(List<(string, string)> deck)
{
    Random random = new ();
    int n = deck.Count;
    while (n > 1)
    {
        n--;
        int k = random.Next(n + 1);
        (string, string) tmp = deck[k];
        deck[k] = deck[n];
        deck[n] = tmp;
    }
}

/// Return the score of a card depending on the current score
static int getScore(string card, int score)
{
    switch (card)
    {
        case "A":
            if (score > 10)
            {
                return 1;
            } else
            {
                return 11;
            }
        case "J":
        case "Q":
        case "K":
            return 10;
        default:
            return Convert.ToInt32(card);
    }
}

/// Return the total score of a hand of card
static int getUserCardScore(List<(string type, string cardNumber)> cards)
{
    int score = 0;
    List<int> aceIndex = new List<int>();
    for (int i =0; i < cards.Count; i++)
    {
        if (cards[i].cardNumber == "A")
        {
            aceIndex.Add(i);
        } else
        {
            score += getScore(cards[i].cardNumber, score);
        }
    }
    for (int i = 0; i < aceIndex.Count; i++)
    {
        score += getScore(cards[aceIndex[i]].cardNumber, score);
    }
    return score;
}

string[] cardNumber = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
string[] type = { "Diamond", "Spade", "Heart", "Club" };

// Create a deck of card and shuffle it
List<(string type, string cardNumber)> deck = new ();
for (int i =0; i < type.Length; i++)
{
    for (int j =0; j < cardNumber.Length; j++)
    {
        deck.Add((type[i], cardNumber[j]));
    }
}
shuffleDeck(deck);

// Create the hand of our user
List<(string type, string cardNumber)> userCards = new()
{
    deck[0],
    deck[1]
};
int currentCardIndex = 2;
int score = getUserCardScore(userCards);

// Show initial state
Console.ForegroundColor = ConsoleColor.Blue;
for (int i = 0; i < userCards.Count; i++)
{
    Console.WriteLine("Vous avez un " + userCards[i].cardNumber + " de " + userCards[i].type);
}
Console.WriteLine("Pour un score total de " + score);

string userInput;
do // Game loop
{
    // Get user input
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Voulez vous continuer ? o/n : ");
    Console.ResetColor();
    userInput = Console.ReadLine();
    if (userInput == "o")
    {
        userCards.Add(deck[currentCardIndex]);
        score = getUserCardScore(userCards);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Vous avez pioché un " + userCards[userCards.Count - 1].cardNumber + " de " + userCards[userCards.Count - 1].type + " pour un score de " + score);
        currentCardIndex++;
    }
} while (score < 21 && userInput != "n");


// Game end
if (score < 21)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("Vous avez décidé d'arrêter avec un score de " + score);
}
else if (score == 21)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Blackjack");
} else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Perdu avec un score  de " + score);
}
Console.ResetColor();
