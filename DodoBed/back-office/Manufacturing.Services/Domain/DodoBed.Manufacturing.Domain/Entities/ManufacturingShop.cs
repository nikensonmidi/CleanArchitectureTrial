using System;
using System.Collections.Generic;

namespace DodoBed.Manufacturing.Domain.Entities
{
    public class ManufacturingShop
    {
        public int ManufacturingShopId { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<ManufacturingShopProcessor> Processors { get; set; }
    }
    public class ManufacturingShopSchedule
    {
        public long ManufacturingShopScheduleId { get; set; }
        public DateTime ScheduleTime { get; set; }//Must be set on a pessimistic time of ManufacturedProduct's HighestAssembledTimeInSec
        public ICollection<ManufacturedProductScheduled> ProductToBeBuilt { get; set; }
      

    }

    public class ManufacturingShopScheduleLog
    {
        public long ManufacturingShopScheduleLogId { get; set; }
        public ManufacturingShopSchedule ManufacturingShopSchedule { get; set; }
        public ManufacturingShopProcessorActivity ManufacturingShopProcessorActivity { get; set; }
      
    }
    public class ManufacturingShopProcessorActivity
    {
        public long ManufacturingShopProcessorActivityId { get; set; }
        public ICollection<ManufacturedProductCreated> CreatedProducts { get; set; }
        public ManufacturingShopProcessorState ProcessorState { get; set; }
    }

    public class ManufacturingShopProcessor
    {
        public int ManufacturingShopProcessorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Note> Instructions { get; set; }
        public ICollection<Tool> Tools { get; set; }
        
       
        public int ProcessingSequence { get; set; }//is it first or second, third...
    }



    public class ManufacturingShopProcessorState
    {
        public int ManufacturingShopProcessorStateId { get; set; }
        public DateTime StateBeginAt { get; set; }
        public string StateReason { get; set; }
        public ProcessorStateNames StateName { get; set; }
    }

    
    public enum ProcessorStateNames
    {
        Completed,
        Interrupted,//Unknown reasons why it stops
        Paused,
        Starting,
        Failed
        
    }
}