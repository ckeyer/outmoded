package PPoker;

public class CPlayer {
	// Conventional attributes
	int id;
	String name;
	int mark = 0;	// 分数
	int WinTimes = 0;
	int LostTimes = 0;
	
	
	// attributes in games
	boolean isLandlord = false; // 角色：地主 or 贫民
	CCard InHand[]; 
	CCard OnTable[] = new CCard[3];
	
	public CPlayer(){}
	public CPlayer(int id)
	{
		this.id = id;
	}
	
	//顺牌
	public void  ClearCards()
	{
		if(this.InHand == null)
			throw new IllegalArgumentException("手中的牌为空，顺牌操作错误");
		int length = this.InHand.length;
		CCard temp ;
		int i,j;
		for( i = 0 ;i<length ;i++)
		{
			for ( j=i+1; j<length;j++)
			{
				if(this.InHand[i].getRank()*4+this.InHand[i].getSuit() >
						this.InHand[j].getRank()*4+this.InHand[j].getSuit())
				{
					temp = this.InHand[i];
					this.InHand[i]=this.InHand[j];
					this.InHand[j] =temp;
				}
			}
		}
	}
	
	// 地主进底牌
	public void AddCards(CCard OnTable[])
	{
		if(this.InHand == null)
			throw new IllegalArgumentException("手中的牌为空,获取底牌错误");
		this.isLandlord = true;
		int i=0,j=0;
		CCard temp[] = new CCard[20]; 
		
		for(i= 0 ;i<17;i++)
		{
			temp[i] = this.InHand[i];
		}
		for(i = 17 ;i<20;i++)
		{
			temp[i] = OnTable[j++];
		}
		this.InHand = temp;
		this.ClearCards();
	}
	
	public int hashCode()
	{
		return id;
	}
}
