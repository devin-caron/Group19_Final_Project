using System;
using System.Collections.Generic;
using System.Text;

namespace ML03
{
   ///
   /// \brief <i>Class</i> <b>FutureOrderAdjustments</b>
   /// \details <b>Details</b>
   ///
   /// Characteristics that represent the requirements of the FutureOrderAdjustments.
   /// 
   /// As a FutureOrderAdjustments I want to be able to tally the extra charges OSHT adds on to
   /// the final cost for the Buyer to cover overages.
   /// 
   /// Child derived from Parent MySql class.
   ///
   class FutureOrderAdjustments : MySql
   {

      string provinceNorth
      { get; set; }
      string provinceSouth
      { get; set; }
      bool carrierAvilability
      { get; set; }
      bool railOption
      { get; set; }
      int railDistance
      { get; set; }


      ///
      /// \brief Constructor for <b>FutureOrderAdjustments</b>
      /// \details <b>Details</b>
      /// 
      /// Creates the required object. 
      ///
      public FutureOrderAdjustments() : base()
      {

      }


      ///
      /// \brief <b>sqlDataFormProcess</b> function for <b>FutureOrderAdjustments</b>
      /// \details <b>Details</b>
      ///
      /// Future expansion options held but not initiated until approved
      ///
      /// \param None  - <b>void</b>
      ///
      /// \return  TBD  - <b>TBD</b>
      ///
      public void optionsHalfMoonBay()
      {
         // TODO_implement
      }
   }
}
