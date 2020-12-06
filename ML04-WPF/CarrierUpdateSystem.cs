using System;
using System.Collections.Generic;
using System.Text;

namespace ML03
{
   ///
   /// \brief <i>Class</i> <b>CarrierUpdateSystem</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the Communications.
   /// 
   /// As a CarrierUpdateSystem link I want to be able to provide external information,
   /// acting as a relay for external markets.
   /// 
   /// Child derived from Parent Communications class.
   ///
   class CarrierUpdateSystem : Communications
   {


      string carrierName
      { get; set; }
      string depotCity
      { get; set; }
      int availabilityFTL
      { get; set; }
      int availabilityLTL
      { get; set; }
      float rateFTL
      { get; set; }
      float rateLTL
      { get; set; }
      float reeferCharge
      { get; set; }


      ///
      /// \brief Constructor for <b>CarrierUpdateSystem</b>
      /// \details <b>Details</b>
      /// 
      /// Creates the required object. 
      ///
      public CarrierUpdateSystem() : base()
      {

      }

      ///
      /// \brief <b>markupFTL</b> function for <b>CarrierUpdateSystem</b>
      /// \details <b>Details</b>
      ///
      /// Markup Estimated FTL rate by 8% 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void markupFTL()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>markupLTL</b> function for <b>CarrierUpdateSystem</b>
      /// \details <b>Details</b>
      ///
      /// Markup Estimated LTL rate by 5% 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void markupLTL()
      {
         // TODO_implement
      }

      ///
      /// \brief <b>convertedLTL</b> function for <b>CarrierUpdateSystem</b>
      /// \details <b>Details</b>
      ///
      /// Markup Estimated LTL rate by 5% 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void convertedLTL()
      {
         // TODO_implement
      }
   }
}
