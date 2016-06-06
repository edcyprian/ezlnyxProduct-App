using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using EzlynxProductApp.Models;

namespace EzlynxProductApp.Migrations
{
    [ContextType(typeof(ModelsContext))]
    partial class initial
    {
        public override string Id
        {
            get { return "20160606122503_initial"; }
        }
        
        public override string ProductVersion
        {
            get { return "7.0.0-beta5-13549"; }
        }
        
        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("SqlServer:DefaultSequenceName", "DefaultSequence")
                .Annotation("SqlServer:Sequence:.DefaultSequence", "'DefaultSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .Annotation("SqlServer:ValueGeneration", "Sequence");
            
            builder.Entity("EzlynxProductApp.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity);
                    
                    b.Property<string>("name");
                    
                    b.Property<string>("shortDesc");
                    
                    b.Property<string>("type");
                    
                    b.Key("id");
                });
        }
    }
}
