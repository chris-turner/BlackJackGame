<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlackJack.aspx.cs" Inherits="BlackJackGame.BlackJack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Black Jack Game</title>
    <link href="StyleSheet1.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h3 id="BlackJackHeader">Single Deck Black Jack</h3>
            </div>

        <img id="DealerPicture" runat="server" src="~/Images/BlackJackDealer.png" />
        
        <img id="dealercardpic1" runat="server" src="~/Images/BlankCard.PNG" />
        <img id="dealercardpic2" runat="server" src="~/Images/BlankCard.PNG" /> 
        <img id="dealercardpic3" runat="server" src="~/Images/BlankCard.PNG" />
        <img id="dealercardpic4" runat="server" src="~/Images/BlankCard.PNG" />
        <img id="dealercardpic5" runat="server" src="~/Images/BlankCard.PNG" />
        <img id="playercardpic3" runat="server" src="~/Images/BlankCard.PNG" />
        <img id="playercardpic4" runat="server" src="~/Images/BlankCard.PNG" />
        <img id="playercardpic5" runat="server" src="~/Images/BlankCard.PNG" />

        <img id="playercardpic2" runat="server" src="~/Images/BlankCard.PNG" />
    <img id="playercardpic1" runat="server" src="~/Images/BlankCard.PNG" />

        <asp:Label ID="DealerLabel" runat="server" Text="Dealer" Visible="True"></asp:Label>
        <asp:Label ID="PlayerLabel" runat="server" Text="Player 1" Visible="True"></asp:Label>

        <asp:Label ID="lblDealerCard1" runat="server" Text="lblDealerCard1" Visible="False"></asp:Label>
        <asp:Label ID="lblDealerCard2" runat="server" Text="lblDealerCard2" Visible="False"></asp:Label>
        <asp:Label ID="lblDealerHitCard" runat="server" Text="lblDealerHitCard" Visible="False"></asp:Label>
        <asp:Label ID="lblDealerHitCard2" runat="server" Text="lblDealerHitCard2" Visible="False"></asp:Label>
        <asp:Label ID="lblDealerHitCard3" runat="server" Text="lblDealerHitCard3" Visible="False"></asp:Label>

        <asp:Label ID="lblPlayerCard1" runat="server" Text="lblPlayerCard1" Visible="False"></asp:Label>
        <asp:Label ID="lblPlayerCard2" runat="server" Text="lblPlayerCard2" Visible="False"></asp:Label>
        <asp:Label ID="lblHitCard1" runat="server" Text="lblHitCard1" Visible="False"></asp:Label>
        <asp:Label ID="lblHitCard2" runat="server" Text="lblHitCard2" Visible="False"></asp:Label>
        <asp:Label ID="lblHitCard3" runat="server" Text="lblHitCard3" Visible="False"></asp:Label>

        <asp:Label ID="lblPlayerHand" runat="server" Text="lblPlayerHand" Visible="False"></asp:Label>
        <asp:Label ID="lblDealerHandValue" runat="server" Text="lblDealerHandValue" Visible="False"></asp:Label>
        <asp:Label ID="lblWinLoseBust" runat="server" Text="lblWinLoseBust" Visible="False"></asp:Label>

        <asp:Label ID="lblYourBet" runat="server" Text="Your Bet: $0" Visible ="true" ></asp:Label>
        <asp:Label ID="lblPlayerBalance" runat="server" Text="Balance:" Visible ="true" ></asp:Label>
        <asp:Label ID="lblInsufficentBalance" runat="server" Text="Insufficent Funds. Try a smaller amount." Visible ="false" ></asp:Label>
        
        
        <asp:Button ID="btnDeal" runat="server" Text="Deal" OnClick="btnDeal_Click1" />
        <asp:Button ID="btnClearBet" runat="server" Text="Clear Bet" OnClick="btnClearBet_Click" Visible="False" />
         <asp:Button ID="btnPlayAgain" runat="server" Text="Play Again" Visible="False" OnClick="btnPlayAgain_Click1" />
         <asp:Button ID="btnHit" runat="server" Text="Hit" Visible="False" OnClick="btnHit_Click1" />
         <asp:Button ID="btnStay" runat="server" Text="Stay" Visible="False" OnClick="btnStay_Click1" />
        <asp:Button ID="btnDoubleDown" runat="server" Text="Double Down" Visible="False" OnClick="btnDoubleDown_Click" />
        <asp:Button ID="btnReplenish" runat="server" Text="Replenish Balance" Visible="False" OnClick="btnReplenish_Click" />

    
        <asp:ImageButton ID="chip1" ImageUrl="~/Images/chip1.png" runat="server" OnClick="chip1_Click" />
        <asp:ImageButton ID="chip5" ImageUrl="~/Images/chip5.png" runat="server" Visible="False" OnClick="chip5_Click" />
        <asp:ImageButton ID="chip10" ImageUrl="~/Images/chip10.png" runat="server" Visible="False" OnClick="chip10_Click" />
        <asp:ImageButton ID="chip25" ImageUrl="~/Images/chip25.png" runat="server" Visible="False" OnClick="chip25_Click" />
        <asp:ImageButton ID="chip50" ImageUrl="~/Images/chip50.png" runat="server" Visible="False" OnClick="chip50_Click" />
        <asp:ImageButton ID="chip100" ImageUrl="~/Images/chip100.png" runat="server" Visible="False" OnClick="chip100_Click" />
         <asp:ImageButton ID="chip500" ImageUrl="~/Images/chip500.png" runat="server" Visible="False" OnClick="chip500_Click" />
    
        </form>
        
                
        
</body>
</html>
