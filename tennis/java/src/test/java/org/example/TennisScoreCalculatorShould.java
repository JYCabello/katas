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
				Arguments.of(0, 0,"love - love")
		);
	}
}
