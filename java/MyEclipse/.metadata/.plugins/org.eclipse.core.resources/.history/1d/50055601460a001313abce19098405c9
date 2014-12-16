package PPoker;

import java.util.Arrays;

public class CText {
	public static void main(String[] args)
	{
		CPoker poker = new CPoker(20);
		poker.shuffle(100);
		int i=0;
		
		// 创建玩家
		CPlayer one = new CPlayer(1);
		CPlayer two = new CPlayer(2);
		CPlayer three = new CPlayer(3);
		CPlayer Landlord;
		
		// 给玩家发牌
		
		Landlord = poker.deal(one, two, three);
		Landlord = poker.getLandLord();
		System.out.println(Arrays.toString(poker.OnTable));
		one.ClearCards();
		two.ClearCards();
		three.ClearCards();
		
		Landlord.AddCards(poker.getOnTable());
		
		for(i = 0 ; i < one.InHand.length;i++)
		{
			System.out.print(one.InHand[i].getCard() + " ");
		}
		System.out.println();
		for(i = 0 ; i < two.InHand.length;i++)
		{
			System.out.print(two.InHand[i].getCard() + " ");
		}
		System.out.println();
		for(i = 0 ; i < three.InHand.length;i++)
		{
			System.out.print(three.InHand[i].getCard() + " ");
		}
		
		System.out.println();
		
		/*System.out.println();
		for(i = 0 ; i < 3;i++)
		{
			System.out.print(OnTable[i].getCard() + " ");
		}
		
		for(i=0;i<54;i++)
		{
			System.out.print(poker.getPoker(i) +" ");
			if((i+1)%17==0)System.out.println();
		}*/
	}
}
