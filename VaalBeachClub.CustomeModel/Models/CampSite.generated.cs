//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor
//     https://github.com/msawczyn/EFDesigner
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace VaalBeachClub.Models.Domain.CampSites
{
   public partial class CampSite : VaalBeachClub.CustomeModel.BaseEntity
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected CampSite(): base()
      {
         Init();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="campsitenumber"></param>
      public CampSite(string campsitenumber)
      {
         if (string.IsNullOrEmpty(campsitenumber)) throw new ArgumentNullException(nameof(campsitenumber));
         CampSiteNumber = campsitenumber;
         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="campsitenumber"></param>
      public static CampSite Create(string campsitenumber)
      {
         return new CampSite(campsitenumber);
      }

      /*************************************************************************
       * Persistent properties
       *************************************************************************/

      /// <summary>
      /// Required
      /// </summary>
      [Required]
      public string CampSiteNumber { get; set; }

   }
}

