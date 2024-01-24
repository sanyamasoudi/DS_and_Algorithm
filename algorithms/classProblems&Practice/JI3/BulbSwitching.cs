public class BulbSwitching
{
    public static int ComputeMinSwitch(List<int> state)
    {
        int count = 0; // Initialize the count of switches to 0
        int n = state.Count;

        for (int i = 0; i < n; i++)
        {
            if (state[i] == 0)
            {
                // If the bulb is off, press the switch
                count++;
                // Toggle the state of all bulbs to the right
                for (int j = i; j < n; j++)
                {
                    state[j] = 1 - state[j];
                }
            }
        }

        return count;
    }

}