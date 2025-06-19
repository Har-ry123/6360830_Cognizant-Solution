// Forecast.java
import java.util.HashMap;

public class Forecast {

    // Basic recursive method
    public static double recursiveForecast(double initialValue, double growthRate, int years) {
        if (years == 0) {
            return initialValue;
        }
        return recursiveForecast(initialValue, growthRate, years - 1) * (1 + growthRate);
    }

    // Memoized recursive method
    public static double memoizedForecast(double initialValue, double growthRate, int years, HashMap<Integer, Double> memo) {
        if (years == 0) {
            return initialValue;
        }
        if (memo.containsKey(years)) {
            return memo.get(years);
        }
        double result = memoizedForecast(initialValue, growthRate, years - 1, memo) * (1 + growthRate);
        memo.put(years, result);
        return result;
    }
}
