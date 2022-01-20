package org.example;

public class TennisScoreCalculator {
	public String score(int player1Score, int player2Score) {

		if (player1Score == player2Score && player1Score == 1)
			return "fifteen - all";

		if (player2Score == 1)
			return "love - fifteen";
		return "love - all";
	}
}
