import RomanNumerals.RomanNumerals
import org.junit.jupiter.params.ParameterizedTest
import org.junit.jupiter.params.provider.Arguments
import org.junit.jupiter.params.provider.MethodSource
import java.util.stream.Stream
import org.junit.jupiter.api.Assertions.assertEquals


class RomanNumeralsShould {
    @ParameterizedTest
    @MethodSource("romanNumerals")
    fun `map a number to a roman numeral`(decimal: Int, roman: String) {
        assertEquals(roman, RomanNumerals.convert(decimal))
    }

    @ParameterizedTest
    @MethodSource("romanNumerals")
    fun `map a number to a roman numeral, but FP`(decimal: Int, roman: String) {
        assertEquals(roman, RomanNumerals.convertFn(decimal))
    }

    @ParameterizedTest
    @MethodSource("romanNumerals")
    fun `map a number to a roman numeral, but recursive`(decimal: Int, roman: String) {
        assertEquals(roman, RomanNumerals.convertRec(decimal))
    }

    companion object {
        @JvmStatic
        fun romanNumerals(): Stream<Arguments> {
            return Stream.of(
                Arguments.of(1, "I"),
                Arguments.of(2, "II"),
                Arguments.of(3, "III"),
                Arguments.of(4, "IV"),
                Arguments.of(5, "V"),
                Arguments.of(7, "VII"),
                Arguments.of(10, "X"),
                Arguments.of(12, "XII"),
                Arguments.of(14, "XIV"),
                Arguments.of(16, "XVI")
            )
        }
    }
}
