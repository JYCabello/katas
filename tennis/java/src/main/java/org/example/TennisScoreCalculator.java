package org.example;

public class TennisScoreCalculator {
	public String score(int player1Score, int player2Score) {
		if (player2Score == 1)
			return "love - fifteen";
		return "love - love";
	}
}
