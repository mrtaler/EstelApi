namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg
{
    using System;

    public class Worker : Customer
    {

        public DateTimeOffset WorkFrom { get; set; }

        public DateTimeOffset? RetirementDate { get; set; }
        public StaffType StaffType { get; set; }
    }

    /* 

      HasKey(p => p.Id);
      Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);*/
}