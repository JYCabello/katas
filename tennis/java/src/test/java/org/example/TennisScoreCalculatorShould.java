package org.example;

import java.util.stream.Stream;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.Arguments;
import org.junit.jupiter.params.provider.MethodSource;
import static org.junit.jupiter.api.Assertions.assertEquals;


public class TennisScoreCalculatorShould {
	@ParameterizedTest
	@MethodSource("matchGenerator")
	public void
	returns_match_result(int player1Score, int player2Score, String expected) {
		assertEquals(expected, new TennisScoreCalculator().score(player1Score, player2Score));
	}

	private static Stream<Arguments> matchGenerator() {
		return Stream.of(
				Arguments.of(0, 0, "love - all"),
				Arguments.of(0, 1, "love - fifteen"),
				Arguments.of(1, 1, "fifteen - all"),
				Arguments.of(2, 2, "thirty - all"),
				Arguments.of(3, 3, "deuce"),
				Arguments.of(8, 8, "deuce"),
				Arguments.of(0, 2, "love - thirty"),
				Arguments.of(0, 3, "love - forty"),
				Arguments.of(1, 3, "fifteen - forty"),
				Arguments.of(5, 0, "player 1 wins"),
				Arguments.of(5, 7, "player 2 wins"),
				Arguments.of(7, 6, "player 1 advantage"),
				Arguments.of(6, 7, "player 2 advantage")
		);
	}
}
