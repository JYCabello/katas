package org.example;

import java.util.AbstractMap;
import java.util.Map;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class TennisScoreCalculator {
	public String score(int player1Score, int player2Score) {
		if (player1Score == player2Score && player1Score <= 3)
			return getDeuce(player1Score);

		if (player2Score <= 3 && player1Score <= 3)
			return getScoreDiff(player1Score, player2Score);

		if (wonOver(player1Score, player2Score))
			return "player 1 wins";

		if (wonOver(player2Score, player1Score))
			return "player 2 wins";

		if (advantageOver(player1Score, player2Score))
			return "player 1 advantage";

		if (advantageOver(player2Score, player1Score))
			return "player 2 advantage";

		return null;
	}

	private boolean advantageOver(int scoreA, int scoreB) {
		boolean is1OverThreshold = scoreA > 3;
		int diff1To2 = scoreA - scoreB;
		return is1OverThreshold && diff1To2 == 1;
	}

	private boolean wonOver(int scoreA, int scoreB) {
		boolean isOverThreshold = scoreA > 3;
		int diff = scoreA - scoreB;
		return isOverThreshold && diff > 1;
	}

	private static String getDeuce(int score) {
		return score == 3 ? "deuce" : scores.get(score) + " - all";
	}

	private static String getScoreDiff(int scoreA, int scoreB) {
		return scores.get(scoreA) + " - " + scores.get(scoreB);
	}

	private static final Map<Integer, String> scores = Stream.of(
			new AbstractMap.SimpleEntry<>(0, "love"),
			new AbstractMap.SimpleEntry<>(1, "fifteen"),
			new AbstractMap.SimpleEntry<>(2, "thirty"),
			new AbstractMap.SimpleEntry<>(3, "forty")
	).collect(Collectors.toMap(AbstractMap.SimpleEntry::getKey, AbstractMap.SimpleEntry::getValue));
}
