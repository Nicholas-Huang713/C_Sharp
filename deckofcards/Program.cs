using System;
using System.Collections.Generic;

namespace deckofcards
{
    class Program
    {
        static void Main(string[] args)
        {
            Player Nick = new Player("Nick");
            Deck newDeck = new Deck();
            newDeck.Show();
            // newDeck.Deal();
            // Nick.Draw(newDeck);
            // Nick.Draw(newDeck);
            // Nick.ShowHand();
        }
    }

    class Card
    {
        public string stringVal;
        public string suit;
        public int val;

        public Card(string stringVal, string suit, int val)
        {
            this.stringVal = stringVal;
            this.suit = suit;
            this.val = val;
        }
    }

    class Deck
    {
        public List<Card> Cards;

        public Deck()
        {
            this.Cards = new List<Card>();
            this.Reset(); 
        }
        public void Reset(){
                this.Cards = new List<Card>();
                string[] suits = {"Hearts","Clubs","Spades","Diamonds"};
                string[] stringVal = {"Ace","Two","Three","Four","Five","Six","Seven","Eight","Nine","Ten","Jack","Queen","King"};
                
                int num = 0;
                foreach (var suit in suits){
                    foreach(var val in stringVal){
                        Card card = new Card(val, suit, num++);
                        this.Cards.Add(card);
                    }
                }
            }

        public Card Deal(){
                this.Shuffle();
                Card card = this.Cards[this.Cards.Count - 1];
                this.Cards.Remove(card);
                System.Console.WriteLine($"Card: {card.stringVal} of {card.suit}");
                System.Console.WriteLine("Count: " + this.Cards.Count);
                return card;
        }

        public void Shuffle(){
            Random rand = new Random();
            int n = Cards.Count;    
            while (n > 1){
                n--;
                int randNum = rand.Next(n + 1);
                Card temp= Cards[randNum];
                this.Cards[randNum] = Cards[n];
                this.Cards[n] = temp;
            }
        }
        public void Show(){
                foreach(Card card in this.Cards){
                    System.Console.WriteLine($"Suit: {card.suit} - Number: {card.stringVal}");
                }
            
            
        }


    }

    class Player
    {
        public string Name;
        public List<Card> Hand;
        // public Deck Deck;

        public Player(string name){
            this.Name = name;
            this.Hand = new List<Card>();
        }

        public Card Draw(Deck deck)
        {
            Card card = deck.Deal();
            this.Hand.Add(card);
            return card;
        }

        public Card Discard(int index){
            if(index >= this.Hand.Count){
                return null;
            } else{
                Card card = this.Hand[index];
                this.Hand.RemoveAt(index);
                return card;
            }
        }

        public void ShowHand(){
            foreach(Card card in Hand){
                System.Console.WriteLine(card.stringVal + " of " + card.suit);
            }
        }
    }
}
