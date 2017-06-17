using NET_POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_POC.Migrations
{
    class GlobalSeeder
    {
        public void SeedDatabase(NET_POC.Models.DataContexts context)
        {
            //Get all the "ISeed" implementations in this assembly
            var seedTypes = typeof(GlobalSeeder).Assembly.GetTypes().Where(t => typeof(ISeed).IsAssignableFrom(t) && t.IsClass);

            //Little bit of Linq to object to get all the types in a suitable format.
            var seeds =
                seedTypes.Select(st => new
                {
                    SeedType = st,
                    DependingSeeds = st.GetCustomAttributes(typeof(DependsOnAttribute), true).Cast<DependsOnAttribute>().Select(ds => ds.DependingType).ToList()
                }).ToList();

            //While there is still some seeds to process
            while (seeds.Count() > 0)
            {
                //Find all the seeds without anymore depending seeds to process
                var oprhenSeeds = seeds.Where(s => s.DependingSeeds.Count == 0).ToList();
                foreach (var orphenSeed in oprhenSeeds)
                {
                    //Instanciate the current seed
                    ISeed seedInstance = (ISeed)Activator.CreateInstance(orphenSeed.SeedType);
                    //Execute seed process
                    seedInstance.SeedData(context);

                    //Remove the processed seed from all the dependant seeds
                    var relatedSeeds = seeds.Where(s => s.DependingSeeds.Any(ds => ds == orphenSeed.SeedType));
                    foreach (var relatedSeed in relatedSeeds)
                    {
                        relatedSeed.DependingSeeds.Remove(orphenSeed.SeedType);
                    }
                    //Remove the processed seed from the "to be processed list".
                    seeds.Remove(orphenSeed);
                }
            }
            //Finally save all changes to the Entity framework context.
            context.SaveChanges();
        }
    }
}