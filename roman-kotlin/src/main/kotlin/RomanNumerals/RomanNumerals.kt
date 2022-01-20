package RomanNumerals

object RomanNumerals {
    fun convert(decimal: Int): String {
        val builder = StringBuilder()
        var dec = decimal

        for (roman in symbols) {
            while(dec >= roman.decimal) {
                dec -= roman.decimal
                builder.append(roman.symbol)
            }
        }

        return builder.toString()
    }

    fun convertRec(decimal: Int): String {
        tailrec fun go(dec: Int, roman: StringBuilder): StringBuilder {
            val symbol = symbols.find { dec >= it.decimal }
            if (symbol != null)
                return go(dec - symbol.decimal, roman.append(symbol.symbol))
            return roman
        }

        return go(decimal, StringBuilder()).toString()
    }

    fun convertFn(decimal: Int): String =
        symbols
            .fold(SymbolTranslationProgress("", decimal))
            { acc, sym ->
                val result = getSymbolsFor(sym, acc.decimal)
                SymbolTranslationProgress(acc.symbols + result.symbols, acc.decimal - result.usedUp)
            }.symbols


    private fun getSymbolsFor(symbol: Roman, decimal: Int): SymbolCreationResult =
        if (decimal >= symbol.decimal) {
            val repeats = decimal / symbol.decimal
            SymbolCreationResult(symbol.symbol.repeat(repeats), repeats * symbol.decimal)
        } else
            SymbolCreationResult("", 0)


    data class SymbolTranslationProgress(val symbols: String, val decimal: Int)

    data class SymbolCreationResult(val symbols: String, val usedUp: Int)

    data class Roman(val decimal: Int, val symbol: String)

    private val symbols = listOf(
        Roman(10, "X"),
        Roman(9, "IX"),
        Roman(5, "V"),
        Roman(4, "IV"),
        Roman(1, "I"),
    ).sortedByDescending { it.decimal }

    sealed class Error {
        class Unauthenticated(val resourceName: String): Error()
        class Unauthorized(val resourceName: String, val userName: String): Error()
        class NotFound(val entityName: String): Error()
    }

    data class HttpResponse(val code: Int, val message: String)

    fun mapError(error: Error): HttpResponse =
        when(error) {
            is Error.NotFound ->
                HttpResponse(404, "Could not find entity of type ${error.entityName}")
            is Error.Unauthenticated ->
                HttpResponse(401, "You are not authenticated")
            is Error.Unauthorized ->
                HttpResponse(401, "User ${error.userName} is not authorized to access resource ${error.resourceName}")
        }
}
