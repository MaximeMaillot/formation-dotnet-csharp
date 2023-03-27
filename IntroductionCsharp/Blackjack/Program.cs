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

static (string, string) popDeck(List<(string, string)> deck) 
{
    (string, string) card = deck.Last();
    deck.RemoveAt(deck.Count - 1);
    return card;
}

static bool doesDealerDraw(List<(string, string)> cards, int score)
{
    if (score < 17)
    {
        return true;
    }
    return false;
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
    popDeck(deck),
    popDeck(deck)
};
List<(string type, string cardNumber)> dealerCards = new()
{
    popDeck(deck),
    popDeck(deck)
};
List<(string type, string cardNumber)> dealerCardsShown = new()
{
    dealerCards[0]
};


int score = getUserCardScore(userCards);
int dealerScore = getUserCardScore(dealerCards);
int dealerScoreShown = getUserCardScore(dealerCardsShown);
bool dealerDraw = true;

// Show initial state
Console.ForegroundColor = ConsoleColor.Blue;
for (int i = 0; i < userCards.Count; i++)
{
    Console.WriteLine("Vous avez un " + userCards[i].cardNumber + " de " + userCards[i].type);
}
Console.WriteLine("Pour un score total de " + score);

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Le dealer a un " + dealerCardsShown[0].cardNumber + " de " + dealerCardsShown[0].type + " plus une carte caché"); 
Console.WriteLine("Pour un score visible de : " + dealerScoreShown);


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
        userCards.Add(popDeck(deck));
        score = getUserCardScore(userCards);
        if (score >= 21)
        {
            break;
        } 
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Vous avez pioché un " + userCards.Last().cardNumber + " de " + userCards.Last().type + " pour un score de " + score);
    }
    if (dealerDraw)
    {
        dealerDraw = doesDealerDraw(dealerCards, dealerScore);
        if (dealerDraw)
        {
            dealerCards.Add(popDeck(deck));
            dealerCardsShown.Add(dealerCards.Last());
            dealerScore = getUserCardScore(dealerCards);
            dealerScoreShown = getUserCardScore(dealerCardsShown);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Le dealer a pioché " + dealerCardsShown.Last().cardNumber + " de " + dealerCardsShown.Last().type + " pour un score visible de " + dealerScoreShown);
        }
    }
} while (score < 21 && userInput != "n");

// Dealer continue to draw until he's satisfied
while (dealerDraw)
{
    dealerDraw = doesDealerDraw(dealerCards, dealerScore);
    if (dealerDraw)
    {
        dealerCards.Add(popDeck(deck));
        dealerCardsShown.Add(dealerCards.Last());
        dealerScore = getUserCardScore(dealerCards);
        dealerScoreShown = getUserCardScore(dealerCardsShown);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Le dealer a pioché " + dealerCardsShown.Last().cardNumber + " de " + dealerCardsShown.Last().type + " pour un score visible de " + dealerScoreShown);
    }
};

Console.WriteLine("La carte caché du dealer est un " + dealerCards[1].cardNumber + " de " + dealerCards[1].type + " pour un score total de " + dealerScore);

// Game end
if (score > 21)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Defaite car vous avez dépassé 21");
}
else if (dealerScore > 21)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Victoire car le dealer a dépassé 21");
}
else if (score > dealerScore) 
{
    if (score == 21)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Blackjack");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Victoire !");
    }
} else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Perdu avec un score  de " + score + " contre le score de " + dealerScore + " du dealer");
}
Console.ResetColor();
