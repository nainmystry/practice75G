public class GasStation
{
    public int CanCompleteCircuit(int[] gas, int[] cost) {
         int total_tank = 0;
        int current_tank = 0;
        int starting_station = 0;
        
        for (int i = 0; i < gas.Length; i++) {
            // Update the overall gas balance
            total_tank += gas[i] - cost[i];
            
            // Update the gas balance for the current segment
            current_tank += gas[i] - cost[i];
            
            // // If the gas balance for the current segment is negative, i.e cant reach
            if (current_tank < 0) {
                // We cannot complete the trip starting from the current starting_station
                // Therefore, set the next station as the new candidate starting station
                starting_station = i + 1;
                // Reset the current segment gas balance
                current_tank = 0;
            }
        }
        
        // If total gas is less than total cost, we cannot complete the circuit
        return total_tank >= 0 ? starting_station : -1;
    }
}