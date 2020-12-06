using System;
using System.Collections.Generic;
using System.Text;

namespace ML03
{
   ///
   /// \brief <i>Class</i> <b>CostCharges</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the CostCharges.
   /// 
   /// As a CostCharges I want to be able to tally the extra charges OSHT adds on to
   /// the final cost for the Buyer to cover overages.
   /// 
   /// Child derived from Parent MySql class.
   ///
   class CostCharges : MySql
   {
      float averageRateFTL
      { get; set; }
      float averageRateLTL
      { get; set; }
      float actualRateAdj
      { get; set; }


      ///
      /// \brief Constuctor for <b>CostCharges</b>
      /// \details <b>Details</b>
      /// 
      /// Creates the required object. 
      ///
      public CostCharges() : base()
      {

      }

      ///
      /// \brief <b>rateOSHT</b> function for <b>CostCharges</b>
      /// \details <b>Details</b>
      ///
      /// Rate adjustments for rateOSHT extra service charges
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void rateOSHT()
      {
         // TODO_implement
      }
   }
}
