using System;
using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
    int dealersFirstCard = -1;
    int PlayerBet;
    int PlayerBank = 3000;

    public CardStack player;
    public CardStack dealer;
    public CardStack deck;

    public Button hitButton;
    public Button stickButton;
    public Button playAgainButton;
    public Button ExitToMenuButton;
    public Button OneDollarButton;
    public Button FiveDollarsButton;
    public Button TenDollarsButton;
    public Button QuarterButton;
    public Button HundrerBotton;
    public Button DealButton;

    public Text PlayerBankText;
    public Text PlayerBetsText;

    public Text winnerText;
    
    /*
     * Cards dealt to each player
     * First player hits/sticks/bust
     * Dealer's turn; must have minimum of 17 score hand
     * Dealers cards; first card is hidden, subsequent cards are facing
     */

    #region Public methods
    public void Hit()
    {
        player.Push(deck.Pop());
        if (player.HandValue() > 21)
        {
            HitStickLock(false);
            StartCoroutine(DealersTurn());
        }
    }

    public void Stick()
    {
        hitButton.interactable = false;
        stickButton.interactable = false;
        StartCoroutine(DealersTurn());
    }

    public void PlayAgain()
    {
        playAgainButton.interactable = false;

        player.GetComponent<CardStackView>().Clear();
        dealer.GetComponent<CardStackView>().Clear();
        deck.GetComponent<CardStackView>().Clear();
        deck.CreateDeck();

        winnerText.text = "";

        BetsBlock(true);

        dealersFirstCard = -1;

        MakingBet();
    }

    public void ExitToMenu()
    {
        Application.LoadLevel(0);
    }

    public void OneDollar()
    {
        winnerText.text = "";
        if (PlayerBank >= 1)
        {
            PlayerBet++;
            PlayerBank--;
        }
        else
        {
            winnerText.text = "Вы не можете поставить больше.";
        }
        CashRefresh();
    }
    public void FiveDollars()
    {
        winnerText.text = "";
        if (PlayerBank >= 5)
        {
            PlayerBet += 5;
            PlayerBank -= 5;
        }
        else
        {
            winnerText.text = "Вы не можете поставить больше.";
        }
        CashRefresh();
    }
    public void TenDollars()
    {
        winnerText.text = "";
        if (PlayerBank >= 10)
        {
            PlayerBet += 10;
            PlayerBank -= 10;
        }
        else
        {
            winnerText.text = "Вы не можете поставить больше.";
        }
        CashRefresh();
    }
    public void QuarterDollars()
    {
        winnerText.text = "";
        if (PlayerBank >= 25)
        {
            PlayerBet += 25;
            PlayerBank -= 25;
        }
        else
        {
            winnerText.text = "Вы не можете поставить больше.";
        }
        CashRefresh();
    }
    public void HundredDollars()
    {
        winnerText.text = "";
        if (PlayerBank >= 100)
        {
            PlayerBet += 100;
            PlayerBank -= 100;
        }
        else
        {
            winnerText.text = "Вы не можете поставить больше.";
        }
        CashRefresh();
    }


    public void Deal()
    {
        winnerText.text = "";
        if (PlayerBet > 0)
        {
            BetsBlock(false);
            HitStickLock(true);
            StartGame();
        }
        else
        {
            winnerText.text = "Прежде чем начать игру, нужно сделать ставку.";
        }
    }


    #endregion

    #region Unity messages

    void Start()
    {
        PlayerBankText.text = "Банк: " + PlayerBank;
        MakingBet();
    }


    #endregion

    void CashRefresh()
    {
        PlayerBankText.text = "Банк: " + PlayerBank;
        PlayerBetsText.text = "Ставка: " + PlayerBet;
    }

    void BetsBlock(bool a)
    {
        OneDollarButton.interactable = a;
        FiveDollarsButton.interactable = a;
        TenDollarsButton.interactable = a;
        QuarterButton.interactable = a;
        HundrerBotton.interactable = a;
        DealButton.interactable = a;
    }

    void HitStickLock(bool a)
    {
        hitButton.interactable = a;
        stickButton.interactable = a;
    }

    void MakingBet()
    {
        if (PlayerBank > 0)
        {
            PlayerBet = 0;
            CashRefresh();
            HitStickLock(false);
            DealButton.interactable = true;
        }
        else
        {
            winnerText.text = "Вы не можете продолжать игру";
        }
    }

    void StartGame()
    {
        winnerText.text = "";
        for (int i = 0; i < 2; i++)
        {
            player.Push(deck.Pop());
            
            HitDealer();
        }
    }

    void HitDealer()
    {
        int card = deck.Pop();

        if (dealersFirstCard < 0)
        {
            dealersFirstCard = card;
        }

        dealer.Push(card);
        if (dealer.CardCount >= 2)
        {
            CardStackView view = dealer.GetComponent<CardStackView>();
            view.Toggle(card, true);
        }
    }

    IEnumerator DealersTurn()
    {
        hitButton.interactable = false;
        stickButton.interactable = false;

        CardStackView view = dealer.GetComponent<CardStackView>();
        
        view.Toggle(dealersFirstCard, true);
        view.ShowCards();
        yield return new WaitForSeconds(1f);

        while (dealer.HandValue() < 17)
        {
            HitDealer();
            yield return new WaitForSeconds(1f);
        } 

        if (player.HandValue() > 21 || (dealer.HandValue() >= player.HandValue() && dealer.HandValue() <= 21))
        {
            winnerText.text = "Вы проиграли";
        }
        else if (dealer.HandValue() > 21 || (player.HandValue() <= 21 && player.HandValue() > dealer.HandValue()))
        {
            winnerText.text = "Вы выиграли!";
            PlayerBet = PlayerBet * 2; 
            PlayerBank = PlayerBank + PlayerBet;
        }
        else
        {
            winnerText.text = "The house wins!";
        }

        yield return new WaitForSeconds(1f);
        playAgainButton.interactable = true;
    }
}
