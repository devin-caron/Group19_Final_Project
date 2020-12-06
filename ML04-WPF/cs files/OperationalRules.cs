using System;
using System.Collections.Generic;
using System.Text;

namespace ML03
{
   ///
   /// \brief <i>Class</i> <b>OperationalRules</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the OperationalRules.
   /// 
   /// As a OperationalRules I want to be able to tally the extra charges OSHT adds on to
   /// the final cost for the Buyer to cover overages.
   /// 
   /// Child derived from Parent MySql class.
   ///
   class OperationalRules : MySql
   {
      const int driverOperation = 0;
      const int loadLTL = 0;
      bool statusFTL
      { get; set; }
      int surchargeHr
      { get; set; }


      ///
      /// \brief Constructor for <b>OperationalRules</b>
      /// \details <b>Details</b>
      /// 
      /// Creates the required object. 
      ///
      public OperationalRules() : base()
      {
 
      }

      ///
      /// \brief <b>opRules</b> function for <b>OperationalRules</b>
      /// \details <b>Details</b>
      ///
      /// Operational rules placed for access and verification 
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void opRules()
      {
         // TODO_implement
      }
   }
}
