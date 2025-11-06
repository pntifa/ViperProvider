using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using MVC_Viper.Models.MetaData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Viper.Models
{
    [ModelMetadataType(typeof(AdminsMetaData))]
    public partial class Admin
    {

    }

    [ModelMetadataType(typeof(BillMetaData))]
    public partial class Bill
    {
        
    }

    [ModelMetadataType(typeof(CallsMetaData))]
    public partial class Call
    {

    }

    [ModelMetadataType(typeof(ClientsMetaData))]
    public partial class Client
    {

    }

    [ModelMetadataType(typeof(PhoneMetaData))]
    public partial class Phone
    {

    }

    [ModelMetadataType(typeof(ProgramsMetaData))]
    public partial class Programs
    {

    }

    [ModelMetadataType(typeof(SellerMetaData))]
    public partial class Seller
    {

    }

    [ModelMetadataType(typeof(UserMetaData))]
    public partial class User
    {

    }




}
