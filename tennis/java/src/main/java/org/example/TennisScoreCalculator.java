package org.example;

import java.util.AbstractMap;
import java.util.Map;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class TennisScoreCalculator {
	public String score(int player1Score, int player2Score) {
		switch (calculateResult(player1Score, player2Score)) {
			case Deuce:
				return getDeuce(player1Score);
			case Difference:
				return getScoreDiff(player1Score, player2Score);
			case Win1:
				return "player 1 wins";
			case Win2:
				return "player 2 wins";
			case Advantage1:
				return "player 1 advantage";
			case Advantage2:
				return "player 2 advantage";
		}
		throw new IndexOutOfBoundsException("Results were not computable");
	}

	private Result calculateResult(int player1Score, int player2Score) {
		if (player1Score == player2Score)
			return Result.Deuce;

		if (player2Score <= 3 && player1Score <= 3)
			return Result.Difference;

		if (wonOver(player1Score, player2Score))
			return Result.Win1;

		if (wonOver(player2Score, player1Score))
			return Result.Win2;

		if (advantageOver(player1Score, player2Score))
			return Result.Advantage1;

		if (advantageOver(player2Score, player1Score))
			return Result.Advantage2;

		throw new IndexOutOfBoundsException("Results were not computable");
	}

	private enum Result {
		Deuce,
		Difference,
		Win1,
		Win2,
		Advantage1,
		Advantage2
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
		return score >= 3 ? "deuce" : scores.get(score) + " - all";
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
