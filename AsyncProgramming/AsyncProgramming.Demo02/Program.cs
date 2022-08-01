using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

// make console application and edit csproj to be :

//<TargetFramework>net5.0</TargetFramework>
//<LangVersion>preview</LangVersion>


// Then remove code in Program.cs and Main Function

// ================================ //

#region Blocking Programming 

//var lines = File.ReadAllLines("myfile.txt");          // => Blocking Programming

//foreach (var line in lines)
//{
//    Console.WriteLine(line);
//}

#endregion

// ================================ //

#region Async Programming example1

////var fileReadTask = File.ReadAllLinesAsync("myfile.txt");    // => Non Blocking Programming (Async Progrmmming)


//// Note: Naming Convention for writing Async Function >> BlablablaAsync()
//// >> Add myfile.txt and add some text from Lorem Ipsum




//// File.ReadAllLinesAsync() >> Returns Task<string[]> 
//// so what is a task ??
//// a task is not a thread >> it is like a task in human being
//// you assign a task to a person to do something and when he finish, he will inform you 
//// you can start multiple tasks and starting a task is not a problem unlike starting a thread

//// Task has a status ( started, completed, failed, ... ) and a result (like here string[])


////Console.WriteLine(fileReadTask.Status);

////Thread.Sleep(1);

////Console.WriteLine(fileReadTask.Status);

//// how can you wait for a task to be completed ?

//// if you use wait :
////fileReadTask.Wait(); //  this will block the thread until task is completed so it doesn't make sense to wait

//// how about acccessing the result ?

////var lines = fileReadTask.Result; // not a good idea because task may be not finished yet


//// the solution is to use:
//File.ReadAllLinesAsync("myfile.txt")
//    .ContinueWith(t =>
//    {

//        // We are sure that here the task will be completed
//        // an action will be scheduled to be executed after task is completed


//        // but if we run this forloop , no output will be written in console
//        foreach (var line in t.Result)
//        {
//            Console.WriteLine(line);
//        }

//        // the problem is that  the main thread will be exit before the task has been completed and before scheduled action executed because the thread was not blocked

//        // we want to make sure that the main thread will not be exit before the task completed
//    });

//// simple solution to this problem in this situation :
//Console.ReadKey();

//// but this is not the practical solution and we will find it later



#endregion

#region Async Programming example2

//// What will happen if the task doesn't complete due to an exception

////File.ReadAllLinesAsync("myfile2.txt")
////    .ContinueWith(t =>
////    {

////        foreach (var line in t.Result)
////        {
////            Console.WriteLine(line);
////        }
////    });

////Console.ReadKey();

//// no exception will be bumb

//// you must check fauilure by yourself

//File.ReadAllLinesAsync("myfile2.txt")
//    .ContinueWith(t =>
//    {
//        if (t.IsFaulted)
//        {
//            Console.Error.WriteLine(t.Exception);
//            return;
//        }
//        foreach (var line in t.Result)
//        {
//            Console.WriteLine(line);
//        }
//    });

//Console.ReadKey();


//// this is a complex way to program in this way >>> what is the solution?
//// new magic solution in c# has been introduced 


#endregion

#region Async Programming by magic (async and await) keywords example1

//// 2 new magic keyword (async , await) 
//// very simple way to do async programming

//async Task ReadFileAsync()
//{
//    var lines = await File.ReadAllLinesAsync("myfile.txt");

//    //var lines = await File.ReadAllLinesAsync("myfile2.txt"); // this will throw exception like the blocking programming



//    foreach (var line in lines)
//    {
//        Console.WriteLine(line);
//    }
//}

//await ReadFileAsync();



//// async , await making handling a task as similar as doing sync programming




#endregion

#region Async Programming by magic (async and await) keywords example2

//async Task<int> GetDataFromNetworkAsync(){
//    // similulate a network call
//    await Task .Delay(150);
//    // await will not block cpu thread ... await tell c# if you have anything else do it , and i will waiting to be notified when the task finished to complete.

//    // await schedule the reset of the method and it will be automatically execute after the task completed. it doesn't block the thread but it will free the thread and wake up once the task completed.

//    // with EF we will always use async call to DB


//    var result = 42;
//    return result;

//}

//var networkResult = await GetDataFromNetworkAsync();

//Console.WriteLine(networkResult);

#endregion

#region Async Programming by magic (async and await) keywords using lambda example3

Func<Task<int>> GetDataFromNetworkAsync = async () =>
{
    // similulate a network call
    await Task.Delay(150);
    // await will not block cpu thread ... await tell c# if you have anything else do it , and i will waiting to be notified when the task finished to complete.

    // await schedule the reset of the method and it will be automatically execute after the task completed. it doesn't block the thread but it will free the thread and wake up once the task completed.

    // with EF we will always use async call to DB


    var result = 42;
    return result;

};

var networkResult = await GetDataFromNetworkAsync();

Console.WriteLine(networkResult);

#endregion

