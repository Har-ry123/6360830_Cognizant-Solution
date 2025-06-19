// Main.java
import java.util.HashMap;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        try (Scanner scanner = new Scanner(System.in)) {
            System.out.print("Enter initial amount: ");
            double initial = scanner.nextDouble();

            System.out.print("Enter annual growth rate (as decimal, e.g., 0.05 for 5%): ");
            double rate = scanner.nextDouble();

            System.out.print("Enter number of years to forecast: ");
            int years = scanner.nextInt();

            // Basic recursive forecast
            double basicResult = Forecast.recursiveForecast(initial, rate, years);
            System.out.printf("Future Value (Recursive): $%.2f\n", basicResult);

            // Memoized forecast
            HashMap<Integer, Double> memo = new HashMap<>();
            double memoResult = Forecast.memoizedForecast(initial, rate, years, memo);
            System.out.printf("Future Value (Memoized): $%.2f\n", memoResult);
        }
    }
}
