// using System.Threading.Tasks.Dataflow;

// var path = "/Users/tomasfrechou/Desktop/MyConsoleApp2/input2.txt";
// var safeReports = File.ReadAllLines(path).Select(x => {
//     var levels = x.Split(" ").Select(y => int.Parse(y)).ToList();

//     return new Report() { 
//         Levels = levels,
//         Decreasing = levels[0] > levels[levels.Count - 1],
//         };
//     }).ToList();


// safeReports = Function(safeReports);
// Console.WriteLine($"safeReports: {safeReports.Where(x => x.Safe).Count()}");


// var unsafeReports = safeReports.Where(x => !x.Safe).ToList();
// var aaa = FixedUnsafeReports(unsafeReports);
// var safeReports2 = Function(aaa);

// Console.WriteLine($"safeReports2: {safeReports2.Where(x => x.Safe).Count()}");


// List<Report> Function(List<Report> reports)
// {
//     foreach (var report in reports) {
//         var decreasing = true;
//         var increasing = true;    
//         var increased = 0;
//         var decreased = 0;


//         var index = 0;
//         foreach (var currentLevel in report.Levels) {
//             if (index < report.Levels.Count - 1) {
//                 var nextLevel = report.Levels[index + 1];

//                 var isDecressing = currentLevel > nextLevel;
//                 var isIncreassing = currentLevel < nextLevel;
//                 var diff = Math.Abs(currentLevel - nextLevel) >= 1 && Math.Abs(currentLevel - nextLevel) <= 3;

                
//                 if (!isDecressing) {
//                     increased += 1;  
//                 }
//                 if (!isIncreassing) {
//                     decreased += 1;
//                 }

//                 decreasing = decreasing && isDecressing && diff;
//                 increasing = increasing && isIncreassing && diff;        

//                 index++;
//             }    
//         }

//         if (decreasing || increasing) {
//             report.Safe = true;
//         } 
//     }

//     return reports;
// }

// List<Report> FixedUnsafeReports(List<Report> reports) {
//     var result = new List<Report>();

//     foreach (var report in reports) {

//         var index = 0;
//         var indexes = new List<int>();
//         foreach (var currentLevel in report.Levels) {
//             if (index < report.Levels.Count - 1) {
//                 var nextLevel = report.Levels[index + 1];
//                 if (report.Decreasing && currentLevel <= nextLevel) {
//                     indexes.Add(index);
//                 }
//                 else if (!report.Decreasing && currentLevel >= nextLevel) {
//                     indexes.Add(index);
//                 }
//             }

//             index++;
//         }

//         if (indexes.Count == 1) {
//             report.Levels.RemoveAt(indexes[0]);
//             report.Safe = false;
//             result.Add(report);
        
//             // Console.WriteLine(indexes);
//         }
//     }

//             // Console.WriteLine(result.Count);

//     return result;
// }