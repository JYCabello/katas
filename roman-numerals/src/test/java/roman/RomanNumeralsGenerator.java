package roman;

import java.util.AbstractMap;
import java.util.Map;
import java.util.SortedMap;
import java.util.TreeMap;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class RomanNumeralsGenerator {
	public static String convert(int decimal) {
		return convertButSane(decimal);
	}

	private static String convertButSane(int decimal) {
		StringBuilder roman = new StringBuilder();
		for (Map.Entry<Integer, String> symbol: meh.entrySet()) {
			while(decimal >= symbol.getKey()) {
				decimal -= symbol.getKey();
				roman.append(symbol.getValue());
			}
		}
		return roman.toString();
	}

	private static final SortedMap<Integer, String> meh =
			new TreeMap<>(
				Map.of(1,"I", 4, "IV", 5, "V", 9, "IX", 10, "X")
			).descendingMap();

	private static StringBuilder convertWithAHeadache(int decimal, StringBuilder roman) {
		return symbols
				.keySet()
				.stream()
				.filter(k -> decimal >= k)
				.max(Integer::compareTo)
				.stream()
				.findFirst()
				.map(v -> convertWithAHeadache(decimal - v, roman.append(symbols.get(v))))
				.orElse(roman);
	}

	private static final Map<Integer, String> symbols = Stream.of(
			new AbstractMap.SimpleEntry<>(1, "I"),
			new AbstractMap.SimpleEntry<>(5, "V"),
			new AbstractMap.SimpleEntry<>(10, "X"),
			new AbstractMap.SimpleEntry<>(4, "IV")
	).collect(Collectors.toMap(AbstractMap.SimpleEntry::getKey, AbstractMap.SimpleEntry::getValue));
}
