using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using System.Linq;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            return context.Jobs.Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                Customer = mapToCustomerModel(x.Customer),
                When = x.When
            }).ToArray();
        }

        public JobModel GetJob(int jobId)
        {
            return context.Jobs.Where(x => x.JobId == jobId).Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                Customer = mapToCustomerModel(x.Customer),
                When = x.When
            }).SingleOrDefault();
        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var addedJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                CustomerId = model.CustomerId,
                When = model.When
            });

            context.SaveChanges();

            return new JobModel
            {
                JobId = addedJob.Entity.JobId,
                Engineer = addedJob.Entity.Engineer,
                Customer = mapToCustomerModel(addedJob.Entity.Customer),
                When = addedJob.Entity.When
            };
        }

        private static CustomerModel mapToCustomerModel(Customer customer)
        {
            if (customer == null) 
            {
                // This is to manage the existing Job entries without customer
                return new CustomerModel();
            }

            return new CustomerModel() { CustomerId = customer.CustomerId, Name = customer.Name, Type = customer.Type };
        }
    }
}
