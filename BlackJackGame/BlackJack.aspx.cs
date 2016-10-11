using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlackJackGame
{
    public partial class BlackJack : System.Web.UI.Page
    {
        public static int playerHandValue = 0;
        public static int dealerHandValue = 0;
        public static List<Card> Deck1 = new List<Card>();
        public static int HitClicks = 0;
        public static int AceCount = 0;
        public static int DealerAceCount = 0;
        public static int SubtractCount = 0;
        public static int DealerSubtractCount = 0;
        public static int PlayerBalance;
        public static int PlayerBet = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                HttpCookie cookie = Request.Cookies["Balance"];
                if (cookie != null)
                {
                    PlayerBalance = Convert.ToInt32(cookie.Values["balance"]);
                    if (PlayerBalance == 0)
                    {
                        PlayerBalance = 250;

                    }
                    
                }
                else
                {
                    PlayerBalance = 250;
                    cookie = new HttpCookie("Balance");
                    cookie.Values.Add("balance", PlayerBalance.ToString());
                    cookie.Expires = DateTime.Now.AddYears(2111);
                    
                    Response.Cookies.Add(cookie);
                }
                PlayerBet = 0;
            }


            lblPlayerBalance.Text = $"Balance: ${PlayerBalance}";
            DisplayChips();



        }

        public void DisplayChips()
        {
            if (PlayerBalance >= 5)
            {
                chip5.Visible = true;
            }

            if (PlayerBalance >= 10)
            {
                chip10.Visible = true;
            }

            if (PlayerBalance >= 25)
            {
                chip25.Visible = true;
            }

            if (PlayerBalance >= 50)
            {
                chip50.Visible = true;
            }

            if (PlayerBalance >= 100)
            {
                chip100.Visible = true;
            }

            if (PlayerBalance >= 500)
            {
                chip500.Visible = true;
            }


        }

        public string Hit()
        {
            Card hitCard;
            string cardInfo;
            bool isunique = false;
            do
            {
                Random random = new Random();
                int SelectedNumber = random.Next(1, 53);
                var cards = Deck1.Where(p => p.ID == SelectedNumber);
                hitCard = new Card();

                foreach (Card item in cards)
                {
                    hitCard = item;
                }

                cardInfo = String.Format(hitCard.Face + hitCard.Suite);

                if (hitCard.Face == "Ace")
                {
                    AceCount++;
                }

                Deck1.Remove(hitCard);
                if (!String.IsNullOrEmpty(cardInfo))
                {

                    playerHandValue += hitCard.Value;
                    isunique = true;
                }
            }

            while (!isunique);

            lblPlayerHand.Text = (playerHandValue).ToString();

            HandleAces();

            return cardInfo;
        }

        private void HandleAces()
        {
            if (AceCount == 1 && playerHandValue > 21)
            {
                if (SubtractCount == 0)
                {
                    playerHandValue -= 10;
                    SubtractCount++;
                }
            }

            if (AceCount == 2 && playerHandValue > 21)
            {
                if (SubtractCount == 0)
                {
                    playerHandValue -= 10;
                    SubtractCount++;

                    if (playerHandValue > 21)
                    {
                        playerHandValue -= 10;
                        SubtractCount++;
                    }
                }

                if (SubtractCount == 1 && playerHandValue > 21)
                {
                    playerHandValue -= 10;
                    SubtractCount++;

                }

            }
            if (AceCount == 3 && playerHandValue > 21)
            {
                if (SubtractCount == 0)
                {
                    playerHandValue -= 10;
                    SubtractCount++;

                    if (playerHandValue > 21)
                    {
                        playerHandValue -= 10;
                        SubtractCount++;

                        if (playerHandValue > 21)
                        {
                            playerHandValue -= 10;
                            SubtractCount++;
                        }

                    }

                }

                if (SubtractCount == 1 && playerHandValue > 21)
                {
                    playerHandValue -= 10;
                    SubtractCount++;

                    if (playerHandValue > 21)
                    {
                        playerHandValue -= 10;
                        SubtractCount++;
                    }

                }
                if (SubtractCount == 2 && playerHandValue > 21)
                {
                    playerHandValue -= 10;
                    SubtractCount++;

                }

            }
            if (AceCount == 4 && playerHandValue > 21)
            {
                if (SubtractCount == 0)
                {
                    playerHandValue -= 10;
                    SubtractCount++;

                    if (playerHandValue > 21)
                    {
                        playerHandValue -= 10;
                        SubtractCount++;

                        if (playerHandValue > 21)
                        {
                            playerHandValue -= 10;
                            SubtractCount++;

                            if (playerHandValue > 21)
                            {
                                playerHandValue -= 10;
                                SubtractCount++;
                            }
                        }


                    }

                }

                if (SubtractCount == 1 && playerHandValue > 21)
                {
                    playerHandValue -= 10;
                    SubtractCount++;

                    if (playerHandValue > 21)
                    {
                        playerHandValue -= 10;
                        SubtractCount++;
                        if (playerHandValue > 21)
                        {
                            playerHandValue -= 10;
                            SubtractCount++;
                            if (playerHandValue > 21)
                            {
                                playerHandValue -= 10;
                                SubtractCount++;
                            }
                        }


                    }

                }
                if (SubtractCount == 2 && playerHandValue > 21)
                {
                    playerHandValue -= 10;
                    SubtractCount++;
                }
                if (playerHandValue > 21)
                {
                    playerHandValue -= 10;
                    SubtractCount++;

                }
                if (SubtractCount == 3 && playerHandValue > 21)
                {
                    playerHandValue -= 10;
                    SubtractCount++;
                }

            }
            lblPlayerHand.Text = playerHandValue.ToString();
        }

        private void DealerHandleAces()
        {
            if (DealerAceCount == 1 && dealerHandValue > 21)
            {
                if (DealerSubtractCount == 0)
                {
                    dealerHandValue -= 10;
                    DealerSubtractCount++;
                }
            }

            if (DealerAceCount == 2 && dealerHandValue > 21)
            {
                if (DealerSubtractCount == 0)
                {
                    dealerHandValue -= 10;
                    DealerSubtractCount++;

                    if (dealerHandValue > 21)
                    {
                        dealerHandValue -= 10;
                        DealerSubtractCount++;
                    }
                }

                if (DealerSubtractCount == 1 && dealerHandValue > 21)
                {
                    dealerHandValue -= 10;
                    DealerSubtractCount++;

                }

            }
            if (DealerAceCount == 3 && dealerHandValue > 21)
            {
                if (DealerSubtractCount == 0)
                {
                    dealerHandValue -= 10;
                    DealerSubtractCount++;

                    if (dealerHandValue > 21)
                    {
                        dealerHandValue -= 10;
                        DealerSubtractCount++;

                        if (dealerHandValue > 21)
                        {
                            dealerHandValue -= 10;
                            DealerSubtractCount++;
                        }

                    }

                }

                if (DealerSubtractCount == 1 && dealerHandValue > 21)
                {
                    dealerHandValue -= 10;
                    DealerSubtractCount++;

                    if (dealerHandValue > 21)
                    {
                        dealerHandValue -= 10;
                        DealerSubtractCount++;
                    }

                }
                if (DealerSubtractCount == 2 && dealerHandValue > 21)
                {
                    dealerHandValue -= 10;
                    DealerSubtractCount++;

                }

            }
            if (DealerAceCount == 4 && dealerHandValue > 21)
            {
                if (DealerSubtractCount == 0)
                {
                    dealerHandValue -= 10;
                    DealerSubtractCount++;

                    if (dealerHandValue > 21)
                    {
                        dealerHandValue -= 10;
                        DealerSubtractCount++;

                        if (dealerHandValue > 21)
                        {
                            dealerHandValue -= 10;
                            DealerSubtractCount++;

                            if (dealerHandValue > 21)
                            {
                                dealerHandValue -= 10;
                                DealerSubtractCount++;
                            }
                        }


                    }

                }

                if (DealerSubtractCount == 1 && dealerHandValue > 21)
                {
                    dealerHandValue -= 10;
                    DealerSubtractCount++;

                    if (dealerHandValue > 21)
                    {
                        dealerHandValue -= 10;
                        DealerSubtractCount++;
                        if (dealerHandValue > 21)
                        {
                            dealerHandValue -= 10;
                            DealerSubtractCount++;
                            if (dealerHandValue > 21)
                            {
                                dealerHandValue -= 10;
                                DealerSubtractCount++;
                            }
                        }


                    }

                }
                if (DealerSubtractCount == 2 && dealerHandValue > 21)
                {
                    dealerHandValue -= 10;
                    DealerSubtractCount++;
                }
                if (dealerHandValue > 21)
                {
                    dealerHandValue -= 10;
                    DealerSubtractCount++;

                }
                if (DealerSubtractCount == 3 && dealerHandValue > 21)
                {
                    dealerHandValue -= 10;
                    DealerSubtractCount++;
                }

            }

        }

        public string DealerHit()
        {
            Card dealerHitCard;
            string cardInfo;
            bool isunique = false;
            do
            {
                Random random = new Random();
                int SelectedNumber = random.Next(1, 53);
                var cards = Deck1.Where(p => p.ID == SelectedNumber);
                dealerHitCard = new Card();

                foreach (Card item in cards)
                {
                    dealerHitCard = item;
                }

                if (dealerHitCard.Face == "Ace")
                {
                    DealerAceCount++;
                }

                cardInfo = String.Format(dealerHitCard.Face + dealerHitCard.Suite);
               
                Deck1.Remove(dealerHitCard);
                if (!String.IsNullOrEmpty(cardInfo))
                {

                    dealerHandValue += dealerHitCard.Value;
                    isunique = true;
                }
            }

            while (!isunique);
            DealerHandleAces();

            if (dealerHandValue > 21)
            {
                lblWinLoseBust.Text = "Dealer Bust! You Win!";
                lblDealerHandValue.Text = dealerHandValue.ToString();
                PlayerBalance = PlayerBalance + (PlayerBet * 2);
                PromptToPlayAgain();
            }
           
            return cardInfo;

        }

        public List<Card> ShuffleDeck()
        {

            List<Card> Deck = new List<Card>();

            //Hearts
            Card KingOfHearts = new Card();
            KingOfHearts.Value = 10;
            KingOfHearts.Face = "King";
            KingOfHearts.Suite = "Heart";
            KingOfHearts.ID = 1;
            Deck.Add(KingOfHearts);

            Card QueenOfHearts = new Card();
            QueenOfHearts.Value = 10;
            QueenOfHearts.Face = "Queen";
            QueenOfHearts.Suite = "Heart";
            QueenOfHearts.ID = 2;
            Deck.Add(QueenOfHearts);

            Card JackOfHearts = new Card();
            JackOfHearts.Value = 10;
            JackOfHearts.Face = "Jack";
            JackOfHearts.Suite = "Heart";
            JackOfHearts.ID = 3;
            Deck.Add(JackOfHearts);

            Card TenOfHearts = new Card();
            TenOfHearts.Value = 10;
            TenOfHearts.Face = "Ten";
            TenOfHearts.Suite = "Heart";
            TenOfHearts.ID = 4;
            Deck.Add(TenOfHearts);

            Card NineOfHearts = new Card();
            NineOfHearts.Value = 9;
            NineOfHearts.Face = "Nine";
            NineOfHearts.Suite = "Heart";
            NineOfHearts.ID = 5;
            Deck.Add(NineOfHearts);

            Card EightOfHearts = new Card();
            EightOfHearts.Value = 8;
            EightOfHearts.Face = "Eight";
            EightOfHearts.Suite = "Heart";
            EightOfHearts.ID = 6;
            Deck.Add(EightOfHearts);

            Card SevenOfHearts = new Card();
            SevenOfHearts.Value = 7;
            SevenOfHearts.Face = "Seven";
            SevenOfHearts.Suite = "Heart";
            SevenOfHearts.ID = 7;
            Deck.Add(SevenOfHearts);

            Card SixOfHearts = new Card();
            SixOfHearts.Value = 6;
            SixOfHearts.Face = "Six";
            SixOfHearts.Suite = "Heart";
            SixOfHearts.ID = 8;
            Deck.Add(SixOfHearts);

            Card FiveOfHearts = new Card();
            FiveOfHearts.Value = 5;
            FiveOfHearts.Face = "Five";
            FiveOfHearts.Suite = "Heart";
            FiveOfHearts.ID = 9;
            Deck.Add(FiveOfHearts);

            Card FourOfHearts = new Card();
            FourOfHearts.Value = 4;
            FourOfHearts.Face = "Four";
            FourOfHearts.Suite = "Heart";
            FourOfHearts.ID = 10;
            Deck.Add(FourOfHearts);

            Card ThreeOfHearts = new Card();
            ThreeOfHearts.Value = 3;
            ThreeOfHearts.Face = "Three";
            ThreeOfHearts.Suite = "Heart";
            ThreeOfHearts.ID = 11;
            Deck.Add(ThreeOfHearts);

            Card TwoOfHearts = new Card();
            TwoOfHearts.Value = 2;
            TwoOfHearts.Face = "Two";
            TwoOfHearts.Suite = "Heart";
            TwoOfHearts.ID = 12;
            Deck.Add(TwoOfHearts);

            Card AceOfHearts = new Card();
            AceOfHearts.Value = 11;
            AceOfHearts.Face = "Ace";
            AceOfHearts.Suite = "Heart";
            AceOfHearts.ID = 13;
            Deck.Add(AceOfHearts);

            //Spades
            Card KingOfSpades = new Card();
            KingOfSpades.Value = 10;
            KingOfSpades.Face = "King";
            KingOfSpades.Suite = "Spade";
            KingOfSpades.ID = 14;
            Deck.Add(KingOfSpades);

            Card QueenOfSpades = new Card();
            QueenOfSpades.Value = 10;
            QueenOfSpades.Face = "Queen";
            QueenOfSpades.Suite = "Spade";
            QueenOfSpades.ID = 15;
            Deck.Add(QueenOfSpades);

            Card JackOfSpades = new Card();
            JackOfSpades.Value = 10;
            JackOfSpades.Face = "Jack";
            JackOfSpades.Suite = "Spade";
            JackOfSpades.ID = 16;
            Deck.Add(JackOfSpades);

            Card TenOfSpades = new Card();
            TenOfSpades.Value = 10;
            TenOfSpades.Face = "Ten";
            TenOfSpades.Suite = "Spade";
            TenOfSpades.ID = 17;
            Deck.Add(TenOfSpades);

            Card NineOfSpades = new Card();
            NineOfSpades.Value = 9;
            NineOfSpades.Face = "Nine";
            NineOfSpades.Suite = "Spade";
            NineOfSpades.ID = 18;
            Deck.Add(NineOfSpades);

            Card EightOfSpades = new Card();
            EightOfSpades.Value = 8;
            EightOfSpades.Face = "Eight";
            EightOfSpades.Suite = "Spade";
            EightOfSpades.ID = 19;
            Deck.Add(EightOfSpades);

            Card SevenOfSpades = new Card();
            SevenOfSpades.Value = 7;
            SevenOfSpades.Face = "Seven";
            SevenOfSpades.Suite = "Spade";
            SevenOfSpades.ID = 20;
            Deck.Add(SevenOfSpades);

            Card SixOfSpades = new Card();
            SixOfSpades.Value = 6;
            SixOfSpades.Face = "Six";
            SixOfSpades.Suite = "Spade";
            SixOfSpades.ID = 21;
            Deck.Add(SixOfSpades);

            Card FiveOfSpades = new Card();
            FiveOfSpades.Value = 5;
            FiveOfSpades.Face = "Five";
            FiveOfSpades.Suite = "Spade";
            FiveOfSpades.ID = 22;
            Deck.Add(FiveOfSpades);

            Card FourOfSpades = new Card();
            FourOfSpades.Value = 4;
            FourOfSpades.Face = "Four";
            FourOfSpades.Suite = "Spade";
            FourOfSpades.ID = 23;
            Deck.Add(FourOfSpades);

            Card ThreeOfSpades = new Card();
            ThreeOfSpades.Value = 3;
            ThreeOfSpades.Face = "Three";
            ThreeOfSpades.Suite = "Spade";
            ThreeOfSpades.ID = 24;
            Deck.Add(ThreeOfSpades);

            Card TwoOfSpades = new Card();
            TwoOfSpades.Value = 2;
            TwoOfSpades.Face = "Two";
            TwoOfSpades.Suite = "Spade";
            TwoOfSpades.ID = 25;
            Deck.Add(TwoOfSpades);

            Card AceOfSpades = new Card();
            AceOfSpades.Value = 11;
            AceOfSpades.Face = "Ace";
            AceOfSpades.Suite = "Spade";
            AceOfSpades.ID = 26;
            Deck.Add(AceOfSpades);

            //Clubs
            Card KingOfClubs = new Card();
            KingOfClubs.Value = 10;
            KingOfClubs.Face = "King";
            KingOfClubs.Suite = "Club";
            KingOfClubs.ID = 27;
            Deck.Add(KingOfClubs);

            Card QueenOfClubs = new Card();
            QueenOfClubs.Value = 10;
            QueenOfClubs.Face = "Queen";
            QueenOfClubs.Suite = "Club";
            QueenOfClubs.ID = 28;
            Deck.Add(QueenOfClubs);

            Card JackOfClubs = new Card();
            JackOfClubs.Value = 10;
            JackOfClubs.Face = "Jack";
            JackOfClubs.Suite = "Club";
            JackOfClubs.ID = 29;
            Deck.Add(JackOfClubs);

            Card TenOfClubs = new Card();
            TenOfClubs.Value = 10;
            TenOfClubs.Face = "Ten";
            TenOfClubs.Suite = "Club";
            TenOfClubs.ID = 30;
            Deck.Add(TenOfClubs);

            Card NineOfClubs = new Card();
            NineOfClubs.Value = 9;
            NineOfClubs.Face = "Nine";
            NineOfClubs.Suite = "Club";
            NineOfClubs.ID = 31;
            Deck.Add(NineOfClubs);

            Card EightOfClubs = new Card();
            EightOfClubs.Value = 8;
            EightOfClubs.Face = "Eight";
            EightOfClubs.Suite = "Club";
            EightOfClubs.ID = 32;
            Deck.Add(EightOfClubs);

            Card SevenOfClubs = new Card();
            SevenOfClubs.Value = 7;
            SevenOfClubs.Face = "Seven";
            SevenOfClubs.Suite = "Club";
            SevenOfClubs.ID = 33;
            Deck.Add(SevenOfClubs);

            Card SixOfClubs = new Card();
            SixOfClubs.Value = 6;
            SixOfClubs.Face = "Six";
            SixOfClubs.Suite = "Club";
            SixOfClubs.ID = 34;
            Deck.Add(SixOfClubs);

            Card FiveOfClubs = new Card();
            FiveOfClubs.Value = 5;
            FiveOfClubs.Face = "Five";
            FiveOfClubs.Suite = "Club";
            FiveOfClubs.ID = 35;
            Deck.Add(FiveOfClubs);

            Card FourOfClubs = new Card();
            FourOfClubs.Value = 4;
            FourOfClubs.Face = "Four";
            FourOfClubs.Suite = "Club";
            FourOfClubs.ID = 36;
            Deck.Add(FourOfClubs);

            Card ThreeOfClubs = new Card();
            ThreeOfClubs.Value = 3;
            ThreeOfClubs.Face = "Three";
            ThreeOfClubs.Suite = "Club";
            ThreeOfClubs.ID = 37;
            Deck.Add(ThreeOfClubs);

            Card TwoOfClubs = new Card();
            TwoOfClubs.Value = 2;
            TwoOfClubs.Face = "Two";
            TwoOfClubs.Suite = "Club";
            TwoOfClubs.ID = 38;
            Deck.Add(TwoOfClubs);

            Card AceOfClubs = new Card();
            AceOfClubs.Value = 11;
            AceOfClubs.Face = "Ace";
            AceOfClubs.Suite = "Club";
            AceOfClubs.ID = 39;
            Deck.Add(AceOfClubs);

            //Diamonds
            Card KingOfDiamonds = new Card();
            KingOfDiamonds.Value = 10;
            KingOfDiamonds.Face = "King";
            KingOfDiamonds.Suite = "Diamond";
            KingOfDiamonds.ID = 40;
            Deck.Add(KingOfDiamonds);

            Card QueenOfDiamonds = new Card();
            QueenOfDiamonds.Value = 10;
            QueenOfDiamonds.Face = "Queen";
            QueenOfDiamonds.Suite = "Diamond";
            QueenOfDiamonds.ID = 41;
            Deck.Add(QueenOfDiamonds);

            Card JackOfDiamonds = new Card();
            JackOfDiamonds.Value = 10;
            JackOfDiamonds.Face = "Jack";
            JackOfDiamonds.Suite = "Diamond";
            JackOfDiamonds.ID = 42;
            Deck.Add(JackOfDiamonds);

            Card TenOfDiamonds = new Card();
            TenOfDiamonds.Value = 10;
            TenOfDiamonds.Face = "Ten";
            TenOfDiamonds.Suite = "Diamond";
            TenOfDiamonds.ID = 43;
            Deck.Add(TenOfDiamonds);

            Card NineOfDiamonds = new Card();
            NineOfDiamonds.Value = 9;
            NineOfDiamonds.Face = "Nine";
            NineOfDiamonds.Suite = "Diamond";
            NineOfDiamonds.ID = 44;
            Deck.Add(NineOfDiamonds);

            Card EightOfDiamonds = new Card();
            EightOfDiamonds.Value = 8;
            EightOfDiamonds.Face = "Eight";
            EightOfDiamonds.Suite = "Diamond";
            EightOfDiamonds.ID = 45;
            Deck.Add(EightOfDiamonds);

            Card SevenOfDiamonds = new Card();
            SevenOfDiamonds.Value = 7;
            SevenOfDiamonds.Face = "Seven";
            SevenOfDiamonds.Suite = "Diamond";
            SevenOfDiamonds.ID = 46;
            Deck.Add(SevenOfDiamonds);

            Card SixOfDiamonds = new Card();
            SixOfDiamonds.Value = 6;
            SixOfDiamonds.Face = "Six";
            SixOfDiamonds.Suite = "Diamond";
            SixOfDiamonds.ID = 47;
            Deck.Add(SixOfDiamonds);

            Card FiveOfDiamonds = new Card();
            FiveOfDiamonds.Value = 5;
            FiveOfDiamonds.Face = "Five";
            FiveOfDiamonds.Suite = "Diamond";
            FiveOfDiamonds.ID = 48;
            Deck.Add(FiveOfDiamonds);

            Card FourOfDiamonds = new Card();
            FourOfDiamonds.Value = 4;
            FourOfDiamonds.Face = "Four";
            FourOfDiamonds.Suite = "Diamond";
            FourOfDiamonds.ID = 49;
            Deck.Add(FourOfDiamonds);

            Card ThreeOfDiamonds = new Card();
            ThreeOfDiamonds.Value = 3;
            ThreeOfDiamonds.Face = "Three";
            ThreeOfDiamonds.Suite = "Diamond";
            ThreeOfDiamonds.ID = 50;
            Deck.Add(ThreeOfDiamonds);

            Card TwoOfDiamonds = new Card();
            TwoOfDiamonds.Value = 2;
            TwoOfDiamonds.Face = "Two";
            TwoOfDiamonds.Suite = "Diamond";
            TwoOfDiamonds.ID = 51;
            Deck.Add(TwoOfDiamonds);

            Card AceOfDiamonds = new Card();
            AceOfDiamonds.Value = 11;
            AceOfDiamonds.Face = "Ace";
            AceOfDiamonds.Suite = "Diamond";
            AceOfDiamonds.ID = 52;
            Deck.Add(AceOfDiamonds);


            return Deck;


        }


        public void DealCards(List<Card> Deck)
        {
            Card card1;
            Card card2;
            Card card3;
            Card card4;
            dealercardpic2.Attributes["src"] = ResolveUrl("~/Images/Cardback.jpg");
            //player card1
            bool isunique = false;
            do
            {
                Random random = new Random();
                int SelectedNumber = random.Next(1, 53);
                var cards = Deck.Where(p => p.ID == SelectedNumber);
                card1 = new Card();

                foreach (Card item in cards)
                {
                    card1 = item;
                }

                lblPlayerCard1.Text = String.Format(card1.Face + card1.Suite);
               
                Deck.Remove(card1);
                if (card1.Face != null)
                {
                    playerHandValue = card1.Value;
                    isunique = true;
                }
            }

            while (!isunique);

            //player card 2
            bool isunique2 = false;
            do
            {
                Random random = new Random();
                int SelectedNumber = random.Next(1, 53);
                var cards = Deck.Where(p => p.ID == SelectedNumber);
                card2 = new Card();

                foreach (Card item in cards)
                {
                    card2 = item;
                }

                lblPlayerCard2.Text = String.Format(card2.Face + card2.Suite);
            
                Deck.Remove(card2);
                if (card2.Face != null)
                {

                    playerHandValue += card2.Value;
                    isunique2 = true;
                }
            }

            while (!isunique2);
            
            bool isunique3 = false;
            do
            {
                Random random = new Random();
                int SelectedNumber = random.Next(1, 53);
                var cards = Deck.Where(p => p.ID == SelectedNumber);
                card3 = new Card();

                foreach (Card item in cards)
                {
                    card3 = item;
                }

                lblDealerCard1.Text = String.Format(card3.Face + card3.Suite);
                
                Deck.Remove(card3);
                if (card3.Face != null)
                {

                    dealerHandValue = card3.Value;
                    isunique3 = true;
                    lblDealerHandValue.Text = card3.Value.ToString();
                }
            }

            while (!isunique3);
            
            bool isunique4 = false;
            do
            {
                Random random = new Random();
                int SelectedNumber = random.Next(1, 53);
                var cards = Deck.Where(p => p.ID == SelectedNumber);
                card4 = new Card();

                foreach (Card item in cards)
                {
                    card4 = item;
                }

                lblDealerCard2.Text = String.Format(card4.Face + card4.Suite);
               
                Deck.Remove(card4);

                if (card4.Face != null)
                {
                    dealerHandValue += card4.Value;
                    isunique4 = true;
                }

            }

            while (!isunique4);


            if (card1.Face == "Ace" || card2.Face == "Ace")
            {
                if (playerHandValue != 21)
                {
                    lblPlayerHand.Text = playerHandValue.ToString() + @"/" + (playerHandValue - 10).ToString();
                    AceCount++;
                }

                if (card1.Face == "Ace" && card2.Face == "Ace")
                {
                    AceCount++;
                    playerHandValue -= 10;
                    SubtractCount++;
                    lblPlayerHand.Text = @"12/2";

                }

                if (playerHandValue == 21 && dealerHandValue != 21)
                {
                    lblDealerHandValue.Text = dealerHandValue.ToString();
                    lblWinLoseBust.Text = "BlackJack! You Win";
                    PlayerBalance = PlayerBalance + (PlayerBet * 2) + (PlayerBet / 2);
                    PromptToPlayAgain();
                    dealercardpic2.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblDealerCard2.Text}.jpg"); ;

                }
            }

            else lblPlayerHand.Text = playerHandValue.ToString();

            if (card3.Face == "Ace" || card4.Face == "Ace")
            {
                if (playerHandValue != 21)
                {


                    DealerAceCount++;

                }

                if (card3.Face == "Ace" && card4.Face == "Ace")
                {
                    DealerAceCount++;
                    dealerHandValue -= 10;
                    DealerSubtractCount++;

                }

                if (playerHandValue == 21 && dealerHandValue == 21)
                {
                    lblDealerHandValue.Text = dealerHandValue.ToString();
                    lblWinLoseBust.Text = "Push!";
                    PlayerBalance += PlayerBet;
                    PromptToPlayAgain();
                    dealercardpic2.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblDealerCard2.Text}.jpg");

                }

                if (dealerHandValue == 21 && playerHandValue != 21)
                {
                    lblDealerHandValue.Text = dealerHandValue.ToString();
                    lblWinLoseBust.Text = "Dealer BlackJack. You lose!";
                    btnHit.Visible = false;
                    btnStay.Visible = false;
                    btnDoubleDown.Visible = false;
                    PromptToPlayAgain();

                    dealercardpic2.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblDealerCard2.Text}.jpg");
                }
            }



            dealercardpic1.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblDealerCard1.Text}.jpg");
            playercardpic1.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblPlayerCard1.Text}.jpg");
            playercardpic2.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblPlayerCard2.Text}.jpg");

        }



        public class Card
        {
            public int Value { get; set; }
            public string Face { get; set; }
            public string Suite { get; set; }
            public int ID { get; set; }
        }

        


        public void DetermineWinner(int player, int dealer)
        {
            dealercardpic2.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblDealerCard2.Text}.jpg");
            if (player > dealer && playerHandValue <= 21)
            {
                lblDealerHandValue.Text = dealerHandValue.ToString();
                lblWinLoseBust.Text = "You win!";
                PlayerBalance = PlayerBalance + (PlayerBet * 2);
            }
            else if (player == dealer)
            {
                lblDealerHandValue.Text = dealerHandValue.ToString();
                lblWinLoseBust.Text = "Push!";
                PlayerBalance += PlayerBet;

            }
            else if (dealer <= 21 && dealer > player)
            {
                lblDealerHandValue.Text = dealerHandValue.ToString();
                lblWinLoseBust.Text = "You lose!";
            }
            else if (dealer > 21 && player > dealer)
            {
                lblDealerHandValue.Text = dealerHandValue.ToString();
                lblWinLoseBust.Text = "You Win!";
                PlayerBalance = PlayerBalance + (PlayerBet * 2);
            }
            else if (dealer > 21 && player <= 21)
            {
                lblDealerHandValue.Text = dealerHandValue.ToString();
                lblWinLoseBust.Text = "Dealer Bust! You win!";
                PlayerBalance = PlayerBalance + (PlayerBet * 2);

            }
            else
            {
                lblWinLoseBust.Text = "You lose!";
            }
            lblDealerHandValue.Text = dealerHandValue.ToString();
            PromptToPlayAgain();



        }


       
        

        public void PromptToPlayAgain()
        {
            lblWinLoseBust.Visible = true;
            

            DisplayChips();


            var cookie = Request.Cookies["Balance"];
            cookie.Values["balance"] = PlayerBalance.ToString();
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);

            if (PlayerBalance == 0)
            {
                btnReplenish.Visible = true;
                btnStay.Visible = false;
                btnHit.Visible = false;
                btnDoubleDown.Visible = false;


            }

            if (PlayerBalance != 0)
                {
                btnReplenish.Visible = false;
                btnStay.Visible = false;
                btnHit.Visible = false;
                btnDoubleDown.Visible = false;
                btnPlayAgain.Visible = true;

                lblDealerHandValue.Visible = true;
                PlayerBet = 0;
                lblYourBet.Text = $"Your Bet: ${PlayerBet}";
                lblPlayerBalance.Text = $"Balance: ${PlayerBalance}";
                DisplayChips();
            }

           



        }

        protected void btnDeal_Click1(object sender, EventArgs e)
        {
            if (PlayerBet == 0)
            {
                lblWinLoseBust.Visible = true;
                lblWinLoseBust.Text = "Please place a bet.";

            }

            if (PlayerBet != 0)
            {
                btnClearBet.Visible = false;
                lblWinLoseBust.Visible = false;
                chip1.Enabled = false;
                chip5.Enabled = false;
                chip10.Enabled = false;
                chip25.Enabled = false;
                chip50.Enabled = false;
                chip100.Enabled = false;
                chip500.Enabled = false;

                Deck1 = ShuffleDeck();

                btnDeal.Visible = false;


                btnHit.Visible = true;
                btnStay.Visible = true;

                if (PlayerBalance >= (PlayerBet))
                {
                    btnDoubleDown.Visible = true;
                }

                lblDealerHandValue.Visible = true;
                lblPlayerHand.Visible = true;


                DealCards(Deck1);
            }

            lblInsufficentBalance.Visible = false;
        }

        protected void btnHit_Click1(object sender, EventArgs e)
        {
            HitClicks++;
            if (HitClicks == 1)
            {

                lblHitCard1.Text = Hit();
                playercardpic3.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblHitCard1.Text}.jpg");
            }
            else if (HitClicks == 2)
            {
                lblHitCard2.Text = Hit();
                playercardpic4.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblHitCard2.Text}.jpg");

            }
            else if (HitClicks == 3)
            {
                lblHitCard3.Text = Hit();
                playercardpic5.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblHitCard3.Text}.jpg");
            }

            if (playerHandValue > 21)
            {
                lblDealerHandValue.Text = dealerHandValue.ToString();
                lblWinLoseBust.Text = "Bust! You Lose!";
                dealercardpic2.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblDealerCard2.Text}.jpg");
                PromptToPlayAgain();

            }
        }

        public void Stay()
        {
            lblPlayerHand.Text = playerHandValue.ToString();
            if (dealerHandValue < 17)
            {
                lblDealerHitCard.Text = DealerHit();
                dealercardpic3.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblDealerHitCard.Text}.jpg");

            }

            if (dealerHandValue < 17)
            {
                lblDealerHitCard2.Text = DealerHit();
                dealercardpic4.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblDealerHitCard2.Text}.jpg");
            }
            if (dealerHandValue < 17)
            {
                lblDealerHitCard3.Text = DealerHit();
                dealercardpic5.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblDealerHitCard3.Text}.jpg");
            }
            lblDealerHandValue.Text = dealerHandValue.ToString();



            DetermineWinner(playerHandValue, dealerHandValue);
            lblWinLoseBust.Visible = true;
            btnHit.Visible = false;
            btnStay.Visible = false;
            btnDoubleDown.Visible = false;
            PromptToPlayAgain();


            dealercardpic2.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblDealerCard2.Text}.jpg");


        }

        protected void btnStay_Click1(object sender, EventArgs e)
        {
            Stay();
        }

        protected void btnPlayAgain_Click1(object sender, EventArgs e)
        {
            playerHandValue = 0;
            dealerHandValue = 0;
            Deck1 = ShuffleDeck();

            lblDealerCard1.Text = "";
            lblDealerCard2.Text = "";
            lblDealerHandValue.Text = "";
            lblPlayerCard1.Text = "";
            lblPlayerCard2.Text = "";

            lblDealerHitCard.Text = null;
            lblPlayerHand.Text = "";
            lblWinLoseBust.Text = "";

            btnDeal.Visible = true;
            btnPlayAgain.Visible = false;
            HitClicks = 0;
            AceCount = 0;
            DealerAceCount = 0;
            SubtractCount = 0;
            DealerSubtractCount = 0;

            playercardpic1.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            playercardpic2.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            playercardpic3.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            playercardpic4.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            playercardpic5.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");

            dealercardpic1.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            dealercardpic2.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            dealercardpic3.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            dealercardpic4.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            dealercardpic5.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");

            chip1.Enabled = true;
            chip5.Enabled = true;
            chip10.Enabled = true;
            chip25.Enabled = true;
            chip50.Enabled = true;
            chip100.Enabled = true;
            chip500.Enabled = true;

        }

        protected void chip1_Click(object sender, ImageClickEventArgs e)
        {
            lblInsufficentBalance.Visible = false;
            btnClearBet.Visible = true;
            if (PlayerBalance >= 1)
            {
                PlayerBalance -= 1;
                PlayerBet += 1;
                lblYourBet.Text = $"Your Bet: ${PlayerBet}";
                lblPlayerBalance.Text = $"Balance: ${PlayerBalance}";
            }
            else
                lblInsufficentBalance.Visible = true;
            
        }

        protected void chip5_Click(object sender, ImageClickEventArgs e)
        {
            lblInsufficentBalance.Visible = false;
            btnClearBet.Visible = true;
            if (PlayerBalance >= 5)
            {
                PlayerBalance -= 5;
                PlayerBet += 5;
                lblYourBet.Text = $"Your Bet: ${PlayerBet}";
                lblPlayerBalance.Text = $"Balance: ${PlayerBalance}";
            }
            else
                lblInsufficentBalance.Visible = true;

        }

        protected void chip10_Click(object sender, ImageClickEventArgs e)
        {
            lblInsufficentBalance.Visible = false;
            btnClearBet.Visible = true;
            if (PlayerBalance >= 10)
            {
                PlayerBalance -= 10;
                PlayerBet += 10;
                lblYourBet.Text = $"Your Bet: ${PlayerBet}";
                lblPlayerBalance.Text = $"Your Balance: ${PlayerBalance}";
            }
            else
                lblInsufficentBalance.Visible = true;
        }

        protected void chip25_Click(object sender, ImageClickEventArgs e)
        {
            lblInsufficentBalance.Visible = false;
            btnClearBet.Visible = true;
            if (PlayerBalance >= 25)
            {
                PlayerBalance -= 25;
                PlayerBet += 25;
                lblYourBet.Text = $"Your Bet: ${PlayerBet}";
                lblPlayerBalance.Text = $"Balance: ${PlayerBalance}";
            }
            else
                lblInsufficentBalance.Visible = true;
        }

        protected void chip50_Click(object sender, ImageClickEventArgs e)
        {
            lblInsufficentBalance.Visible = false;
            btnClearBet.Visible = true;
            if (PlayerBalance >= 50)
            {
                PlayerBalance -= 50;
                PlayerBet += 50;
                lblYourBet.Text = $"Your Bet: ${PlayerBet}";
                lblPlayerBalance.Text = $"Balance: ${PlayerBalance}";
            }
            else
                lblInsufficentBalance.Visible = true;
        }

        protected void chip100_Click(object sender, ImageClickEventArgs e)
        {
            lblInsufficentBalance.Visible = false;
            btnClearBet.Visible = true;
            if (PlayerBalance >= 100)
            {
                PlayerBalance -= 100;
                PlayerBet += 100;
                lblYourBet.Text = $"Your Bet: ${PlayerBet}";
                lblPlayerBalance.Text = $"Balance: ${PlayerBalance}";
            }
            else
                lblInsufficentBalance.Visible = true;
        }

        protected void chip500_Click(object sender, ImageClickEventArgs e)
        {
            lblInsufficentBalance.Visible = false;
            btnClearBet.Visible = true;
            if (PlayerBalance >= 500)
            {
                PlayerBalance -= 500;
                PlayerBet += 500;
                lblYourBet.Text = $"Your Bet: ${PlayerBet}";
                lblPlayerBalance.Text = $"Balance: ${PlayerBalance}";
            }
            else
                lblInsufficentBalance.Visible = true;
        }

        protected void btnReplenish_Click(object sender, EventArgs e)
        {
            PlayerBalance = 250;
            playercardpic1.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            playercardpic2.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            playercardpic3.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            playercardpic4.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            playercardpic5.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");

            dealercardpic1.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            dealercardpic2.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            dealercardpic3.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            dealercardpic4.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            dealercardpic5.Attributes["src"] = ResolveUrl("~/Images/BlankCard.PNG");
            PromptToPlayAgain();
            lblWinLoseBust.Visible = false;
            lblPlayerHand.Visible = false;
            lblDealerHandValue.Visible = false;
        }

        protected void btnClearBet_Click(object sender, EventArgs e)
        {
            PlayerBalance += PlayerBet;
            PlayerBet = 0;
            lblPlayerBalance.Text = $"Balance: ${PlayerBalance}";
            lblYourBet.Text = $"Your Bet: ${PlayerBet}";
            btnClearBet.Visible = false;

        }

        protected void btnDoubleDown_Click(object sender, EventArgs e)
        {
            PlayerBalance -= PlayerBet;
            PlayerBet += PlayerBet;
            lblPlayerBalance.Text = $"Balance: ${PlayerBalance}";
            lblYourBet.Text = $"Your Bet: ${PlayerBet}";

            lblHitCard1.Text = Hit();
            playercardpic3.Attributes["src"] = ResolveUrl("~/Images/" + $"{lblHitCard1.Text}.jpg");
            Stay();

            btnDoubleDown.Visible = false;
        }
    }
}