package PTest;

public class CCard {
	int suit;	//花色
	int rank;	//点数

	public final static int THREE = 1;
	public final static int FOUR = 2;
	public final static int FIVE = 3;
	public final static int SIX = 4;
	public final static int SEVEN = 5;
	public final static int EIGHT = 6;
	public final static int NINE = 7;
	public final static int TEN = 8;
	public final static int JACK = 9;
	public final static int QUEEN = 10;
	public final static int KING = 11;
	public final static int ACE = 12;
	public final static int DEUCE = 13;
	
	public final static int JOKER = 14;
	

	public final static int SPADE = 1;	//黑桃
	public final static int HEART = 2;	//红桃
	public final static int CLUB = 3;	//草花
	public final static int DIAMOND = 4;	//方块
	public final static int BLACK = 5;	//小
	public final static int RED = 6;	//大
	
	
	public final static String[] SuitName = {"黑桃","红桃","梅花","方块","小","大"};
	public final static String[] RankName = "3,4,5,6,7,8,9,10,J,Q,K,A,2,王".split(",");
	
	public CCard(){}
	public CCard(int isuit,int irank)
	{
		this.setSuit(isuit);
		this.setRank(irank);
	}
	
	public void setSuit (int suit)
	{
		if(suit < SPADE || suit > RED)
			throw new IllegalArgumentException("花色选择出错!!!");
		
		this.suit = suit;
	}
	
	public void setRank(int rank)
	{
		if(rank < THREE || rank > JOKER)
			throw new IllegalArgumentException("点数选择出错!!!");
		
		this.rank = rank;
	}
	
	public void setCard(int suit,int rank)
	{
		this.setSuit(suit);
		this.setRank(rank);
	}
	
	public int getRank()
	{
		return this.rank;
	}
	
	public int getSuit()
	{
		return this.suit;
	}
	
	public String getSuitName()
	{
		return CCard.SuitName[this.suit-1];
	}
	
	public String getRankName()
	{
		return CCard.RankName[this.rank-1];
	}
	
	public String getCard()
	{
		return this.getSuitName() + this.getRankName();
	}
	
	public String toString()
	{
		return this.getSuitName() + this.getRankName();
	}
	
	public int hashCode()
	{
		return this.suit*100+this.rank;
	}
	
	public boolean equals(Object obj) 
	{
		if(null == obj) 
		{
			return false;
		}
		if(obj == this)
		{
			return true;
		}
		if(obj instanceof CCard)
		{
			CCard other = (CCard) obj;
			return (this.suit == other.suit && this.rank == other.rank);
		}
		return false;
    }
}
