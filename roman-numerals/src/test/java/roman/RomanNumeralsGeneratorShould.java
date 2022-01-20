package roman;

import java.util.stream.Stream;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.Arguments;
import org.junit.jupiter.params.provider.MethodSource;
import static org.junit.jupiter.api.Assertions.assertEquals;

public class RomanNumeralsGeneratorShould {
	@ParameterizedTest
	@MethodSource("romanNumerals") public void
	generate_roman_representation_of_decimal(int decimal, String representation) {
		assertEquals(representation, RomanNumeralsGenerator.convert(decimal));
	}

	private static Stream<Arguments> romanNumerals() {
		return Stream.of(
				Arguments.of(1, "I"),
				Arguments.of(2, "II"),
				Arguments.of(3, "III"),
				Arguments.of(4, "IV"),
				Arguments.of(5, "V"),
				Arguments.of(7, "VII"),
				Arguments.of(10, "X"),
				Arguments.of(12, "XII"),
				Arguments.of(16, "XVI")
		);
	}
}
