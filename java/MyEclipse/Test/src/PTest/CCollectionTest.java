package PTest;

// 集合与线性数组

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class CCollectionTest implements ITest{
	public void test() {
		
		CCard card = new CCard(CCard.SPADE,CCard.ACE);
		Collection<CCard> others = new ArrayList<CCard>();
		Collection<CCard> cards = new ArrayList<CCard>();
		cards.add(new CCard(CCard.HEART, CCard.TEN));
		cards.add(new CCard(CCard.CLUB, CCard.JACK));
		cards.add(new CCard(CCard.DIAMOND, CCard.QUEEN)); 
		cards.add(new CCard(CCard.SPADE, CCard.KING));
		cards.add(new CCard(CCard.SPADE, CCard.ACE));
		
		others.add(new CCard(CCard.SPADE, CCard.KING));
		others.add(new CCard(CCard.SPADE, CCard.ACE));
		others.add(new CCard(CCard.SPADE, CCard.DEUCE));
		others.add(new CCard(CCard.HEART, CCard.DEUCE));
		others.add(new CCard(CCard.CLUB, CCard.DEUCE));
		
		//cards.addAll(others);
		//cards.removeAll(others);
		//cards.retainAll(others);
		//System.out.println(cards.contains(card));
		
		List<CCard> li = new ArrayList<CCard>();
		li.add(new CCard(CCard.CLUB, CCard.THREE));
		li.add(new CCard(CCard.CLUB, CCard.FOUR));
		li.add(new CCard(CCard.CLUB, CCard.FIVE));
		li.add(new CCard(CCard.CLUB, CCard.SIX));
		li.add(new CCard(CCard.CLUB, CCard.SEVEN));
		li.add(new CCard(CCard.SPADE, CCard.ACE));
		card = li.set(2, card);
		System.out.println(li);
		System.out.println(li.indexOf(card));
		
		
	}

}
