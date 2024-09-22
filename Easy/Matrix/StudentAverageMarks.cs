public class StudentMarks{

public void Run(){
        // int N = 3;
        // int M = 5;
        int[,] marks = {
            {75, 76, 65, 87, 87},
            {78, 76, 68, 56, 89},
            {67, 87, 78, 77, 65}
        };
        var asns = calculateMarks(3,5,marks);
}

public int[] calculateMarks(int N, int M, int[,] marks){
    int[] studentTotal = new int[N];
    int lowestAverage = int.MaxValue;
    int indx = -1;
    for (int I = 0; I < M; I++)
    {
        int subjectAverage = 0;
        for(int II = 0; II < N; II++){
            studentTotal[II] += marks[II,I];            
            subjectAverage += marks[II,I];
        }

        if(subjectAverage < lowestAverage){
            lowestAverage = subjectAverage;
            indx = I;
        }
    }

    for(int II = 0; II < N; II++){
        studentTotal[II] -= marks[II,indx];            
    }

    return studentTotal;
}

}