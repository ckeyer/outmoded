package PPoker;

public class CPoker 
{
	int id;
	CCard cards[] = new CCard[54];
	private CCard handone[] = new CCard[17];
	private CCard handtwo[] = new CCard[17];
	private CCard handthree[] = new CCard[17];
	public CCard OnTable[] = new CCard[3];
	CPlayer Landlord;
	
	public CPoker(int id)
	{
		this.id = id;
		int n=0;
		int suit,rank;
		for(rank = CCard.THREE ; rank <= CCard.DEUCE ; rank++ )
		{
			for(suit = CCard.SPADE; suit <= CCard.DIAMOND ;suit++)
			{
				this.cards[n++]= new CCard(suit, rank);
			}
		}
		cards[n++]= new CCard(CCard.BLACK,CCard.JOKER);
		cards[n++]=new CCard(CCard.RED ,CCard.JOKER);
	}
	
	// 新牌
	public void setPoker()
	{
		int n=0;
		int suit,rank;
		for(rank = CCard.THREE ; rank <= CCard.DEUCE ; rank++ )
		{
			for(suit = CCard.HEART; suit <= CCard.CLUB ;suit++)
			{
				this.cards[n++]= new CCard(suit, rank);
			}
		}
		cards[n++]= new CCard(CCard.BLACK,CCard.JOKER);
		cards[n++]=new CCard(CCard.RED ,CCard.JOKER);
	}

	public String getPoker(int i)
	{
		return this.cards[i].getSuitName() + this.cards[i].getRankName();
	}
	
	//洗牌
	public void shuffle()
	{
		int N=5;
		int rand;
		int c[] = new int[54];
		for(int i=0;i<54;i++)
		{
			c[i]=i;
		}
		for(int n=0;n<N;n++)
		{	
			for(int i=0;i<54;i++)
			{
				rand = (int)(Math.random()*54);
				CCard j = new CCard();
				j = this.cards[i];
				this.cards[i]=this.cards[rand];
				this.cards[rand]=j;
			}
		}
	}
	
	public void shuffle(int N)
	{
		if(1>N || 65535<N)N=1;
		int rand;
		int c[] = new int[54];
		for(int i=0;i<54;i++)
		{
			c[i]=i;
		}
		for(int n=0;n<N;n++)
		{	
			for(int i=0;i<54;i++)
			{
				rand = (int)(Math.random()*54);
				CCard j = new CCard();
				j = this.cards[i];
				this.cards[i]=this.cards[rand];
				this.cards[rand]=j;
			}
		}
	}
	
	// 分牌 返回底牌
	public CPlayer deal(CPlayer one,CPlayer two ,CPlayer three)
	{
		for(int i=0 ;i < 17;i++)
		{
			handone[i]=this.cards[i*3];
			handtwo[i]=this.cards[i*3+1];
			handthree[i]=this.cards[i*3+2];
		}
		this.OnTable[0] = this.cards[51];
		this.OnTable[1] = this.cards[52];
		this.OnTable[2] = this.cards[53];
		
		//给玩家分牌
		one.InHand = this.handone;
		two.InHand = this.handtwo;
		three.InHand = this.handthree;
		
		int rand = (int) (Math.random()*3);;
		switch(rand)
		{
		case 0:	return one;
		case 1:	return two;
		case 2:	return three;
		default : return null;
		}
	}
	
	public CCard[] getOnTable()
	{
		return this.OnTable;
	}
	
	public CPlayer getLandLord()
	{
		return this.Landlord;
	}
	
	public int hashCode()
	{
		return id;
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
		if(obj instanceof CPoker)
		{
			CPoker other = (CPoker) obj;
			return (this.id == other.id);
		}
		return false;
    }
}
