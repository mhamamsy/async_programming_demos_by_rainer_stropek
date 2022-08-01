using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {

        webBuilder.Configure(app =>
        {
            app.Run(async context =>
            {

                #region  Simulate Bad access of DB

                ////Thread.Sleep(1000); //  bad code as it blocks the thread

                //Task.Delay(1000).Wait(); // bad code like Sleep() as Wait() will block the thread

                //await context.Response.WriteAsync("Hello World!");

                //// use Apache Benchmark tool : a nice tool with which you can do load testing 
                //// You can find how to install Apache Benchmark tool in my study notes for the course

                //// Type the following command 

                //// >ab -n 100 -c 10 http://localhost:5000/

                //// this will send 100 requests and 10  of them in parallel

                //// test for your own an check the result

                #endregion


                #region  Simulate Good Async access of DB


                await Task.Delay(1000);
                // id 
                await context.Response.WriteAsync("Hello World!");


                // Type the following command 

                // >ab -n 100 -c 10 http://localhost:5000/

                // test Apache Benchmark

                #endregion
            });
        });

    })
    .Build().Run();

